using LRSystemCore;
using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Services;
using Core.PubClass;

/// <summary>
/// EventWebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class QAWebService : System.Web.Services.WebService
{

    //注意：：返回的值如果是基本类型，那么可以直接返回，如果是泛型，则需要统一转换成string类型
    public QAWebService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    
    //private Stream strm = null;
    private DataBase db = new DataBase();
    private ChangeType changeType = new ChangeType();


    #region 获取问题集
    [WebMethod(EnableSession = true)]
    public string GetQAInfoList()
    {
        MemoryStream strm = new MemoryStream();

        List<MyQAInfo> myQAInfoList = new List<MyQAInfo>();
        DataSet infods = new DataSet();


        string sql = string.Empty;
        sql = @" select * from QA ";
        infods = db.ExecuteDataSet(sql);


        #region 反射转换ds到list
        foreach (DataRow infodr in infods.Tables[0].Rows)
        {
            MyQAInfo qaInfo = new MyQAInfo();
            PropertyInfo[] qaproperty = qaInfo.GetType().GetProperties();
            foreach (PropertyInfo info in qaproperty)
            {
                if (infods.Tables[0].Columns.Contains(info.Name))
                {
                    object value = infodr[info.Name];
                    if (value != DBNull.Value)
                    {
                        info.SetValue(qaInfo, value, null);
                    }
                }
            }
            myQAInfoList.Add(qaInfo);
        }
        #endregion

        //SoapFormatter formatter = new SoapFormatter();
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(strm, myQAInfoList);
        //StreamReader reader = new StreamReader(strm, Encoding.GetEncoding("gb2312"));//用指定的编码方式
        //string result = reader.ReadToEnd();

        strm.Position = 0;
        byte[] buffer = new byte[strm.Length];
        strm.Read(buffer, 0, buffer.Length);
        strm.Flush();
        strm.Close();
        string result = Convert.ToBase64String(buffer);

        return result;
    }
    #endregion

    #region 保存问题集
    [WebMethod(EnableSession = true)]
    public bool SaveQAInfoList(string str)
    {
        //BinaryFormatter formatter = new BinaryFormatter();

        //byte[] array = Encoding.ASCII.GetBytes(str);
        //MemoryStream strm = new MemoryStream(array);
        //List<MyQAInfo> myQAInfoList = (List<MyQAInfo>)formatter.Deserialize(strm);
        List<MyQAInfo> myQAInfoList = changeType.changeStrToT<List<MyQAInfo>>(str);

        try
        {
            List<string> sqllist = new List<string>();
            foreach (MyQAInfo item in myQAInfoList)
            {
                string sql = string.Empty;
                sql = @" insert into QA (QAINFO_ID, .QAINFO_CODE, .QAINFO_PARENTID,
                    .QAINFO_QUESTION, .QAINFO_ANSWER, .QAINFO_CREATETIME,
                    .QAINFO_LASTMODIFIEDTIME, .QAINFO_MODIFICATIONTIMES,
                    .QAINFO_IFINVALID, .QAINFO_STATE) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                sql = string.Format(sql, item.QAINFO_ID, item.QAINFO_CODE, item.QAINFO_PARENTID,
                    item.QAINFO_QUESTION, item.QAINFO_ANSWER, item.QAINFO_CREATETIME,
                    item.QAINFO_LASTMODIFIEDTIME, item.QAINFO_MODIFICATIONTIMES,
                    item.QAINFO_IFINVALID, item.QAINFO_STATE);
                sqllist.Add(sql);
            }
            db.Execute(sqllist);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    #endregion


    #region  写日志
    public static void WriteLogs(string LogMsg)
    {
        System.IO.StreamWriter writer = null;
        string sCurDate = System.DateTime.Now.ToString("yyyy-MM-dd");
        string sFile = sCurDate + "Logs.txt";
        string sFileDir = "C:\\LRSystem";
        sFile = sFileDir + "\\" + sFile;
        try
        {
            if (!System.IO.Directory.Exists(sFileDir))
                System.IO.Directory.CreateDirectory(sFileDir);

            if (System.IO.File.Exists(sFile))
                writer = new System.IO.StreamWriter(sFile, true, System.Text.Encoding.GetEncoding("gb2312"));
            else
                writer = new System.IO.StreamWriter(sFile, false, System.Text.Encoding.GetEncoding("gb2312"));
            string sDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
            writer.WriteLine(sDateTime + " " + LogMsg);
            writer.WriteLine("");
        }
        catch (System.IO.IOException e)
        {
            throw e;
        }
        finally
        {
            if (writer != null)
                writer.Close();
        }
    }

    #endregion

}

using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace LRSystemClient
{
    public class EventClient
    {
        #region 变量
        private DataSet ds = new DataSet();
        //private List<MyEventInfo> relationtypeList = new List<MyEventInfo>();
        private Stream strm = null;
        #endregion

        #region 事件定义之获取数据
        //public List<MyEventInfo> GetEventInfo()
        //{
        //    List<MyEventInfo> result = new List<MyEventInfo>();

        //    //SoapFormatter formatter = new SoapFormatter();
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    result = (List<MyEventInfo>)formatter.Deserialize(strm);


        //    return result;
        //}

        #endregion

        #region 事件定义之保存数据
        //public bool SaveEventType(string DBOperType, MyEventType item)
        //{
        //    bool result = true;

        //    return result;
        //}

        #endregion

        #region 事件卡片之保存数据
        //public bool SaveEventInfoCard(MyEventInfo item)
        //{
        //    bool result = true;

        //    return result;
        //}

        #endregion

        #region 事件卡片之获取句子数据
        public List<MySentenceInfo> GetSentenceInfoCard(string eventCode)
        {
            List<MySentenceInfo> result = new List<MySentenceInfo>();

            return result;
        }

        #endregion
    }
}

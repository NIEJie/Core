using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Core.PubClass;



namespace Core.Client.EnterClient
{
    public class EnterClient
    {
        #region 变量
        private ChangeType changeType = new ChangeType();
        private PubClientProxy pubClient = new PubClientProxy();
        //第一种手动引用的方式
        //private String className = @"LRSystemClient.QAWebService.QAWebServiceSoapClient";
        //第二种动态引用的方式
        private string url = @"http://localhost:3349/QAWebService.asmx";

        #endregion

        #region 获取数据

        #region 获取问题集
        public List<MyQAInfo> GetQAInfoList()
        {
            List<MyQAInfo> result = new List<MyQAInfo>();
            string[] parameters = new string[] { };
            result = pubClient.PubClientProxyClient<List<MyQAInfo>>(url, "GetQAInfoList", parameters);
            return result;
        }

        #endregion

        #region 获取句子
        public List<MySentenceInfo> GetSentenceInfoList(string eventCode)
        {
            List<MySentenceInfo> result = new List<MySentenceInfo>();

            return result;
        }

        #endregion

        #region 获取词汇
        public List<MyVocabularyInfo> GetVocabularyInfoList(string sentenceCode)
        {
            List<MyVocabularyInfo> result = new List<MyVocabularyInfo>();

            return result;
        }

        #endregion

        #region 获取属性
        public List<MyPropertyInfo> GetPropertyInfoList()
        {
            List<MyPropertyInfo> result = new List<MyPropertyInfo>();

            return result;
        }

        #endregion

        #region 获取对象属性
        public List<MyPropertyData> GetPropertyDataList(string objectID)
        {
            List<MyPropertyData> result = new List<MyPropertyData>();

            return result;
        }

        #endregion

        #region 获取关系
        public List<MyRelationInfo> GetRelationInfoList()
        {
            List<MyRelationInfo> result = new List<MyRelationInfo>();

            return result;
        }

        #endregion

        #region 获取对象关系
        public List<MyRelationData> GetRelationDataList(string objectID)
        {
            List<MyRelationData> result = new List<MyRelationData>();

            return result;
        }

        #endregion

        #endregion

        #region 保存数据

        #region 保存事件
        public bool SaveQAInfoList(List<MyQAInfo> myQAInfoList)
        {
            string list = changeType.changeTToStr(myQAInfoList);
            string[] parameters = new string[] { list };
            bool result = pubClient.PubClientProxyClient<bool>(url, "SaveQAInfoList", parameters);
            return result;
        }

        #endregion

        #region 保存句子
        public bool SaveSentenceInfo(MySentenceInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 保存词汇
        public bool SaveVocabularyInfo(MyVocabularyInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 保存属性
        public bool SavePropertyInfo(MyPropertyInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 保存对象属性
        public bool SavePropertyData(MyPropertyData item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 保存关系
        public bool SaveRelationInfo(MyRelationInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 保存对象关系
        public bool SaveRelationData(MyRelationData item)
        {
            bool result = true;

            return result;
        }

        #endregion
        #endregion
    }
}

using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSystemClient
{
    public class VocabularyClient
    {
        #region 变量
        private DataSet ds = new DataSet();
        #endregion

        #region 保存词汇数据
        public bool SaveVocabularyInfoCard(MyVocabularyInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 获取词汇数据
        public List<MyVocabularyInfo> GetVocabularyInfoCard(string VocabularyCode)
        {
            List<MyVocabularyInfo> result = new List<MyVocabularyInfo>();

            return result;
        }

        #endregion



        #region 保存独立词汇数据
        public bool SaveIndependentVocabularyInfoCard(MyVocabularyInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 获取独立词汇数据
        public List<MyVocabularyInfo> GetIndependentVocabularyInfoCard(string VocabularyCode)
        {
            List<MyVocabularyInfo> result = new List<MyVocabularyInfo>();

            return result;
        }

        #endregion
    }
}

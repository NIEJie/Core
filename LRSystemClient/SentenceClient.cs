using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSystemClient
{
    public class SentenceClient
    {
        #region 变量
        private DataSet ds = new DataSet();
        #endregion

        #region 句子之保存数据
        public bool SaveSentenceInfoCard(MySentenceInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 句子之获取词汇数据
        public List<MyVocabularyInfo> GetVocabularyInfoCard(string SentenceCode)
        {
            List<MyVocabularyInfo> result = new List<MyVocabularyInfo>();

            return result;
        }

        #endregion
    }
}

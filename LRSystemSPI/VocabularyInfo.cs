using System;
using System.Collections.Generic;
using System.Text;

namespace LRSystemSPI
{
    public class MyVocabularyInfo
    {
        private string _vocabularyinfo_id;
        private string _vocabularyinfo_code;
        private string _vocabularyinfo_name;
        private string _vocabularyinfo_sentenceinfoid;
        private string _vocabularyinfo_note;
        private string _vocabularyinfo_createtime;
        private string _vocabularyinfo_lastmodifiedtime;
        private string _vocabularyinfo_modificationtimes;
        private string _vocabularyinfo_ifinvalid;

        public string VOCABULARYINFO_ID
        {
            get { return _vocabularyinfo_id; }
            set { _vocabularyinfo_id = value; }
        }

        public string VOCABULARYINFO_CODE
        {
            get { return _vocabularyinfo_code; }
            set { _vocabularyinfo_code = value; }
        }

        public string VOCABULARYINFO_NAME
        {
            get { return _vocabularyinfo_name; }
            set { _vocabularyinfo_name = value; }
        }

        public string VOCABULARYINFO_SENTENCEINFOID
        {
            get { return _vocabularyinfo_sentenceinfoid; }
            set { _vocabularyinfo_sentenceinfoid = value; }
        }

        public string VOCABULARYINFO_NOTE
        {
            get { return _vocabularyinfo_note; }
            set { _vocabularyinfo_note = value; }
        }

        public string VOCABULARYINFO_CREATETIME
        {
            get { return _vocabularyinfo_createtime; }
            set { _vocabularyinfo_createtime = value; }
        }

        public string VOCABULARYINFO_LASTMODIFIEDTIME
        {
            get { return _vocabularyinfo_lastmodifiedtime; }
            set { _vocabularyinfo_lastmodifiedtime = value; }
        }

        public string VOCABULARYINFO_MODIFICATIONTIMES
        {
            get { return _vocabularyinfo_modificationtimes; }
            set { _vocabularyinfo_modificationtimes = value; }
        }

        public string VOCABULARYINFO_IFINVALID
        {
            get { return _vocabularyinfo_ifinvalid; }
            set { _vocabularyinfo_ifinvalid = value; }
        }

    }
}

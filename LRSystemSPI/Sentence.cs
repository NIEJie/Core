using System;
using System.Collections.Generic;
using System.Text;

namespace LRSystemSPI
{
    public class MySentenceInfo
    {
        private string _sentenceinfo_id;
        private string _sentenceinfo_code;
        private string _sentenceinfo_name;
        private string _sentenceinfo_eventinfoid;
        private string _sentenceinfo_note;
        private string _sentenceinfo_createtime;
        private string _sentenceinfo_lastmodifiedtime;
        private string _sentenceinfo_modificationtimes;
        private string _sentenceinfo_ifinvalid;

        public string SENTENCEINFO_ID
        {
            get { return _sentenceinfo_id; }
            set { _sentenceinfo_id = value; }
        }

        public string SENTENCEINFO_CODE
        {
            get { return _sentenceinfo_code; }
            set { _sentenceinfo_code = value; }
        }

        public string SENTENCEINFO_NAME
        {
            get { return _sentenceinfo_name; }
            set { _sentenceinfo_name = value; }
        }

        public string SENTENCEINFO_EVENTINFOID
        {
            get { return _sentenceinfo_eventinfoid; }
            set { _sentenceinfo_eventinfoid = value; }
        }

        public string SENTENCEINFO_NOTE
        {
            get { return _sentenceinfo_note; }
            set { _sentenceinfo_note = value; }
        }

        public string SENTENCEINFO_CREATETIME
        {
            get { return _sentenceinfo_createtime; }
            set { _sentenceinfo_createtime = value; }
        }

        public string SENTENCEINFO_LASTMODIFIEDTIME
        {
            get { return _sentenceinfo_lastmodifiedtime; }
            set { _sentenceinfo_lastmodifiedtime = value; }
        }

        public string SENTENCEINFO_MODIFICATIONTIMES
        {
            get { return _sentenceinfo_modificationtimes; }
            set { _sentenceinfo_modificationtimes = value; }
        }

        public string SENTENCEINFO_IFINVALID
        {
            get { return _sentenceinfo_ifinvalid; }
            set { _sentenceinfo_ifinvalid = value; }
        }

    }
}

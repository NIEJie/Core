using System;
using System.Collections.Generic;
using System.Text;

namespace LRSystemSPI
{
    //serializable使得类型可以被序列化
    [Serializable]
    public class MyQAInfo
    {
        private string _qainfo_id;
        private string _qainfo_code;
        private string _qainfo_parentid;
        private string _qainfo_question;
        private string _qainfo_answer;
        private string _qainfo_createtime;
        private string _qainfo_lastmodifiedtime;
        private int _qainfo_modificationtimes;
        private string _qainfo_ifinvalid;
        private string _qainfo_state;

        public string QAINFO_ID
        {
            get { return _qainfo_id; }
            set { _qainfo_id = value; }
        }


        public string QAINFO_CODE
        {
            get { return _qainfo_code; }
            set { _qainfo_code = value; }
        }

        public string QAINFO_PARENTID
        {
            get { return _qainfo_parentid; }
            set { _qainfo_parentid = value; }
        }

        public string QAINFO_QUESTION
        {
            get { return _qainfo_question; }
            set { _qainfo_question = value; }
        }

        public string QAINFO_ANSWER
        {
            get { return _qainfo_answer; }
            set { _qainfo_answer = value; }
        }

        public string QAINFO_CREATETIME
        {
            get { return _qainfo_createtime; }
            set { _qainfo_createtime = value; }
        }

        public string QAINFO_LASTMODIFIEDTIME
        {
            get { return _qainfo_lastmodifiedtime; }
            set { _qainfo_lastmodifiedtime = value; }
        }

        public int QAINFO_MODIFICATIONTIMES
        {
            get { return _qainfo_modificationtimes; }
            set { _qainfo_modificationtimes = value; }
        }

        public string QAINFO_IFINVALID
        {
            get { return _qainfo_ifinvalid; }
            set { _qainfo_ifinvalid = value; }
        }

        public string QAINFO_STATE
        {
            get { return _qainfo_state; }
            set { _qainfo_state = value; }
        }

    }

}

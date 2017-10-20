using System;
using System.Collections.Generic;
using System.Text;

namespace LRSystemSPI
{
    public class MyRelationInfo
    {
        private string _relationinfo_id;
        private string _relationinfo_code;
        private string _relationinfo_name;
        private string _relationinfo_parentid;
        private string _relationinfo_ifdetail;
        private int _relationinfo_grade;
        private string _relationinfo_note;
        private string _relationinfo_createtime;
        private string _relationinfo_lastmodifiedtime;
        private string _relationinfo_modificationtimes;
        private string _relationinfo_ifinvalid;
        private List<MyRelationInfo> _relationinfo_relationinfo;

        public string RELATIONINFO_ID
        {
            get { return _relationinfo_id; }
            set { _relationinfo_id = value; }
        }

        public string RELATIONINFO_CODE
        {
            get { return _relationinfo_code; }
            set { _relationinfo_code = value; }
        }

        public string RELATIONINFO_NAME
        {
            get { return _relationinfo_name; }
            set { _relationinfo_name = value; }
        }

        public string RELATIONINFO_PARENTID
        {
            get { return _relationinfo_parentid; }
            set { _relationinfo_parentid = value; }
        }
        public string RELATIONINFO_IFDETAIL
        {
            get { return _relationinfo_ifdetail; }
            set { _relationinfo_ifdetail = value; }
        }

        public int RELATIONINFO_GRADE
        {
            get { return _relationinfo_grade; }
            set { _relationinfo_grade = value; }
        }

        public string RELATIONINFO_NOTE
        {
            get { return _relationinfo_note; }
            set { _relationinfo_note = value; }
        }

        public string RELATIONINFO_CREATETIME
        {
            get { return _relationinfo_createtime; }
            set { _relationinfo_createtime = value; }
        }

        public string RELATIONINFO_LASTMODIFIEDTIME
        {
            get { return _relationinfo_lastmodifiedtime; }
            set { _relationinfo_lastmodifiedtime = value; }
        }

        public string RELATIONINFO_MODIFICATIONTIMES
        {
            get { return _relationinfo_modificationtimes; }
            set { _relationinfo_modificationtimes = value; }
        }
        public string RELATIONINFO_IFINVALID
        {
            get { return _relationinfo_ifinvalid; }
            set { _relationinfo_ifinvalid = value; }
        }

        public List<MyRelationInfo> RELATIONINFO_RELATIONINFO
        {
            get { return _relationinfo_relationinfo; }
            set { _relationinfo_relationinfo = value; }
        }

    }


    public class MyRelationData
    {
        private string _relationdata_id;
        private string _relationdata_relationid;//关系
        private string _relationdata_relationinfoid;
        private string _relationdata_relationname;
        private string _relationdata_code;
        private string _relationdata_name;
        private string _relationdata_lobjectid;//左属性
        private string _relationdata_robjectid;//右属性
        private string _relationdata_fpropertyname;
        private string _relationdata_fpropertyid;
        private string _relationdata_fpropertytypeid;
        private string _relationdata_spropertyname;
        private string _relationdata_spropertyid;
        private string _relationdata_spropertytypeid;
        private string _relationdata_note;
        private string _relationdata_createtime;
        private string _relationdata_lastmodifiedtime;
        private string _relationdata_modificationtimes;
        private string _relationdata_ifinvalid;

        public string RELATIONDATA_ID
        {
            get { return _relationdata_id; }
            set { _relationdata_id = value; }
        }

        public string RELATIONDATA_RELATIONNAME
        {
            get { return _relationdata_relationname; }
            set { _relationdata_relationname = value; }
        }
        public string RELATIONDATA_RELATIONID
        {
            get { return _relationdata_relationid; }
            set { _relationdata_relationid = value; }
        }

        public string RELATIONDATA_RELATIONINFOID
        {
            get { return _relationdata_relationinfoid; }
            set { _relationdata_relationinfoid = value; }
        }

        public string RELATIONDATA_CODE
        {
            get { return _relationdata_code; }
            set { _relationdata_code = value; }
        }

        public string RELATIONDATA_NAME
        {
            get { return _relationdata_name; }
            set { _relationdata_name = value; }
        }

        public string RELATIONDATA_LOBJECTID
        {
            get { return _relationdata_lobjectid; }
            set { _relationdata_lobjectid = value; }
        }

        public string RELATIONDATA_ROBJECTTYPEID
        {
            get { return _relationdata_robjectid; }
            set { _relationdata_robjectid = value; }
        }

        public string RELATIONDATA_FPROPERTYNAME
        {
            get { return _relationdata_fpropertyname; }
            set { _relationdata_fpropertyname = value; }
        }

        public string RELATIONDATA_FPROPERTYID
        {
            get { return _relationdata_fpropertyid; }
            set { _relationdata_fpropertyid = value; }
        }

        public string RELATIONDATA_FPROPERTYTYPEID
        {
            get { return _relationdata_fpropertytypeid; }
            set { _relationdata_fpropertytypeid = value; }
        }

        public string RELATIONDATA_SPROPERTYNAME
        {
            get { return _relationdata_spropertyname; }
            set { _relationdata_spropertyname = value; }
        }

        public string RELATIONDATA_SPROPERTYID
        {
            get { return _relationdata_spropertyid; }
            set { _relationdata_spropertyid = value; }
        }

        public string RELATIONDATA_SPROPERTYTYPEID
        {
            get { return _relationdata_spropertytypeid; }
            set { _relationdata_spropertytypeid = value; }
        }

        public string RELATIONDATA_NOTE
        {
            get { return _relationdata_note; }
            set { _relationdata_note = value; }
        }

        public string RELATIONDATA_CREATETIME
        {
            get { return _relationdata_createtime; }
            set { _relationdata_createtime = value; }
        }

        public string RELATIONDATA_LASTMODIFIEDTIME
        {
            get { return _relationdata_lastmodifiedtime; }
            set { _relationdata_lastmodifiedtime = value; }
        }

        public string RELATIONDATA_MODIFICATIONTIMES
        {
            get { return _relationdata_modificationtimes; }
            set { _relationdata_modificationtimes = value; }
        }

        public string RELATIONDATA_IFINVALID
        {
            get { return _relationdata_ifinvalid; }
            set { _relationdata_ifinvalid = value; }
        }

    }

}

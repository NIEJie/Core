using System;
using System.Collections.Generic;
using System.Text;

namespace LRSystemSPI
{
    public class MyPropertyInfo
    {
        private string _propertyinfo_id; 
        private string _propertyinfo_code;
        private string _propertyinfo_name;
        private string _propertyinfo_parentid;
        private string _propertyinfo_ifdetail; //是否有明细项
        private int _propertyinfo_grade;
        private string _propertyinfo_note;
        private string _propertyinfo_createtime;
        private string _propertyinfo_lastmodifiedtime;
        private string _propertyinfo_modificationtimes;
        private string _propertyinfo_ifinvalid;

        public string PROPERTYINFO_ID
        {
            get { return _propertyinfo_id; }
            set { _propertyinfo_id = value; }
        }

        public string PROPERTYINFO_CODE
        {
            get { return _propertyinfo_code; }
            set { _propertyinfo_code = value; }
        }

        public string PROPERTYINFO_NAME
        {
            get { return _propertyinfo_name; }
            set { _propertyinfo_name = value; }
        }

        public string PROPERTYINFO_PARENTID
        {
            get { return _propertyinfo_parentid; }
            set { _propertyinfo_parentid = value; }
        }
        public string PROPERTYINFO_IFDETAIL
        {
            get { return _propertyinfo_ifdetail; }
            set { _propertyinfo_ifdetail = value; }
        }

        public int PROPERTYINFO_GRADE
        {
            get { return _propertyinfo_grade; }
            set { _propertyinfo_grade = value; }
        }

        public string PROPERTYINFO_NOTE
        {
            get { return _propertyinfo_note; }
            set { _propertyinfo_note = value; }
        }

        public string PROPERTYINFO_CREATETIME
        {
            get { return _propertyinfo_createtime; }
            set { _propertyinfo_createtime = value; }
        }

        public string PROPERTYINFO_LASTMODIFIEDTIME
        {
            get { return _propertyinfo_lastmodifiedtime; }
            set { _propertyinfo_lastmodifiedtime = value; }
        }

        public string PROPERTYINFO_MODIFICATIONTIMES
        {
            get { return _propertyinfo_modificationtimes; }
            set { _propertyinfo_modificationtimes = value; }
        }
        public string PROPERTYINFO_IFINVALID
        {
            get { return _propertyinfo_ifinvalid; }
            set { _propertyinfo_ifinvalid = value; }
        }

    }


    public class MyPropertyData
    {
        private string _propertydata_id;
        private string _propertydata_infoid;
        private string _propertydata_typeid;
        private string _propertydata_code;
        private string _propertydata_name;
        private string _propertydata_objectid;
        private string _propertydata_objecttypeid;
        private string _propertydata_note;
        private string _propertydata_createtime;
        private string _propertydata_lastmodifiedtime;
        private string _propertydata_modificationtimes;
        private string _propertydata_ifinvalid;

        public string PROPERTYDATA_ID
        {
            get { return _propertydata_id; }
            set { _propertydata_id = value; }
        }
        public string PROPERTYDATA_INFOID
        {
            get { return _propertydata_infoid; }
            set { _propertydata_infoid = value; }
        }
        public string PROPERTYDATA_TYPEID
        {
            get { return _propertydata_typeid; }
            set { _propertydata_typeid = value; }
        }

        public string PROPERTYDATA_CODE
        {
            get { return _propertydata_code; }
            set { _propertydata_code = value; }
        }

        public string PROPERTYDATA_NAME
        {
            get { return _propertydata_name; }
            set { _propertydata_name = value; }
        }

        public string PROPERTYDATA_OBJECTID
        {
            get { return _propertydata_objectid; }
            set { _propertydata_objectid = value; }
        }

        public string PROPERTYDATA_OBJECTTYPEID
        {
            get { return _propertydata_objecttypeid; }
            set { _propertydata_objecttypeid = value; }
        }

        public string PROPERTYDATA_NOTE
        {
            get { return _propertydata_note; }
            set { _propertydata_note = value; }
        }

        public string PROPERTYDATA_CREATETIME
        {
            get { return _propertydata_createtime; }
            set { _propertydata_createtime = value; }
        }

        public string PROPERTYDATA_LASTMODIFIEDTIME
        {
            get { return _propertydata_lastmodifiedtime; }
            set { _propertydata_lastmodifiedtime = value; }
        }

        public string PROPERTYDATA_MODIFICATIONTIMES
        {
            get { return _propertydata_modificationtimes; }
            set { _propertydata_modificationtimes = value; }
        }

        public string PROPERTYDATA_IFINVALID
        {
            get { return _propertydata_ifinvalid; }
            set { _propertydata_ifinvalid = value; }
        }
    }
}

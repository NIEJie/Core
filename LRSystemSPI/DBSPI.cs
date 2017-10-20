using System;
using System.Collections.Generic;
using System.Text;

namespace LRSystemSPI
{
    public class DBSPI
    {
            #region 构造函数
            public DBSPI()
            {
            }
            #endregion

            #region 变量
            private string _version = string.Empty;
            private string _dbtype = string.Empty;
            private string _code = string.Empty;
            private string _source = string.Empty;
            private string _userid = string.Empty;
            private string _password = string.Empty;
            #endregion

            #region 属性
            public string Version
            {
                get
                {
                    return _version;
                }
                set
                {
                    _version = value;
                }
            }
            public string DBType
            {
                get
                {
                    return _dbtype;
                }
                set
                {
                    _dbtype = value;
                }
            }

            public string Code
            {
                get
                {
                    return _code;
                }
                set
                {
                    _code = value;
                }
            }
        public string Source
            {
                get
                {
                    return _source;
                }
                set
                {
                    _source = value;
                }
            }
            public string Userid
            {
                get
                {
                    return _userid;
                }
                set
                {
                    _userid = value;
                }
            }
            public string PassWord
            {
                get
                {
                    return _password;
                }
                set
                {
                    _password = value;
                }
            }
            #endregion
        }
    }

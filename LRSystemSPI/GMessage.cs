using System;
using System.Collections.Generic;
using System.Text;

namespace Genersoft.GS.InterFace.SPI
{
    [Serializable]
    public enum GMessageFlag
    {
        FAIL,
        SUCCESS
    }

    [Serializable]
    public class GMessage
    {
        #region 构造函数
        public GMessage()
        {

        }
        #endregion

        private GMessageFlag flag = GMessageFlag.SUCCESS;//成功与否的标志
        private string content = string.Empty;   //成功失败后的信息
        private string guid = string.Empty;      //传递guid

        /// <summary>
        /// 成功与否的标志,选择为：MessageFlag.SUCCESS/MessageFlag.FAIL
        /// </summary>
        public GMessageFlag Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }

        /// <summary>
        /// 成功失败后的信息,失败后包含失败信息
        /// </summary>
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        /// <summary>
        /// 唯一内码GUID
        /// </summary>
        public string GUID
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
            }
        }
        /// <summary>
        /// 重写ToString 按照xml格式输出
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "<DATA><MESSAGE><TR FLAG='" + flag + "' CONTENT='" + content + "' GUID='"+ guid +"'></TR></MESSAGE></DATA>";
        }
    }
}

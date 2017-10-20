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
        #region ���캯��
        public GMessage()
        {

        }
        #endregion

        private GMessageFlag flag = GMessageFlag.SUCCESS;//�ɹ����ı�־
        private string content = string.Empty;   //�ɹ�ʧ�ܺ����Ϣ
        private string guid = string.Empty;      //����guid

        /// <summary>
        /// �ɹ����ı�־,ѡ��Ϊ��MessageFlag.SUCCESS/MessageFlag.FAIL
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
        /// �ɹ�ʧ�ܺ����Ϣ,ʧ�ܺ����ʧ����Ϣ
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
        /// Ψһ����GUID
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
        /// ��дToString ����xml��ʽ���
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "<DATA><MESSAGE><TR FLAG='" + flag + "' CONTENT='" + content + "' GUID='"+ guid +"'></TR></MESSAGE></DATA>";
        }
    }
}

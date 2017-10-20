using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSystemClient
{
    public class PropertyClient
    {
        #region 变量
        private DataSet ds = new DataSet();
        //private List<MyPropertyType> propertytypeList = new List<MyPropertyType>();
        #endregion

        #region 属性树构建
        public List<MyPropertyInfo> GetPropertyInfoList()
        {
            List<MyPropertyInfo> result = new List<MyPropertyInfo>();

            return result;
        }

        #endregion

        #region 属性定义之保存数据
        //public bool SavePropertyType(string DBOperType, MyPropertyType item)
        //{
        //    bool result = true;

        //    return result;
        //}

        #endregion

        #region 属性卡片之保存数据
        public bool SavePropertyInfoCard(MyPropertyInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 通用属性卡片获取数据
        public MyPropertyData GetPropertyDataCard(string objectTypeID,string objectId,string typeId,string infoId)
        {
            MyPropertyData result = new MyPropertyData();

            return result;
        }
        #endregion

        #region 通用属性卡片保存数据
        public bool SavePropertyDataCard(string DBOperType, MyPropertyData propertyData)
        {
            bool result = true;

            return result;
        }
        #endregion

    }
}

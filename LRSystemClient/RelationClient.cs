using DevExpress.XtraCharts;
using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRSystemClient
{
    public class RelationClient
    {
        #region 变量
        private DataSet ds = new DataSet();
        //private List<MyRelationType> relationtypeList = new List<MyRelationType>();
        #endregion

        #region 关系定义之获取数据
        public List<MyRelationInfo> GetRelationInfoList()
        {
            List<MyRelationInfo> result = new List<MyRelationInfo>();

            return result;
        }

        #endregion

        #region 关系定义之保存数据
        //public bool SaveRelationType(string DBOperType, MyRelationType item)
        //{
        //    bool result = true;

        //    return result;
        //}

        #endregion

        #region 关系卡片之保存数据
        public bool SaveRelationInfoCard(MyRelationInfo item)
        {
            bool result = true;

            return result;
        }

        #endregion

        #region 关系信息之保存数据
        public bool SaveRelationComCard(List<MyRelationData> relationDataList)
        {
            bool result = true;

            return result;
        }

        #endregion

    }
}

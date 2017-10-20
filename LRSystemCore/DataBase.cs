using System;
using System.Collections.Generic;
using System.Text;
using Genersoft.GS.InterFace.SPI;
using System.Data.SqlClient;

using System.Data;
using System.IO;

using System.Reflection;
using LRSystemSPI;
using Oracle.ManagedDataAccess.Client;

namespace LRSystemCore
{
    public class DataBase
    {
        #region 构造函数
        public DataBase()
        {

        }
        #endregion

        #region 变量
        private string connString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.121.129)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));Persist Security Info=True;User ID=C##niejie;Password=aaaaaa;";
        OracleConnection con;
        private OracleTransaction tx_ora;
        private OracleCommand cmd_ora;
        private OracleDataAdapter myAdp_ora;
        #endregion
        #region 方法
        protected void Connection()
        {

            try
            {
                con = new OracleConnection(connString);
                con.Open();

            }
            catch (System.Exception err)
            {
                throw err;
            }
        }
        public void Execute(string pSql)
        {
            Connection();
            try
            {
                tx_ora = con.BeginTransaction();
                cmd_ora = new OracleCommand(pSql, con);
                cmd_ora.Transaction = tx_ora;
                cmd_ora.ExecuteNonQuery();
            }
            catch (System.Exception err)
            {
                tx_ora.Rollback();
                throw err;
            }
            finally
            {
                tx_ora.Commit();
                con.Close();
            }
        }

        public void Execute(List<string> pSqlList)
        {
            Connection();
            try
            {
                foreach (string pSql in pSqlList)
                {
                    tx_ora = con.BeginTransaction();
                    cmd_ora = new OracleCommand(pSql, con);
                    cmd_ora.Transaction = tx_ora;
                    cmd_ora.ExecuteNonQuery();
                }
            }
            catch (System.Exception err)
            {
                tx_ora.Rollback();
                throw err;
            }
            finally
            {
                tx_ora.Commit();
                con.Close();
            }
        }
        public void ExecuteNonQuery(string pSql)
        {
            Connection();
            try
            {
                cmd_ora = new OracleCommand(pSql, con);
                cmd_ora.ExecuteNonQuery();
            }
            catch (System.Exception err)
            {

                throw err;
            }
            finally
            {

                con.Close();
            }
            
        }
        public void Execute(string[] pSqlArray)
        {

            Connection();
            try
            {
                tx_ora = con.BeginTransaction();
                cmd_ora = new OracleCommand();
                cmd_ora.Connection = con;
                cmd_ora.Transaction = tx_ora;

                foreach (string pSql in pSqlArray)
                {

                    cmd_ora.CommandText = pSql;
                    cmd_ora.ExecuteNonQuery();

                }

            }
            catch (System.Exception err)
            {

                tx_ora.Rollback();
                throw err;
            }
            finally
            {

                tx_ora.Commit();
                con.Close();
            }
        }
        public DataSet ExecuteDataSet(string pSql)
        {
            try
            {
                this.Connection();
            }
            catch (Exception e)
            {
                throw e;
            }
            DataSet ds = new DataSet();
            try
            {

                myAdp_ora = new OracleDataAdapter(pSql, con);
                myAdp_ora.Fill(ds);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }


        #endregion

        #region 记录日志
        public static void WriteTextFile(string logMessage)
        {
            if (logMessage != null && logMessage.Length > 0)
            {
                System.IO.StreamWriter w = System.IO.File.AppendText("C: \\SQL.txt");
                w.WriteLine("记录时间:{0}", DateTime.Now.ToString());
                w.WriteLine("信息文本:{0}", logMessage);
                w.WriteLine("---------------------------------------------------------------------------------------------");
                w.Flush();
                w.Close();
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services
{
    class WorkOrderDao
    {

        public DataTable getWorkOrderDao_Date(string date)
        {
            DataTable dt = FetchTableFromDatabase(date, "Date_Of_Intervention");
            return dt;
        }

        public DataTable getWorkOrderDao_Regd_ID(string Regd_No)
        {
            DataTable dt = FetchTableFromDatabase(Regd_No, "Regd_No");
            return dt;
        }


        private DataTable FetchTableFromDatabase(string condition,string column)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("Data Source = workorderassignment.cdycr1nr2pjg.us-east-2.rds.amazonaws.com,1433; Initial Catalog = WorkDetails; User ID = admin; Password = 12345678; Persist Security Info = False; Packet Size = 4096; Connection Timeout = 360");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from WorkOrder where " + column + " = " + "'"+ condition + "'", con);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public  void CreateWorkOrder(string Reference_Id, string Place, DateTime DOI,string Registration_No)
        {
            SqlConnection con = new SqlConnection("Data Source = workorderassignment.cdycr1nr2pjg.us-east-2.rds.amazonaws.com,1433; Initial Catalog = WorkDetails; User ID = admin; Password = 12345678; Persist Security Info = False; Packet Size = 4096; Connection Timeout = 360");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Technician values ('" + Reference_Id + "','" + Place + "','" + DOI +
                "','" + Registration_No + "')", con);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

    }
}


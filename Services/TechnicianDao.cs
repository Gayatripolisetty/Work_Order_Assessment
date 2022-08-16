using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services
{
    class TechnicianDao
    {
        public void Technician(string firstName, string lastName, string activeYN, string regd_No)
        {
            SqlConnection con = new SqlConnection("Data Source = workorderassignment.cdycr1nr2pjg.us-east-2.rds.amazonaws.com,1433; Initial Catalog = WorkDetails; User ID = admin; Password = 12345678; Persist Security Info = False; Packet Size = 4096; Connection Timeout = 360");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Technician values ('" + firstName + "','" + lastName + "','" + activeYN +
                "','" + regd_No + "')", con);
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
        public void AssignWorkToTechnician(string Reference_ID, string Registration_ID)
        {
            SqlCommand cmd;
            SqlConnection con = new SqlConnection("Data Source = workorderassignment.cdycr1nr2pjg.us-east-2.rds.amazonaws.com,1433; Initial Catalog = WorkDetails; User ID = admin; Password = 12345678; Persist Security Info = False; Packet Size = 4096; Connection Timeout = 360");
            con.Open();
            using (cmd = new SqlCommand("DBP_Assign_Technician", con))
            {
                cmd.Parameters.AddWithValue("@Reference_ID", Reference_ID);
                cmd.Parameters.AddWithValue("@Registration_ID", Registration_ID);
            }
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

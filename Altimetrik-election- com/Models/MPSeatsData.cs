using Microsoft.Data.SqlClient;
using Mono.TextTemplating;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Altimetrik_election__com.Models
{
    public class MPSeatsData
    {
        public Dataconnection conn = new Dataconnection();

        public List<SateModel> ElectionRegistrationuserstate()
        {
            DataTable dt = new DataTable();
            int i = 0;
            List<SateModel> lst;
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("statelist", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    
                    dt.Load(dataReader);
                    
                    con.Close();
                }
               
            }
            List<SateModel> emp = new List<SateModel>();
            emp = (from DataRow row in dt.Rows

                   select new SateModel
                   {
                       Stateid =Convert.ToInt16( row["Stateid"].ToString()),
                       StateName = row["StateName"].ToString()

                   }).ToList();
            return emp;
        }
        public List<MPSeatsModel> ElectionRegistrationuserMPList()
        {
            DataTable dt = new DataTable();
            int i = 0;
            List<MPSeatsModel> lst;
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("MpSeatsList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    con.Close();
                }

            }
            List<MPSeatsModel> emp = new List<MPSeatsModel>();

            foreach (DataRow row in dt.Rows)
            {
                MPSeatsModel employee = new MPSeatsModel();
                employee.Stateid = Convert.ToInt32(row["stateid"]);
                if(employee.Stateid == 1)
                {
                    employee.StateName = "Tamil Nadu";
                }
                else if (employee.Stateid == 2)
                {
                    employee.StateName = "Kerala";
                }
                employee.Cityid = Convert.ToInt32(row["cityid"]);
                if (employee.Cityid == 1)
                {
                    employee.CityName = "Chennai";
                }
                else if (employee.Cityid == 2)
                {
                    employee.CityName = "Madurai";
                }
                employee.seats = row["seats"].ToString();
                employee.MpSeatsid = Convert.ToInt32(row["MpSeatsid"].ToString());
                emp.Add(employee);
            }
         
            return emp;
        }

     
        public string MpSeatInserts(MPSeatsModel MPSeatsModels)
        {

            int i = 0;

            // string conn = "Data Source=DESKTOP-NNTVB6Q\\MSSQLSERVER01;Initial Catalog=cuserorder;Trusted_Connection=True;;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("MpSeatInsert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MpSeatsid", SqlDbType.Int).Value = MPSeatsModels.MpSeatsid;
                    cmd.Parameters.Add("@Stateid", SqlDbType.Int).Value = MPSeatsModels.Stateid;
                    cmd.Parameters.Add("@cityid", SqlDbType.Int).Value = MPSeatsModels.Cityid;
                    cmd.Parameters.Add("@seats", SqlDbType.VarChar).Value = MPSeatsModels.seats;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "I";
                    cmd.Parameters.Add("@Outputs", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @NewId
                    string Outputs = cmd.Parameters["@Outputs"].Value.ToString();
                    if (Outputs == "")
                    {
                        return "";
                    }
                    else
                        return Outputs;
                    con.Close();
                }
               

            }
        }
        public MPSeatsModel ElectionRegistrationuserMPfind( int id)
        {
            DataTable dt = new DataTable();
            MPSeatsModel emp = new MPSeatsModel();
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("Mpsetfind", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                 



                    con.Open();
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                    con.Close();
                }

            }
           

            foreach (DataRow row in dt.Rows)
            {
                MPSeatsModel employee = new MPSeatsModel();
                employee.Stateid = Convert.ToInt32(row["stateid"]);
                if (employee.Stateid == 1)
                {
                    employee.StateName = "Tamil Nadu";
                }
                else if (employee.Stateid == 2)
                {
                    employee.StateName = "Kerala";
                }
                employee.Cityid = Convert.ToInt32(row["cityid"]);
                if (employee.Cityid == 1)
                {
                    employee.CityName = "Chennai";
                }
                else if (employee.Cityid == 2)
                {
                    employee.CityName = "Madurai";
                }
                employee.MpSeatsid = Convert.ToInt32(row["MpSeatsid"]);
                employee.seats = row["seats"].ToString();
                emp = employee;
            }

            return emp;
        }
        public string MpSeatUpdate(MPSeatsModel MPSeatsModels)
        {

            int i = 0;

            // string conn = "Data Source=DESKTOP-NNTVB6Q\\MSSQLSERVER01;Initial Catalog=cuserorder;Trusted_Connection=True;;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("MpSeatInsert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MpSeatsid", SqlDbType.Int).Value = MPSeatsModels.MpSeatsid;
                    cmd.Parameters.Add("@Stateid", SqlDbType.Int).Value = MPSeatsModels.Stateid;
                    cmd.Parameters.Add("@cityid", SqlDbType.Int).Value = MPSeatsModels.Cityid;
                    cmd.Parameters.Add("@seats", SqlDbType.VarChar).Value = MPSeatsModels.seats;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "U";
                    cmd.Parameters.Add("@Outputs", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    // read output value from @NewId
                    string Outputs = cmd.Parameters["@Outputs"].Value.ToString();
                    if (Outputs == "")
                    {
                        return "";
                    }
                    else
                        return Outputs;
                    con.Close();
                }


            }
        }
    }
}

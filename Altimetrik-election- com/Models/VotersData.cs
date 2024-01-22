using Microsoft.Data.SqlClient;
using System.Data;

namespace Altimetrik_election__com.Models
{
    public class VotersData
    {
        public Dataconnection conn = new Dataconnection();
        public List<VotersModel> VotersList()
        {
            DataTable dt = new DataTable();
            int i = 0;
            List<VotersModel> lst;
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("VotersList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    con.Close();
                }

            }
            List<VotersModel> emp = new List<VotersModel>();

            foreach (DataRow row in dt.Rows)
            {
                VotersModel employee = new VotersModel();
                employee.Voterid = Convert.ToInt32(row["Voterid"]);
                employee.VoterName = row["VoterName"].ToString();
                employee.status = row["status"].ToString();
                employee.voterAddress = row["voterAddress"].ToString();
                employee.Photo = row["Photo"].ToString();
                employee.stateid = Convert.ToInt32(row["stateid"]);
                if (employee.stateid == 1)
                {
                    employee.StateName = "Tamil Nadu";
                }
                else if (employee.stateid == 2)
                {
                    employee.StateName = "Kerala";
                }
                employee.cityid = Convert.ToInt32(row["cityid"]);
                if (employee.cityid == 1)
                {
                    employee.CityName = "Chennai";
                }
                else if (employee.cityid == 2)
                {
                    employee.CityName = "Madurai";
                }
               
                emp.Add(employee);
            }

            return emp;
        }


        public string VotersInserts(VotersModel MPSeatsModels)
        {

            int i = 0;

            // string conn = "Data Source=DESKTOP-NNTVB6Q\\MSSQLSERVER01;Initial Catalog=cuserorder;Trusted_Connection=True;;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("VotersInserts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@VoterName", SqlDbType.VarChar).Value = MPSeatsModels.VoterName;
                    cmd.Parameters.Add("@voterAddress", SqlDbType.VarChar).Value = MPSeatsModels.voterAddress;
                    cmd.Parameters.Add("@photo", SqlDbType.VarChar).Value = MPSeatsModels.Photo;
                    cmd.Parameters.Add("@cityid", SqlDbType.Int).Value = MPSeatsModels.Voterid;
                    cmd.Parameters.Add("@stateid", SqlDbType.Int).Value = MPSeatsModels.stateid;
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
    }
}

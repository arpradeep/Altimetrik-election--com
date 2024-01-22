using Microsoft.Data.SqlClient;
using System.Data;

namespace Altimetrik_election__com.Models
{
    public class Votingsystemdata
    {
        public Dataconnection conn = new Dataconnection();
        public List<VotingsystemModel> VotingsystempList()
        {
            DataTable dt = new DataTable();
            int i = 0;
            List<VotersModel> lst;
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("Votingsystemprd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    con.Close();
                }

            }
            List<VotingsystemModel> emp = new List<VotingsystemModel>();

            foreach (DataRow row in dt.Rows)
            {
                VotingsystemModel employee = new VotingsystemModel();
                employee.Votingsystemid = Convert.ToInt32(row["Votingsystemid"]);
                employee.partyid = Convert.ToInt32(row["partyid"]);
                employee.voiterid = Convert.ToInt32(row["voiterid"].ToString());
                employee.voterdate =Convert.ToDateTime( row["voterdate"].ToString());
              
                employee.stateid = Convert.ToInt32(row["stateid"]);
                if (employee.stateid == 1)
                {
                    employee.stateName = "Tamil Nadu";
                }
                else if (employee.stateid == 2)
                {
                    employee.stateName = "Kerala";
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


        public string VotingsystemInserts(VotingsystemModel VotingsystemModels)
        {

            int i = 0;

            // string conn = "Data Source=DESKTOP-NNTVB6Q\\MSSQLSERVER01;Initial Catalog=cuserorder;Trusted_Connection=True;;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("VotingsystemInserts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Votingsystemid", SqlDbType.Int).Value = VotingsystemModels.Votingsystemid;
                    cmd.Parameters.Add("@partyid", SqlDbType.Int).Value = VotingsystemModels.partyid;
                    cmd.Parameters.Add("@voiterid", SqlDbType.Int).Value = VotingsystemModels.voiterid;
                    cmd.Parameters.Add("@voterdate", SqlDbType.DateTime).Value = VotingsystemModels.voterdate;
                    
                    cmd.Parameters.Add("@cityid", SqlDbType.Int).Value = VotingsystemModels.cityid;
                    cmd.Parameters.Add("@stateid", SqlDbType.Int).Value = VotingsystemModels.stateid;
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

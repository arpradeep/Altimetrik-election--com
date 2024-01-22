using Microsoft.Data.SqlClient;
using System.Data;

namespace Altimetrik_election__com.Models
{
    public class PartyNameData
    {
        public Dataconnection conn = new Dataconnection();
        public List<PartyNameModel> ElectionpartyList()
        {
            DataTable dt = new DataTable();
            int i = 0;
            List<PartyNameModel> lst;
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("Electionpartylist", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);

                    con.Close();
                }

            }
            List<PartyNameModel> emp = new List<PartyNameModel>();

            foreach (DataRow row in dt.Rows)
            {
                PartyNameModel employee = new PartyNameModel();
                employee.Epartyid = Convert.ToInt32(row["Epartyid"]);
                employee.partyname = row["partyname"].ToString();
                employee.Symbol = row["Symbol"].ToString();
                employee.yearofelection = Convert.ToDateTime(row["yearofelection"].ToString());

                emp.Add(employee);
            }

            return emp;
        }
        public string ElectionpartyInserts(PartyNameModel PartyNameModel)
        {

            int i = 0;

            // string conn = "Data Source=DESKTOP-NNTVB6Q\\MSSQLSERVER01;Initial Catalog=cuserorder;Trusted_Connection=True;;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("Electionpartyprd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Epartyid", SqlDbType.Int).Value = PartyNameModel.Epartyid;
                    cmd.Parameters.Add("@partyname", SqlDbType.VarChar).Value = PartyNameModel.partyname;
                    cmd.Parameters.Add("@Symbol", SqlDbType.VarChar).Value = PartyNameModel.Symbol;
                    cmd.Parameters.Add("@yearofelection", SqlDbType.DateTime).Value = PartyNameModel.@yearofelection;
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


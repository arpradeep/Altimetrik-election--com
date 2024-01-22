
using Altimetrik_election__com.Models;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Security.Permissions;
namespace Altimetrik_election__com.Models
{



    public class ElectionUsersData
    {

        public Dataconnection conn = new Dataconnection();

        public string ElectionRegistrationuser(ElectionUsersModel ElectionUsersModels)
        {

            int i = 0;

            // string conn = "Data Source=DESKTOP-NNTVB6Q\\MSSQLSERVER01;Initial Catalog=cuserorder;Trusted_Connection=True;;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("ElectionRegistrationuser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = ElectionUsersModels.username;
                    cmd.Parameters.Add("@passwords", SqlDbType.VarChar).Value = ElectionUsersModels.Epassword;
                    cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = ElectionUsersModels.Status;
                    cmd.Parameters.Add("@Euserid", SqlDbType.Int).Value = ElectionUsersModels.Euserid;
                    cmd.Parameters.Add("@Outputs", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

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
        public string ElectionRegistrationuserLogin(ElectionUsersModel ElectionUsersModels)
        {

            int i = 0;

            // string conn = "Data Source=DESKTOP-NNTVB6Q\\MSSQLSERVER01;Initial Catalog=cuserorder;Trusted_Connection=True;;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            using (SqlConnection con = new SqlConnection(conn.Connecctions()))
            {
                using (SqlCommand cmd = new SqlCommand("ElectionRegistrationlogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = ElectionUsersModels.username;
                    cmd.Parameters.Add("@passwords", SqlDbType.VarChar).Value = ElectionUsersModels.Epassword;
                    
                  

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            i = Convert.ToInt32(reader["id"]);
                        }
                    }
                    con.Close();
                }
                if (i == 1)
                {
                    return "Valid";
                }
                else
                {
                    return "Invalid";
                }

            }
        }
        public string EncryptString(string inputString, byte[] key, byte[] iv)
        {
            byte[] encryptedData;

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                ICryptoTransform encryptor = des.CreateEncryptor();

                byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
                encryptedData = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            return Convert.ToBase64String(encryptedData);
        }

        public string DecryptString(string inputString, byte[] key, byte[] iv)
        {
            byte[] decryptedData;

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                ICryptoTransform decryptor = des.CreateDecryptor();

                byte[] inputBytes = Convert.FromBase64String(inputString);
                decryptedData = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            return Encoding.UTF8.GetString(decryptedData);
        }

    }

}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournaManagementModels;

namespace TournaManagementData
{
    public class SqlDbData
    {
        static string connectionString
        = "Data Source =ENZO\\SQLEXPRESS; Initial Catalog = Enzotourna; Integrated Security = True;";

        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public static void Connect()
        {
            sqlConnection.Open();
        }

        public static List<User> GetUsers()
        {
            string selectStatement = "SELECT ign, mlbbid FROM users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                string ign = reader["ign"].ToString();
                string mlbbid = reader["mlbbid"].ToString();

                User readUser = new User();
                readUser.ign = ign;
                readUser.mlbbid = mlbbid;

                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public static int AddUser(string ign, string mlbbid)
        {
            int success;

            string insertStatement = "INSERT INTO users VALUES (@ign, @mlbbid)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@ign", ign);
            insertCommand.Parameters.AddWithValue("@mlbbid", mlbbid);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public static void UpdateUser(string ign, string mlbbid)
        {
            var updateStatment = $"UPDATE users SET mlbbid = @mlbbid WHERE ign = @ign";
            SqlCommand updateCommand = new SqlCommand(updateStatment, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@ign", ign);
            updateCommand.Parameters.AddWithValue("@mlbbid", mlbbid);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public static void DeleteUser(string ign)
        {
            string deleteStatement = $"DELETE FROM users WHERE ign = @ign";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement , sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@ign", ign);

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

        }

    }
}

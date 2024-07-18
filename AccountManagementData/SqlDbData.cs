using System.Collections.Generic;
using System.Data.SqlClient;
using TournaManagementModels;

namespace TournaManagementData
{
    public class SqlDbData
    {
        static string connectionString
        = "Server = tcp:20.205.138.211,1433; Database = Enzotourna; User Id = sa; Password = bsitenzo2!";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT ign, mlbbid, status FROM users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                string ign = reader["ign"].ToString();
                string mlbbid = reader["mlbbid"].ToString();
                string status = reader["status"].ToString();

                User readUser = new User();
                readUser.ign = ign;
                readUser.mlbbid = mlbbid;
                readUser.status = status;

                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string ign, string mlbbid, string status)
        {
            int success;

            string insertStatement = "INSERT INTO users VALUES (@ign, @mlbbid, @status)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@ign", ign);
            insertCommand.Parameters.AddWithValue("@mlbbid", mlbbid);
            insertCommand.Parameters.AddWithValue("@status", status);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public int UpdateUser(string ign, string mlbbid, string status)
        {
            int success;

            string updateStatement = $"UPDATE users SET mlbbid = @mlbbid WHERE ign = @ign";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@mlbbid", mlbbid);
            updateCommand.Parameters.AddWithValue("@ign", ign);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public int DeleteUser(string ign)
        {
            int success;

            string deleteStatement = $"DELETE FROM users WHERE ign = @ign";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@ign", ign);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}

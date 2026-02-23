using MySql.Data.MySqlClient;

public class DatabaseHelper
{
    private readonly string connectionString = "server=localhost;database=SafeVault;user=root;password=securePass;";

    public void InsertUser(string username, string email)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";
            
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

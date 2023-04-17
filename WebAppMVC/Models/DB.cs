using Npgsql;

namespace WebAppMVC.Models
{
    public class DB
    {
        public string SqlConnection { get; set; }
        public string ExceptionText { get; set; }
        public bool Exception { get; set; }

        public DB(string sqlConnection)
        {
            SqlConnection = sqlConnection;
            Exception = false;
        }

        public async Task<bool> SaveJson(StudentInfo studentInfo)
        {
            if(studentInfo==null)
            {
                Exception = true;
                ExceptionText = "Json is empty!";
                return false;
            }
            

            try
            {
                // PostgeSQL-style connection string
                // Making connection with Npgsql provider
                NpgsqlConnection Npgsqlconnection = new NpgsqlConnection(SqlConnection);
                Npgsqlconnection.Open();

                string sql = String.Format("INSERT INTO new_table (studentname, math, english, chemistry, physics) VALUES " +
                    "('{0}','{1}','{2}','{3}','{4}');", studentInfo.Name, studentInfo.Math, 
                    studentInfo.English, studentInfo.Chemistry, studentInfo.Physics);

                NpgsqlCommand command = new NpgsqlCommand(sql, Npgsqlconnection);
                command.Prepare();
                await command.ExecuteNonQueryAsync();
                Npgsqlconnection.Close();
            }
            catch (NpgsqlException ex)
            {
                Exception = true;
                ExceptionText = ex.ToString();
            }

            return true;
        }
    }
}

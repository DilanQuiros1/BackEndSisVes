using System.Data;
using System.Data.Common;
using BackEndSisVes.BackEndSisVesEntidades.DirectionsEntidades;
using Microsoft.Data.SqlClient;

namespace BackEndSisVes.BackEndSisVesBA
{
    public class DataContext: IDisposable
    {

        private readonly SqlConnection _connection;

        public DataContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open(); // Open once and reuse
        }

        public SqlConnection GetConnection()
        {
            return _connection; // Return the same connection
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }



        public bool SetUserSession(int usuarioId)
        {
            try
            {
                string sessionQuery = "EXEC sp_set_session_context @key = 'UsuarioID', @value = @UsuarioID";
                using (SqlCommand command = new SqlCommand(sessionQuery, _connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", usuarioId);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting user session: {ex.Message}");
                return false;
            }
        }


        public string GetUserSession(string query)
        {
            //string sessionQuery = "EXEC sp_set_session_context @key = 'UsuarioID', @value = @UsuarioID;";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : "Not Found";
                }
            
        }

        public DataTable ExecuteQueryViews(string query)
        {
           
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                  
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        return result;
                    }
                }
            
        }

        public int ExecuteNonQuerySPs(string storedProcedure, Dictionary<string, object> parameters = null)
        {
           
                using (SqlCommand command = new SqlCommand(storedProcedure, _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                   
                    return command.ExecuteNonQuery(); // Returns the number of affected rows
                }
            
        }


        public DataTable GetUserLogin(string query, Dictionary<string, object> parameters = null)
        {
            
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                   
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        return result;
                    }
                   
                }
                
            
        }

       




    }
}

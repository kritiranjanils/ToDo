using System.Data.SqlClient;
using Project_WebAPI_1.Models;

namespace Project_WebAPI_1.Services;

public class ToDoService
{
    private readonly string _connectionString;
    
    public ToDoService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    
    public List<Tasks> GetAllTasks()
    {
        var tasks = new List<Tasks>();

        using (var conn = new SqlConnection(_connectionString))
        {
            var query = new SqlCommand("select * from Task");
            conn.Open();

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    tasks.Add(new Tasks
                    {
                        TaskId = reader.GetInt32(0),
                        TaskName = reader.GetString(1),
                        IsCompleted = reader.GetBoolean(2),
                    });
                }
            }

            conn.Close();
            return tasks;
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Assignment4.Core;
using Microsoft.Extensions.Configuration;

namespace Assignment4.Entities
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SqlConnection _connection;
        public TaskRepository()
        {
            var configuration = LoadConfiguration();
            var connectionString = configuration.GetConnectionString("KanBan");
            _connection = new SqlConnection(connectionString);

        }

        public IReadOnlyCollection<TaskDTO> All(){
            return null;
        }

        public int Create(TaskDTO task){
            var cmdText = @"INSERT Task (Title, AssignedTo, Description, State, Tags)
                            VALUES (@Title, @AssignedTo, @Description, @State, @Tags);
                            SELECT SCOPE_IDENTITY()";

            using var command = new SqlCommand(cmdText, _connection);

            command.Parameters.AddWithValue("@Title", task.Title);
            command.Parameters.AddWithValue("@AssignedTo", task.AssignedToId);
            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@State", task.State);
            command.Parameters.AddWithValue("@Tags", task.Tags);

            OpenConnection();

            var id = command.ExecuteScalar();

            CloseConnection();

            return (int)id;
        }

        public void Delete(int taskId){
            
        }

        public TaskDetailsDTO FindById(int id){
            return null;
        }

        public void Update(TaskDTO task){

        }

        public void Dispose(){
            
        }

        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<TaskRepository>();

            return builder.Build();
        }
    }
}

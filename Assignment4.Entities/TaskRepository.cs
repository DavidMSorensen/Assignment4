using System;
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

        // Skal kigges på
        public (Response Response, int TaskId) Create(TaskCreateDTO task){
            var cmdText = @"INSERT Task (Title, AssignedTo, Description, State, Tags)
                            VALUES (@Title, @AssignedTo, @Description, @State, @Tags);
                            SELECT SCOPE_IDENTITY()";

            using var command = new SqlCommand(cmdText, _connection);

            command.Parameters.AddWithValue("@Title", task.Title);
            command.Parameters.AddWithValue("@AssignedTo", task.AssignedToId);
            command.Parameters.AddWithValue("@Description", task.Description);
            // command.Parameters.AddWithValue("@State", task.State);
            command.Parameters.AddWithValue("@Tags", task.Tags);

            OpenConnection();

            var id = command.ExecuteScalar();

            CloseConnection();

            return (Response.Created, (int)id);
        }

        public IReadOnlyCollection<TaskDTO> ReadAll(){
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllRemoved(){
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByTag(string tag){
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByUser(int userId){
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByState(State state){
            throw new NotImplementedException();
        }

        public TaskDetailsDTO Read(int taskId){
            throw new NotImplementedException();
        }

        public Response Update(TaskUpdateDTO task){
            throw new NotImplementedException();
        }

        public Response Delete(int taskId){
            throw new NotImplementedException();
        }

        // Private methods
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

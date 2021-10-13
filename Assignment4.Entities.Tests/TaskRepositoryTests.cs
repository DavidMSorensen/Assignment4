using System;
using Xunit;
using Assignment4.Core;
using Assignment4.Entities;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Assignment4.Entities.Tests
{
    public class TaskRepositoryTests
    {
        private readonly IKanbanContext _context;
        private readonly TagRepository _repo;

        public TaskRepositoryTests()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<KanbanContext>();
            builder.UseSqlite(connection);
            var context = new KanbanContext(builder.Options);
            context.Database.EnsureCreated();
            context.Tasks.Add(new Task { Title = "Implement funny memes" });
            context.SaveChanges();

            _context = context;
            _repo = new TagRepository(_context);
        }

        [Fact]
        public void Create()
        {
           //Arrange
            _repo.Create(new TaskDTO({}));
           
           //Act
           
           
           //Assert
           
        }
    }
}

using System;
using Assignment4.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace Assignment4.Entities.Tests
{
    public class TagRepositoryTests : IDisposable
    {


        private readonly KanbanContext _context;
        private readonly TagRepository _repo;

        public TagRepositoryTests()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<KanbanContext>();
            builder.UseSqlite(connection);
            var context = new KanbanContext(builder.Options);
            context.Database.EnsureCreated();
            context.Tags.Add(new Tag { Name = "Active" });
            context.SaveChanges();

            _context = context;
            _repo = new TagRepository(_context);
        }

        [Fact]
        public void Create_given_Tag_returns_tag_with_Id()
        {
            var tag = new TagCreateDTO {Name = "TagzzName"};
            var tag2 = new TagCreateDTO {Name = "TagzzNamodeyo"};

            var created = _repo.Create(tag);
            var created2 = _repo.Create(tag2);

            Assert.Equal(Response.Created, created.Response);
            Assert.Equal(2, created.TagId);
            Assert.Equal(Response.Created, created2.Response);
            Assert.Equal(3, created2.TagId);
        }

        [Fact]
        public void Read_given_non_existing_id_returns_null()
        {
            var tag = _repo.Read(42);

            Assert.Null(tag);
        }

        [Fact]
        public void Read_given_existing_id_returns_tag()
        {
            var tag = _repo.Read(1);

            Assert.Equal(new TagDTO(1, "Active"), tag);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        
    }
}
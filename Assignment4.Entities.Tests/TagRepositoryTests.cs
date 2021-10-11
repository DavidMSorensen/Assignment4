using System;
using Assignment4.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace Assignment4.Entities.Tests
{
    public class TagRepositoryTests : IDisposable
    {


        private readonly IKanbanContext _context;
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
            var tag = new TagCreateDTO("TagzzName");
            var tag2 = new TagCreateDTO("TagzzNamodeyo");

            var created = _repo.Create(tag);
            var created2 = _repo.Create(tag2);

            Assert.Equal(new TagDTO(0, "TagzzName"), created);
            Assert.Equal(new TagDTO(0, "TagzzNamodeyo"), created2);
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
            var tag = _repo.Read(0);

            Assert.Equal(new TagDTO(0, "Active"), tag);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        
    }
}
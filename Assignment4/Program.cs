using System;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Assignment4.Entities;

namespace Assignment4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configuration = LoadConfiguration();
            var connectionString = configuration.GetConnectionString("KanBan");

            var optionsBuilder = new DbContextOptionsBuilder<KanbanContext>().UseSqlServer(connectionString);
            using var context = new KanbanContext(optionsBuilder.Options);

            var chars = from c in context.Users
                        where c.Name.Contains("a")
                        select new
                        {
                            c.Id,
                            c.Email
                        };

            foreach (var c in chars)
            {
                Console.WriteLine(c);
            }
        }

        static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>();

            return builder.Build();
        }
    }
}


using Microsoft.EntityFrameworkCore;   
using MySql.EntityFrameworkCore.Extensions;
using win1_api.Models;
  
namespace win1_api.DBContexts  
{  
    public class MyDBContext : DbContext  
    {   
        public DbSet<Users> Users { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string mySqlConnectionStr = "server=localhost;user=dotnet_user;database=dotnet;password=pass";
            optionBuilder.UseMySQL(mySqlConnectionStr);
        }
    }  
}  
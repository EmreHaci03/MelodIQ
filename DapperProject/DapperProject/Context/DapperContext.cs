using Microsoft.Data.SqlClient; 
using System.Data; 

namespace DapperProject.Context
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;  //.NET'in appsettings.json'ı okuyan yapısı.
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("connectionkey");
            Console.WriteLine("CONNECTION: " + _connectionString);
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);  //CreateConnection çağrılınca yeni bir SqlConnection döndür
    }
}
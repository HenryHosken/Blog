using Blog.Models;
using Blog.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost, 1401;Database=Blog;User ID=sa;Password=H5nry@Hosken@S5norio;Trusted_Connection=False; TrustServerCertificate=True; ";

    static void Main(string[] args)
    {
        var connetion = new SqlConnection(CONNECTION_STRING);
        connetion.Open();

        ReadUsers(connetion);
        ReadRoles(connetion);

        connetion.Close();
    }
  
    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var users = repository.Get();

        foreach (var user in users)        
            Console.WriteLine(user.Name);        
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);
        var roles = repository.Get();

        foreach (var role in roles)
            Console.WriteLine(role.Name);
    }
}
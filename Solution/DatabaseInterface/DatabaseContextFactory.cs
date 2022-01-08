
namespace DatabaseInterface
{
    public class DatabaseContextFactory
    {
        public static DatabaseContext GetContext(string connectionString)
        {
            return new DatabaseContext(connectionString);
        }
    }
}

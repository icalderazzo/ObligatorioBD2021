
namespace Obligatorio.Repositories
{
    public static class DatabaseSettingsRepository
    {
        public static string ConnectionString 
        {
            set {
                SetConnectionString(value);
            } 
        }
        private static void SetConnectionString(string value)
        {
            DataBaseInterface.DatabaseAccess.SetConnectionString(value);
        }
    }
}

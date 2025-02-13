using SQLite;

namespace MathGame.src.Infrastructure.Common;

public static class DatabaseInitializer
{
    public static void Initialize(IServiceProvider provider)
    {
        var connection = provider.GetService<SQLiteAsyncConnection>()!;

        connection.CreateTableAsync<Account>();
        connection.CreateTableAsync<Player>();
        connection.CreateTableAsync<Score>();
        
    }

    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(Constants.DatabasePath);
    }
}

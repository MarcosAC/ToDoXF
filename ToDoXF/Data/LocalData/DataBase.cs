using SQLite;
using ToDoXF.Models;
using Xamarin.Forms;

namespace ToDoXF.Data.LocalData
{
    public class DataBase
    {
        private static SQLiteConnection _connection;

        public DataBase()
        {
            var dependencyService = DependencyService.Get<IDataBaseConnection>();
            string connectionString = dependencyService.Connection("localDb.sqlite");
            _connection = new SQLiteConnection(connectionString);
            _connection.CreateTable<Todo>();
        }
    }
}

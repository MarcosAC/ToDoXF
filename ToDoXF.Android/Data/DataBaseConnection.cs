using System.IO;
using ToDoXF.Data.LocalData;
using ToDoXF.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataBaseConnection))]
namespace ToDoXF.Droid.Data
{
    public class DataBaseConnection : IDataBaseConnection
    {
        public string Connection(string dataBaseName)
        {
            string connectionString = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dataBase = Path.Combine(connectionString, dataBaseName);
            return dataBase;
        }
    }
}
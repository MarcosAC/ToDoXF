using System.Collections.ObjectModel;
using ToDoXF.Data.LocalData;

namespace ToDoXF.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DataBase dataBase;

        public Repository()
        {
            dataBase = new DataBase();
        }

        public void Add(T model)
        {
            dataBase._connection.Insert(model);
        }

        public void Delete(int id)
        {
            dataBase._connection.Delete<T>(id);
        }

        public void DeleteAll(T model)
        {
            dataBase._connection.Delete(model);
        }

        public void Edit(T model)
        {
            dataBase._connection.Update(model);
        }

        public ObservableCollection<T> GetAll()
        {
            return new ObservableCollection<T>(dataBase._connection.Table<T>().ToList());
        }
    }
}

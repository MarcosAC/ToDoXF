using System.Collections.ObjectModel;

namespace ToDoXF.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);
        void Delete(int id);
        void DeleteAll(T model);
        void Edit(T model);
        ObservableCollection<T> GetAll();
        //ObservableCollection<T> SearchTodo();
    }
}

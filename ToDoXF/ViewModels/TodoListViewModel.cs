using System.Collections.ObjectModel;
using ToDoXF.Data.Repository;
using ToDoXF.Models;
using ToDoXF.Views;
using Xamarin.Forms;

namespace ToDoXF.ViewModels
{
    public class TodoListViewModel : BaseViewModel
    {
        private readonly IRepository<Todo> _repositoryTodo;
        private Command _selectTodoCommand;
        public ObservableCollection<Todo> TodoList { get; set; }

        public TodoListViewModel()
        {
            _repositoryTodo = new Repository<Todo>();
            TodoList = LoadTodo();
        }

        private ObservableCollection<Todo> LoadTodo()
        {
            return _repositoryTodo.GetAll();
        }

        public Command SelectTodoCommand =>
            _selectTodoCommand ?? (_selectTodoCommand = new Command<Todo>(todo => ExecuteSelectTodoCommand(todo)));

        private void ExecuteSelectTodoCommand(Todo selectedTodo)
        {
            if (selectedTodo == null)
            {
                return;
            }

            //App.Current.MainPage.Navigation.PushAsync(new TodoFormView(selectedTodo));
        }
    }
}

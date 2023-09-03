using ToDoXF.Data.Repository;
using ToDoXF.Models;
using Xamarin.Forms;

namespace ToDoXF.ViewModels
{
    public class AddTodoViewModel : BaseViewModel
    {
        private readonly IRepository<Todo> _repositoryTodo;
        private Command _addTodoCommand;
        public AddTodoViewModel(Repository<Todo> repositoryTodo)
        {
            _repositoryTodo = repositoryTodo;
        }

        private string _todoTitle;
        public string TodoTitle
        {
            get => _todoTitle;
            set => SetProperty(ref _todoTitle, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public Command AddTodoCommand =>
            _addTodoCommand ?? (_addTodoCommand = new Command(() => ExecuteAddTodoCommand()));

        private void ExecuteAddTodoCommand()
        {
            var todo = new Todo
            {
                TodoTitle = TodoTitle,
                Description = Description,
            };

            _repositoryTodo.Add(todo);
        }
    }
}

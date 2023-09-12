using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        private Command _deleteTodoCommand;

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

            App.Current.MainPage.Navigation.PushAsync(new TodoFormView(selectedTodo));
        }

        public Command DeleteTodoCommand =>
            _deleteTodoCommand ?? (_deleteTodoCommand = new Command<Todo>(async todo => await ExecuteDeleteTodoCommand(todo)));

        private async Task ExecuteDeleteTodoCommand(Todo todo)
        {
            if (todo == null)
            {
                return;
            }

            bool ok = await App.Current.MainPage.DisplayAlert("Excluir Tarefa", "Deseja excluir tarefa", "Sim", "Não");

            if (ok)
            {
                try
                {
                    TodoList.Remove(todo);
                    _repositoryTodo.Delete(todo.Id);
                    
                    await App.Current.MainPage.DisplayAlert("Excluir Tarefa", "Tarefa excluida com sucesso!", "Ok");
                }
                catch (System.Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Erro ao excluir tarefa!", "Ok");
                }
            }
        }
    }
}

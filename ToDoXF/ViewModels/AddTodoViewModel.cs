using System;
using ToDoXF.Data.Repository;
using ToDoXF.Models;
using ToDoXF.Views;
using Xamarin.Forms;

namespace ToDoXF.ViewModels
{
    public class AddTodoViewModel : BaseViewModel
    {
        private readonly IRepository<Todo> _repositoryTodo;
        private Command _addTodoCommand;
        public AddTodoViewModel()
        {
            _repositoryTodo = new Repository<Todo>();
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
            try
            {
                var todo = new Todo
                {
                    TodoTitle = TodoTitle,
                    Description = Description,
                };

                _repositoryTodo.Add(todo);
                Application.Current.MainPage.DisplayAlert("Nova Tarefa", "Nova tarefa criada com sucesso.", "OK");
            }
            catch (Exception)
            {
                Application.Current.MainPage.DisplayAlert("Nova Tarefa", "Erro ao criar nova tarefa", "Ok");
            }

            App.Current.MainPage.Navigation.PushAsync(new TodoListView());
        }
    }
}

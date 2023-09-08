﻿using System;
using ToDoXF.Data.Repository;
using ToDoXF.Models;
using Xamarin.Forms;

namespace ToDoXF.ViewModels
{
    public class AddTodoViewModel : BaseViewModel
    {
        private readonly IRepository<Todo> _repositoryTodo;
        private Command _addTodoCommand;
        private readonly Todo _todo;
        public AddTodoViewModel()
        {
            _repositoryTodo = new Repository<Todo>();
        }

        public AddTodoViewModel(Todo selectedTodo)
        {
            _todo = selectedTodo;
        }

        private string _todoTitle;
        public string TodoTitle
        {

            get => _todo != null ? _todo.TodoTitle : _todoTitle;

            set
            {
                if (_todo != null)
                {
                    _todo.TodoTitle = value;
                    OnPropertyChanged();
                }

                SetProperty(ref _todoTitle, value);
            }
        }

        private string _description;
        public string Description
        {
            get => _todo != null ? _todo.Description : _description;

            set
            {
                if (_todo != null)
                {
                    _todo.Description = value;
                    OnPropertyChanged();
                }

                SetProperty(ref _description, value);
            }
        }

        public Command AddTodoCommand =>
            _addTodoCommand ?? (_addTodoCommand = new Command(() => ExecuteAddTodoCommand()));

        private void ExecuteAddTodoCommand()
        {
            try
            {
                Todo todo = new Todo
                {
                    TodoTitle = TodoTitle,
                    Description = Description,
                };

                _repositoryTodo.Add(todo);

               App.Current.MainPage.DisplayAlert("Nova Tarefa", "Nova tarefa criada com sucesso.", "OK");

                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Nova Tarefa", "Erro ao criar nova tarefa", "Ok");
            }
        }
    }
}

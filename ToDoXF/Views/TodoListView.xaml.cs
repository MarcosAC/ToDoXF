using System;
using ToDoXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListView : ContentPage
    {
        public TodoListView()
        {
            InitializeComponent();

            ViewModel = new TodoListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new TodoListViewModel();
        }

        private TodoListViewModel ViewModel
        {
            get => BindingContext as TodoListViewModel;
            set => BindingContext = value;
        }

        private void OnGoNewTaskClicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new TodoFormView());
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.SelectTodoCommand.Execute(e.SelectedItem);
            }

            ListViewTodo.SelectedItem = null;
        }
    }
}
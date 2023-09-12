using ToDoXF.Models;
using ToDoXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoFormView : ContentPage
    {
        public TodoFormView()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = new AddTodoViewModel();
            Title = "Nova Tarefa";
        }

        public TodoFormView(Todo selectedTodo)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = new AddTodoViewModel(selectedTodo);
            Title = "Editar Tarefa";
        }

        private void OnBackTodoListViewClicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
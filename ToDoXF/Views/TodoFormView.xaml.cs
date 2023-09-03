using ToDoXF.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoFormView : ContentPage
    {
        public TodoFormView()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            Title = "Nova Tarefa";
        }

        public TodoFormView(Todo selectedTodo)
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            Title = "Editar Tarefa";
        }
    }
}
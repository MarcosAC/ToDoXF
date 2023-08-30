using ToDoXF.Models;
using ToDoXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoDetailsView : ContentPage
    {
        public TodoDetailsView(Todo selectedTodo)
        {
            InitializeComponent();

            BindingContext = new TodoListViewModel();
        }
    }
}
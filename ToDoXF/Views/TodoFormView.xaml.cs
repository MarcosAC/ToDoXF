using ToDoXF.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoFormView : ContentPage
    {
        public TodoFormView(Todo selectedTodo)
        {
            InitializeComponent();
        }

        public TodoFormView()
        {

        }
    }
}
using System;
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
        }

        private void OnGoNewTaskClicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new TodoFormView());
        }
    }
}
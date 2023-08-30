﻿using System;
using ToDoXF.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoXF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TodoFormView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

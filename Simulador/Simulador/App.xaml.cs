using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simulador
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Tabbed();
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

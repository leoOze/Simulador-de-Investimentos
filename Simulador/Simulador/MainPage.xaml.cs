using System;
using Xamarin.Forms;

namespace Simulador
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var canal = "https://www.deflacione.cf";
            Device.OpenUri(new Uri(canal));
        }
    }
}

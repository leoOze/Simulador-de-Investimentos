using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var canal = "https://www.youtube.com/channel/UCGoMSEhZSKLj7s0DDOhQkjQ";
            Device.OpenUri(new Uri(canal));
        }
    }
}

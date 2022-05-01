using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simulador
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tabbed : TabbedPage
    {
        public Tabbed()
        {
            InitializeComponent();


        }


        public void ButtonClicked(object obj, EventArgs args)
        {
            var canal = "https://www.youtube.com/channel/UCGoMSEhZSKLj7s0DDOhQkjQ";
            Device.OpenUri(new Uri(canal));
        }

    }
}
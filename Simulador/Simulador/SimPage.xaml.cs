using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Simulador
{
    public partial class SimPage : ContentPage
    {
        public SimPage()
        {
            InitializeComponent();

            
        }

        private void Simular(object sender, EventArgs e)
        {
            double taxaSelic = 0.1175;

            double eqpUm = (taxaSelic + 1);

            double eqp2 = Math.Pow(eqpUm, Convert.ToDouble(tbTempo.Text));

            double montante = eqp2 * Convert.ToDouble(tbInvest.Text);
            Convert.ToString(tbInvest.Text);


            txtResultado.Text = $"Em {tbTempo.Text} anos, seu investimento de {tbInvest.Text} terá retornado R$ {montante} (sem o desconto do imposto de renda)";
        }
    }
}

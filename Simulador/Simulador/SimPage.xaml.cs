using Microcharts;
using SkiaSharp;
using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.ChartEntry;



namespace Simulador
{
    public partial class SimPage : ContentPage
    {
        public void Simular(object sender, EventArgs e)
        {
            double taxaSelic = 0.1375, taxaInflacao = 0.1007, cdi = 0.1446, montante = Convert.ToDouble(tbInvest.Text) * Math.Pow(taxaSelic + 1, Convert.ToDouble(tbTempo.Text)), invInicial = Convert.ToDouble(tbInvest.Text), invAnos = Convert.ToDouble(tbTempo.Text), ir = 0, custodia = 0;
            double poupanca = 0.0617, montpoupanca = Convert.ToDouble(tbInvest.Text) * Math.Pow((poupanca + 1), Convert.ToDouble(tbTempo.Text));
            double montInflacao = invInicial * Math.Pow((taxaInflacao + 1), invAnos),   montLci = invInicial * Math.Pow((cdi + 1), invAnos);
            string poupText = montpoupanca.ToString("F2");
            montante = Math.Round(montante, 2);
            

            if (invAnos < 0.49)
            {
                ir = ((montante - invInicial) * 0.225);
                montante = montante - ((montante - invInicial) * 0.225);

            } // IR
            else if (invAnos > 0.49 && invAnos < 0.98)
            {
                ir = ((montante - invInicial) * 0.2);
                montante = montante - ((montante - invInicial) * 0.2);
            }
            else if (invAnos > 0.98 && invAnos < 1.97)
            {
                ir = ((montante - invInicial) * 0.175);
                montante = montante - ((montante - invInicial) * 0.175);
            }
            else if (invAnos > 1.97)
            {
                ir = ((montante - invInicial) * 0.15);
                montante = montante - ((montante - invInicial) * 0.15);
            }
            for (double i = 0; i < invAnos;)
            {
                if (montante > 10000 && invAnos >= 0.5)
                {
                    custodia = ((montante - 10000) * 0.02);
                    montante = montante - ((montante - 10000) * 0.02);
                }
                i = i + 0.5;
            } // Taxa de Custódia



            string montanteString = montante.ToString("F1"), irstr = ir.ToString("F1"), custodiaString = custodia.ToString("F1"), inflastring = montInflacao.ToString("F1"), lcistring = montLci.ToString("F1");



            txtResultado.Text = $"Rentabilidade de investimento de R$ {tbInvest.Text} por {tbTempo.Text} anos:\n\nPoupança: R$ {poupText} \nTesouro Selic: R$ {montanteString}\nLCI (110% do CDI): R$ {lcistring}\nInflação: R$ {inflastring}";
            
            List<Entry> entries = new List<Entry> 
        {
            new Entry((float)Convert.ToDouble(tbInvest.Text))
            {
                Color=SKColor.Parse("#545454"),
                Label = "Sem investir",
                ValueLabel = tbInvest.Text
            },
            new Entry((float)montpoupanca)
            {
                Color = SKColor.Parse("#cf601b"),
                Label = "Poupança",
                ValueLabel = poupText
            },

            new Entry((float)montante)
            {
                Color = SKColor.Parse("#7105ab"),
                Label = "Selic",
                ValueLabel = montanteString
            },
            new Entry((float)montInflacao)
            {
                Color = SKColor.Parse("#f20a0a"),
                Label = "IPCA",
                ValueLabel = inflastring
            },
            new Entry((float)montLci)
            {
                Color = SKColor.Parse("#00fa11"),
                Label = "Lci 110%",
                ValueLabel = lcistring
            },
         };



            List<Entry> grp2 = new List<Entry>
        {
            new Entry((float)montante)
            {
                Color=SKColor.Parse("#0ceb1e"),
                Label = "Retorno liquido",
                ValueLabel = montanteString,
                ValueLabelColor = SKColor.Parse("#0ceb1e"),
                TextColor = SKColor.Parse("#0ceb1e")
            },
            new Entry((float)ir)
            {
                Color = SKColor.Parse("#450c0f"),
                Label = "Imposto de Renda",
                ValueLabel = irstr,
                ValueLabelColor = SKColor.Parse("#450c0f"),
                TextColor = SKColor.Parse("#450c0f")
            },
            new Entry((float)custodia)
            {
                Color = SKColor.Parse("#9e6105"),
                Label = "Taxa de Custódia",
                ValueLabel = custodiaString,
                ValueLabelColor = SKColor.Parse("#9e6105"),
                TextColor = SKColor.Parse("#9e6105")
            },
         };


            Grafico1.Chart = new BarChart() { Entries = entries, LabelOrientation = Orientation.Horizontal, ValueLabelOrientation = Orientation.Horizontal, LabelColor = SKColor.Parse("#000000"), LabelTextSize = 39, Margin = 50, BarAreaAlpha = 80 };
            Grafico2.Chart = new PieChart() { Entries = grp2, LabelTextSize = 40, Margin = 80, GraphPosition = GraphPosition.AutoFill, LabelMode = LabelMode.RightOnly };
            int barWidth = 60;
            Grafico2.WidthRequest = entries.Count * barWidth;

        }

        

        public SimPage()
        {
            InitializeComponent();

        }
    }
}

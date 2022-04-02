using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAgro.Documentatie;
using DoAgro;

namespace DoAgro.Asolamente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Trienal : ContentPage
    {
        Culturi culturi1;
        Culturi culturi2;
        Culturi culturi3;
        public Trienal()
        {
            InitializeComponent();
            List<Culturi> culturiTrienal = new List<Culturi>
            {
                new Culturi{Denumire="Brocoli"},
                new Culturi{Denumire="Castravete"},
                new Culturi{Denumire="Cartofi albi"},
                new Culturi{Denumire="Ceapa"},
                new Culturi{Denumire="Ceapa verde"},
                new Culturi{Denumire="Floarea soarelui"},
                new Culturi{Denumire="Mazare"},
                new Culturi{Denumire="Porumb"},
                new Culturi{Denumire="Ridiche"},
                new Culturi{Denumire="Rosie"},
                new Culturi{Denumire="Usturoi"},
                new Culturi{Denumire="Trifoi/Lucerna"},
                new Culturi{Denumire="Varza timpurie"},
                new Culturi{Denumire="Varza de vara/Varza rosie/Varza de toamna"},
                new Culturi{Denumire="Vinata"},
                //new Culturi{Denumire="va urma...."}
            };
            Parcela1.ItemsSource = culturiTrienal;
            Parcela2.ItemsSource = culturiTrienal;
            Parcela3.ItemsSource = culturiTrienal;
        }

        private void Parcela1_SelectedIndexChanged(object sender, EventArgs e)
        {
            culturi1 = ((sender as Picker).SelectedItem as Culturi);
        }

        private void Parcela2_SelectedIndexChanged(object sender, EventArgs e)
        {
            culturi2 = ((sender as Picker).SelectedItem as Culturi);
        }

        private void Parcela3_SelectedIndexChanged(object sender, EventArgs e)
        {
            culturi3 = ((sender as Picker).SelectedItem as Culturi);
        }
        private void ButonGenereazaRotatie_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (culturi1.Denumire.Equals("Porumb") && culturi2.Denumire.Equals("Porumb") && culturi2.Denumire.Equals("Porumb"))
                {
                    RezultatRotatie1.Text = "Lucerna sau trifoi";
                    RezultatRotatie2.Text = "1. Porumb\n2. Porumb\n3. Porumb";
                    RezultatRotatie3.Text = "Lucerna sau trifoi (pe una dintre parcele se poate continua cu porumb)";

                }
                else if (culturi1.Denumire.Equals("Porumb") && culturi2.Denumire != "Porumb" && culturi3.Denumire != "Porumb")
                {
                    RezultatRotatie1.Text = "Lucerna sau trifoi";
                    RezultatRotatie2.Text = "1. Porumb\n2. Porumb\n3. Porumb";
                    RezultatRotatie3.Text = "1. Lucerna sau trifoi\n2. Lucerna sau trifoi\n3. Mazare, fasole, radacinoase";
                }
                else if (culturi2.Denumire.Equals("Porumb") && culturi1.Denumire != "Porumb" && culturi3.Denumire != "Porumb")
                {
                    RezultatRotatie1.Text = "Lucerna sau trifoi";
                    RezultatRotatie2.Text = "1. Porumb\n2. Porumb\n3. Porumb";
                    RezultatRotatie3.Text = "Lucerna sau trifoi, mazare, fasole, radacinoase";
                }
                else if (culturi3.Denumire.Equals("Porumb") && culturi1.Denumire != "Porumb" && culturi2.Denumire != "Porumb")
                {
                    RezultatRotatie1.Text = "Lucerna sau trifoi";
                    RezultatRotatie2.Text = "1. Porumb\n2. Porumb\n3. Porumb";
                    RezultatRotatie3.Text = "1. Lucerna sau trifoi\n2. Lucerna sau trifoi\n3. Mazare, fasole, radacinoase";
                }
                else if ((culturi1.Denumire.Equals("Porumb") && culturi2.Denumire.Equals("Porumb")) || (culturi1.Denumire.Equals("Porumb") && culturi3.Denumire.Equals("Porumb"))
                   || (culturi2.Denumire.Equals("Porumb") && culturi1.Denumire.Equals("Porumb") || (culturi2.Denumire.Equals("Porumb") && culturi3.Denumire.Equals("Porumb"))))
                {
                    RezultatRotatie1.Text = "Lucerna sau trifoi";
                    RezultatRotatie2.Text = "1. Porumb\n2. Porumb\n3. Porumb";
                    RezultatRotatie3.Text = "Lucerna sau trifoi (pe una dintre parcele se poate continua cu porumb)";
                }
                if (culturi1.Denumire.Equals("Rosie") || culturi1.Denumire.Equals("Vanata") && (culturi2.Denumire != "Floarea soarelui" || culturi3.Denumire != "Floarea soarelui"))
                {
                    RezultatRotatie1.Text = "Lucerna, trifoi, mazare, fasole, radacinoase, ceapa, praz, usturoi, cereale de toamna sau bostanoase";

                }
                if (culturi2.Denumire.Equals("Rosie") || culturi2.Denumire.Equals("Vanata")
                    && (culturi1.Denumire != "Floarea soarelui" || culturi3.Denumire != "Floarea soarelui"))
                {
                    RezultatRotatie2.Text = "Lucerna, trifoi, mazare, fasole, radacinoase, ceapa, praz, usturoi, cereale de toamna sau bostanoase";
                }
                if (culturi3.Denumire.Equals("Rosie") || culturi3.Denumire.Equals("Vanata")
                    && (culturi2.Denumire != "Floarea soarelui" || culturi1.Denumire != "Floarea soarelui"))
                {
                    RezultatRotatie3.Text = "Lucerna, trifoi, mazare, fasole, radacinoase, ceapa, praz, usturoi, cereale de toamna sau bostanoase";
                }
                if ((culturi1.Denumire.Equals("Brocoli") || culturi1.Denumire.Equals("Castravete")) && (culturi2.Denumire.Equals("Varza timpurie") || culturi2.Denumire.Equals("Ceapa") || culturi2.Denumire.Equals("Usturoi")) && culturi3.Denumire.Equals("Varza de vara/Varza rosie/Varza de toamna"))
                {
                    RezultatRotatie1.Text = "1. Varza sau radacinoase\n2. ceapa, praz, usturoi\n3. Mazare, fasole, salata, spanac";
                    RezultatRotatie2.Text = "1. Vinete sau rosii\n2. Mazare, fasole, ardei, vinete, rosii\n3. Rosii, vinete, varza, salata, ceapa, praz, usturoi";
                    RezultatRotatie3.Text = "Lucerna, trifoi, mazare, fasole, radacinoase, salata, ceapa, praz, usturoi";
                }
                else if ((culturi2.Denumire.Equals("Brocoli") || culturi2.Denumire.Equals("Castravete")) && (culturi1.Denumire.Equals("Varza timpurie") || culturi1.Denumire.Equals("Ceapa") || culturi1.Denumire.Equals("Usturoi")) && culturi3.Denumire.Equals("Varza de vara/Varza rosie/Varza de toamna"))
                {
                    RezultatRotatie1.Text = "1. ceapa, praz, usturoi\n2. Varza sau radacinoase\n3. Mazare, fasole, salata, spanac";
                    RezultatRotatie2.Text = "1. Mazare, fasole, ardei, vinete, rosii\n2. Vinete sau rosii\n3. Rosii, vinete, varza, salata, ceapa, praz, usturoi";
                    RezultatRotatie3.Text = "Lucerna, trifoi, mazare, fasole, radacinoase, salata, ceapa, praz, usturoi";
                }
                else if ((culturi3.Denumire.Equals("Brocoli") || culturi3.Denumire.Equals("Castravete")) && (culturi3.Denumire.Equals("Varza timpurie") || culturi3.Denumire.Equals("Ceapa") || culturi3.Denumire.Equals("Usturoi")) && culturi2.Denumire.Equals("Varza de vara/Varza rosie/Varza de toamna"))
                {
                    RezultatRotatie1.Text = "1. ceapa, praz, usturoi\n2. Varza sau radacinoase\n3. Mazare, fasole, salata, spanac";
                    RezultatRotatie2.Text = "1. Mazare, fasole, ardei, vinete, rosii\n2. Vinete sau rosii\n3. Rosii, vinete, varza, salata, ceapa, praz, usturoi";
                    RezultatRotatie3.Text = "Lucerna, trifoi, mazare, fasole, radacinoase, salata, ceapa, praz, usturoi";
                }
                if ((culturi1.Denumire.Equals("Ceapa") || culturi1.Denumire.Equals("Usturoi")) && (culturi2.Denumire.Equals("Ceapa") || culturi2.Denumire.Equals("Usturoi")) && (culturi3.Denumire.Equals("Ceapa") || culturi3.Denumire.Equals("Usturoi")))
                {
                    RezultatRotatie1.Text = "Mazare, fasole, ardei, vinete, rosii";
                    RezultatRotatie2.Text = "Ceapa, praz, usturoi";
                    RezultatRotatie3.Text = "Mazare, fasole, ardei, vinete, rosii";
                }
                else if ((culturi1.Denumire.Equals("Ceapa") || culturi1.Denumire.Equals("Usturoi")) && culturi2.Denumire.Equals("Ridiche") && (culturi3.Denumire.Equals("Ceapa") || culturi3.Denumire.Equals("Usturoi")))
                {
                    RezultatRotatie1.Text = "Mazare, fasole, ardei, vinete, rosii";
                    RezultatRotatie2.Text = "1. Ceapa, praz, usturoi\n2. Ardei, rosi, vinete\n3. Ceapa, praz, usturoi";
                    RezultatRotatie3.Text = "Mazare, fasole, ardei, vinete, rosii";

                }
                else if ((culturi1.Denumire.Equals("Ceapa verde") || culturi1.Denumire.Equals("Ceapa rosie")) && (culturi1.Denumire.Equals("Ceapa verde") || culturi1.Denumire.Equals("Ceapa rosie")) && (culturi2.Denumire.Equals("Ceapa verde") || culturi2.Denumire.Equals("Ceapa rosie")) && (culturi1.Denumire.Equals("Ceapa verde") || culturi1.Denumire.Equals("Ceapa rosie")))
                {
                    RezultatRotatie1.Text = "Mazare, fasole, radacinoase, bostanoase";
                    RezultatRotatie2.Text = "Mazare, fasole, bostanoase";
                    RezultatRotatie3.Text = "Ardei, rosii, vinete, varza, salata, mazare, fasole, radacinoase, bostanoase";

                }
                if (culturi1.Denumire.Equals("Floarea soarelui") || culturi2.Denumire.Equals("Floarea soarelui") || culturi3.Denumire.Equals("Floarea soarelui"))
                {
                    RezultatRotatie1.Text = "Floarea soarelui";
                    RezultatRotatie2.Text = "Floarea soarelui";
                    RezultatRotatie3.Text = "Floarea soarelui";
                }
                if (culturi1.Denumire.Equals("Cartofi albi") && culturi2.Denumire.Equals("Cartofi albi") && culturi3.Denumire.Equals("Cartofi albi"))
                {
                    RezultatRotatie1.Text = "Cartofi";
                    RezultatRotatie2.Text = "Lucerna sau trifoi";
                    RezultatRotatie3.Text = "Cartofi";

                }
                else if (culturi1.Denumire.Equals("Cartofi albi") && culturi2.Denumire != "Cartofi albi" && culturi3.Denumire.Equals("Cartofi albi"))
                {
                    RezultatRotatie1.Text = "1. Cartofi\n2. Lucerna sau trifoi\n3. Cartofi";
                    RezultatRotatie2.Text = "1. Lucerna sau trifoi\n2. Cartofi\n3. Lucerna sau trifoi";
                    RezultatRotatie3.Text = "Cartofi";

                }
                else if (culturi1.Denumire != "Cartofi albi" && culturi2.Denumire.Equals("Cartofi albi") && culturi3.Denumire.Equals("Cartofi albi"))
                {
                    RezultatRotatie1.Text = "1. Lucerna sau trifoi\n2. Cartofi\n3. Cartofi";
                    RezultatRotatie2.Text = "1. Cartofi\n2. Lucerna sau trifoi\n3. Lucerna sau trifoi";
                    RezultatRotatie3.Text = "Cartofi";

                }
                if (culturi1.Denumire.Equals("Trifoi/Lucerna") && culturi2.Denumire.Equals("Trifoi/Lucerna") && culturi3.Denumire.Equals("Trifoi/Lucerna"))
                {
                    RezultatRotatie1.Text = "Se recomanda culturi inrudite pentru a imbogati solul";
                    RezultatRotatie2.Text = "rotatie";
                    RezultatRotatie3.Text = "rotatie si lucerna sau trifoi macar pe una dintre parcele";
                }
                else if (culturi1.Denumire != "Trifoi/Lucerna" && culturi2.Denumire.Equals("Trifoi/Lucerna") && culturi3.Denumire.Equals("Trifoi/Lucerna")
                   || (culturi2.Denumire != "Trifoi/Lucerna" && culturi1.Denumire.Equals("Trifoi/Lucerna") && culturi3.Denumire.Equals("Trifoi/Lucerna"))
                   || culturi3.Denumire != "Trifoi/Lucerna" && culturi2.Denumire.Equals("Trifoi/Lucerna") && culturi1.Denumire.Equals("Trifoi/Lucerna"))
                {
                    RezultatRotatie1.Text = "Se recomanda culturi inrudite (Ex: ceapa, praz, usturoi)";
                    RezultatRotatie2.Text = "rotatie intre ele";
                    RezultatRotatie3.Text = "rotatie intre ele";
                }

                //Nu am terminat inca toate combinatiile

            }
            catch (Exception)
            {
                DisplayAlert("ATENTIE", "Toate parcelele trebuie completate !", "OK");
            }
        }
            
    }
}
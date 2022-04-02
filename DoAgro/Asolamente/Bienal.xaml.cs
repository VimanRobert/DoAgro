using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAgro.Asolamente;
using DoAgro.Documentatie;

namespace DoAgro.Asolamente
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bienal : ContentPage
    {
        Culturi culturi;
        public Bienal()
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
                new Culturi{Denumire="Varza timpurie"},
                new Culturi{Denumire="Varza de vara/Varza rosie/Varza de toamna"},
                new Culturi{Denumire="Vinata"},
                //new Culturi{Denumire="va urma...."}
            };
            Parcela.ItemsSource = culturiTrienal;
        }

        private void Parcela_SelectedIndexChanged(object sender, EventArgs e)
        {
            culturi = ((sender as Picker).SelectedItem as Culturi);
        }

        private void ButonGenereazaRotatie_Clicked(object sender, EventArgs e)
        {
            try { 

            if (culturi.Denumire.Equals("Varza de vara/Varza rosie/Varza de toamna"))
            {
                _ = RezultatRotatie.Text = "Mazare, cartofi, fasole, salata, spanac, ceapa, praz, usturoi";

            }
            else if (culturi.Denumire.Equals("Ceapa") || culturi.Denumire.Equals("Usturoi"))
            {
                _ = RezultatRotatie.Text = "Mazare, fasole, ardei, vinete, rosii, bostanoase";

            }
            else if (culturi.Denumire.Equals("Ceapa verde") || culturi.Denumire.Equals("Ceapa rosie"))
            {
                _ = RezultatRotatie.Text = "Mazare, fasole, radacinoase, bostanoase";

            }
            else if (culturi.Denumire.Equals("Castravete"))
            {
                _ = RezultatRotatie.Text = "Brocoli, varza, radacinoase, cartofi, cereale pastaioase";

            }
            else if (culturi.Denumire.Equals("Brocoli"))
            {
                _ = RezultatRotatie.Text = "Brocoli, varza, radacinoase, ";

            }
            else if (culturi.Denumire.Equals("Cartofi albi"))
            {
                _ = RezultatRotatie.Text = "Tot cartofi";

            }
            else if (culturi.Denumire.Equals("Floarea soarelui"))
            {
                _ = RezultatRotatie.Text = "Macar 5 ani consecutivi tot aceeasi cultura";

            }
            else if (culturi.Denumire.Equals("Mazare"))
            {
                _ = RezultatRotatie.Text = "Ardei, rosii, vinete, varza, salata, ceapa, praz, usturoi, bostanoase, radacinoase";

            }
            else if (culturi.Denumire.Equals("Porumb"))
            {
                _ = RezultatRotatie.Text = "Lucerna sau trifoi este recomandat, pentru a se odihni pamantul pana anul urmator";

            }
            else if (culturi.Denumire.Equals("Ridiche"))
            {
                _ = RezultatRotatie.Text = "Ardei, rosi, vinete, bostanoase, cereale";

            }
            else if (culturi.Denumire.Equals("Vinata") || culturi.Denumire.Equals("Rosie"))
            {
                _ = RezultatRotatie.Text = "Lucerna, trifoi, mazare, fasole, radacinoase, ceapa, praz, usturoi, cereale de toamna sau bostanoase";

            }
            else if (culturi.Denumire.Equals("Varza timpurie"))
            {
                _ = RezultatRotatie.Text = "Ardei, rosii, vinete, pastaioase, ceapa, praz, usturoi";

            }
            }
            catch (Exception)
            {
                DisplayAlert("ATENTIE", "Parcela este necompletata", "OK");
            }
        }
    }
}
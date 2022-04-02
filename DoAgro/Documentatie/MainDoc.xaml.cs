using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAgro.Documentatie;

namespace DoAgro.Documentatie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDoc : ContentPage
    {
        public MainDoc()
        {
            InitializeComponent();
            List<Culturi> listaCulturi = new List<Culturi>
            {
                new Culturi{Imagine="brocoli.png", Denumire="Brocoli", Familie="Brasicaceae", 
                    Descriere="Are o valoare nutritiva sialimentara ridicataside asemenea un continut bogat in glucide, vitamine si saruri minerale. " +
                    "Productia este de 10-12 t/ha, ajungand chiar pana la 25 t/ha.", },

                new Culturi{Imagine="castraveti1.jpg", Denumire="Castravete", Familie="Cucurbitaceae", 
                    Descriere="Este un bun laxativ si contribuie la eliminarea toxinelor din organism. " +
                    "Poate fi utilizat ca remediu natural in tratarea: iritatiilor, intestinelor, reumatismului, gutei, arsurilor solare si a constipatiei. " +
                    "De asemenea si semintele au proprietati terapeutice care trateaza afectiuni precum tuse, probleme ale tenului si probleme cu expectoratia. ", },

                new Culturi{Imagine="cartofialbi1.jpg", Denumire="Cartofi albi", Familie="", 
                    Descriere="", },
                new Culturi{Imagine="ceapagalbena1.jpg", Denumire="Ceapa galbena", Familie="", Descriere="", },
                new Culturi{Imagine="ceaparosie1.jpg", Denumire="Ceapa rosie", Familie="", Descriere="", },
                new Culturi{Imagine="Floareasoarelui.jpg", Denumire="Floarea soarelui", Familie="", Descriere="", },
                new Culturi{Imagine="mazare.jpg", Denumire="Mazare", Familie="", Descriere="", },
                new Culturi{Imagine="porumb1.jpg", Denumire="Porumb", Familie="", Descriere="", },
                new Culturi{Imagine="ridiche.jpg", Denumire="Ridiche", Familie="", Descriere="", },

                new Culturi{Imagine="rosii1.jpg", Denumire="Rosie", Familie="Solanaceae", 
                    Descriere="Este o sursa buna de fibre, oferind aproximativ 1,5grame de fibre pe rosie de dimensiuni medii." +
                    "Rosiile proaspete au un continut scazut de carbohidrati. Continutul de carbohidrati consta in principal din zaharuri simple si fibre insolubile. " +
                    "Ajuta la o dieta echilibrata dar combate si afectiuni precum bolile de inima, cancer si boli ale pielii", },

                new Culturi{Imagine="usturoi1.jpg", Denumire="Usturoi", Familie="", Descriere="", },

                new Culturi{Imagine="varzaverde1.jpg", Denumire="Varza alba", Familie="Brasicaceae", 
                    Descriere="Este o planta bienala deoarece in primul an vegeteaza, iar in al doilea an infloreste. " +
                    "Este recomandata ca tratament pentru: anemie, diabet zaharat, tuse, litizie biliara, afectiuni renale, dureri de ficat si ulcer gastric.", },

                new Culturi{Imagine="vinete1.jpg", Denumire="Vinata", Familie="Solanaceae", 
                    Descriere="Beneficiile pentru sanatate ale vinetelor sunt in primul rand derivate din continutullor de vitamine. " +
                    "Aceste beneficii sunt: pierderea in greutate, prevenirea cancerului, imbunatatesc sanatatea oaselor,imbunatatesc sanatatea inimii, prevenirea diabetului, prevenirea anemiei si sanatatea ficatului. " +
                    "De asemenea poate fi un risc pentru alergii,nicotina sau sarcina.", }
            };
            listViewCulturi.ItemsSource = listaCulturi;
        }

        private async void listViewCulturi_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cultura = e.SelectedItem as Culturi;
            var paginaCultura = new InfoCultura();
            paginaCultura.BindingContext = cultura;
            await Navigation.PushAsync(paginaCultura);
        }
    }
}
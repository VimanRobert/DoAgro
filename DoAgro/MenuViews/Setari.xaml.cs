using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAgro.MenuViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Setari : ContentPage
    {
        UserManager userManager = new UserManager();
        public Setari()
        {
            InitializeComponent();
        }

        private async void schimbaParola_Clicked(object sender, EventArgs e)
        {
            try
            {
                string token = Preferences.Get("token", "");
                bool ischanged;
                string parola = schimbaParola.Text;
                string confParola = confirmareParola.Text;
                ischanged = await userManager.SchimbareParola(token, parola);
                if (string.IsNullOrEmpty(parola))
                {
                    await DisplayAlert("Schimba parola", "Necesita adaugat o parola noua!", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(confParola))
                {
                    await DisplayAlert("Schimba parola", "Necesita confirmarea parolei!", "OK");
                    return;
                }
                if (parola != confParola)
                {
                    await DisplayAlert("Schimba parola", "Nu se potriveste parola din casuta 'confirmare parola' cu cea introdusa mai sus!", "OK");
                    return;
                }
                if (ischanged)
                {
                    await DisplayAlert("Schimba parola", "Parola a fost schimbata cu succes!\nAveti grija sa nu o uitati.", "OK");
                    return;
                }
                else
                {
                    await DisplayAlert("Schimba parola", "A aparut o eroare!\nReincercati din nou.", "OK");
                }
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Schimba parola", "A aparut o eroare de sistem!\nReincercati din nou.", "OK");
                await App.Current.MainPage.DisplayAlert("Autentificare", ex.Message, "OK");
            }

        }

        private void stergeContul_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
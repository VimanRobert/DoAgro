using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAgro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Auth : ContentPage
    {
        public string WebAPIkey = "AIzaSyAORmGx7StS_KVkahljSogKIIvCAbEO26c";
        UserManager userManager = new UserManager();

        //public string Nume { set; get; }
        //public string Prenume { set; get; }
        //public string Email { set; get; }
        //public string NumeUtilizator { set; get; }
        //public string Parola { set; get; }
        //public string ConfirmareParola { set; get; }
        //public Task MesajConfirmare { set; get; }
        public Auth()
        {
            InitializeComponent();
        }
        private async void buttonInapoi(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void buttonCreeaza(object sender, EventArgs e)
        {
            string username = new_username.Text;
            string email = new_email.Text;
            string parola = new_password.Text;
            if(new_password.Text != confirmare_parola.Text)
            {
                await DisplayAlert("ATENTIE","Nu se potriveste parola din casuta 'confirmare parola' cu cea introdusa mai sus!","OK");
            }
            else if(new_email.Text == null || new_password.Text == null || new_username.Text == null || confirmare_parola.Text == null)
            {
                await DisplayAlert("ATENTIE", "Toate campurile trebuie completate!", "OK");
            }
            else
            {
                try
                {
                    bool newuser = await userManager.Autentificare(email, username, parola);
                    if (newuser)
                    {
                        await App.Current.MainPage.DisplayAlert("Autentificare", "Contul a fost creat cu succes!", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Autentificare","Nu s-a putut crea contul.\nReincearcati din nou.", "OK");
                    }
                    /*
                    var authProv = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                    var authUser = await authProv.CreateUserWithEmailAndPasswordAsync(new_email.Text, new_password.Text);

                    string token = authUser.FirebaseToken;
                    */
                }
                catch(Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Autentificare", ex.Message, "OK");
                }
                /*
                MesajConfirmare = DisplayAlert("Succes", "Contul a fost creat cu succes!", "OK");
                await Navigation.PopAsync();
                */
            }
        }
    }
}
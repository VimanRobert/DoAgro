using DoAgro.MenuViews;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAgro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //private string email;
        //private string parola;
        public Login()
        {
            InitializeComponent();
        }
        public string WebAPIkey = "AIzaSyAORmGx7StS_KVkahljSogKIIvCAbEO26c";


        private async void ButtonLogin(object sender, EventArgs e)
        {
            var authProv = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            if (insert_email.Text == null || insert_password.Text == null)
            {
              _ = DisplayAlert("ATENTIE", "Completati toate campurile!", "OK");
            }
            else
            {
                try
                {
                    var LoginUser = await authProv.SignInWithEmailAndPasswordAsync(insert_email.Text, insert_password.Text);
                    var date = await LoginUser.GetFreshAuthAsync();
                    var sendDate = JsonConvert.SerializeObject(date);
                    Preferences.Set("FirebaseUserToken", sendDate);
                    await Navigation.PushModalAsync(new NavigationPage(new FlyoutMenu()));
                }
                catch (Exception)
                {
                    _ = DisplayAlert("ATENTIE", "Date invalide!", "OK");
                }
              //Navigation.PushModalAsync(new NavigationPage(new FlyoutMenu()));
            }
        }

        private void ButtonAuth(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Auth());
        }
    }
}
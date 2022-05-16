using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAgro.MenuViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Deconectare : ContentPage
    {
        public string WebAPIkey = "AIzaSyAORmGx7StS_KVkahljSogKIIvCAbEO26c";


        public Deconectare()
        {
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
        }
        public void Deconect(object sender, EventArgs e)
        {
            Preferences.Remove("FirebaseUserToken");
            //App.Current.MainPage = new NavigationPage(new Login());
            Navigation.PopModalAsync();
        }

        private async void GetProfileInformationAndRefreshToken()
        {
            try 
            {
           
            var authProv = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            var userLog = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FirebaseUserToken", ""));
            var discRefresh = await authProv.RefreshAuthAsync(userLog);
                Preferences.Set("FirebaseUserToken", JsonConvert.SerializeObject(discRefresh));
            }
            catch (Exception)
            {
                _ = DisplayAlert("EXPIRAT", "Sesiunea a expirat", "OK");
            }
        }

        public async void Ramane(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new NavigationPage(new FlyoutMenu()));
        }
    }
}
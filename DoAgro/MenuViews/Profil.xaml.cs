using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase;

namespace DoAgro.MenuViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profil : ContentPage
    {
        UserManager userManager = new UserManager();
        public string email;
        public string username;
        public Profil()
        {
            InitializeComponent();
            
        }
        public void ShowUserData()
        {
            username = usernameLabel.Text;
            email = emailLabel.Text;
        }
    }
}
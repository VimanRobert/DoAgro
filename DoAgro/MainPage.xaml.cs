using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DoAgro.MenuViews;
using DoAgro.Asolamente;
using DoAgro.Documentatie;

namespace DoAgro

    // Pagina Acasa !!
{
    //[Obsolete] = MasterDetailPage !!
    public partial class MainPage : ContentPage
    {
        //public List<MenuDetailItems> menuItems { get; set; }
        public MainPage()
        {
            InitializeComponent();
            /*
            menuItems = new List<MenuDetailItems>();

            menuItems.Add(new MenuDetailItems() { Title = "Profil", Point = typeof(Profil) });
            menuItems.Add(new MenuDetailItems() { Title = "Portofoliu", Point = typeof(Portofoliu) });
            menuItems.Add(new MenuDetailItems() { Title = "Acasa", Point = typeof(Acasa) });
            menuItems.Add(new MenuDetailItems() { Title = "Informatii", Point = typeof(Informatii) });
            menuItems.Add(new MenuDetailItems() { Title = "Setari", Point = typeof(Setari) });
            menuItems.Add(new MenuDetailItems() { Title = "Deconectare", Point = typeof(Deconectare) });

            navigationList.ItemsSource = menuItems;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
            */
        }
        private void ButtonDocumentatie(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new NavigationPage(new MainDoc()));
            Navigation.PushAsync(new MainDoc());
        }
        private void ButtonAslBienal(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Bienal());
        }
        private void ButtonAslTrienal(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Trienal());
        }
        /*
        private void MenuSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MenuDetailItems)e.SelectedItem;
            Type page = item.Point;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        */
    }
}

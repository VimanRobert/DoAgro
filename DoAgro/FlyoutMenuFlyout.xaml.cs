using DoAgro.MenuViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAgro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutMenuFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutMenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutMenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutMenuFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutMenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutMenuFlyoutMenuItem>(new[]
                {
                    new FlyoutMenuFlyoutMenuItem {Title = "Acasa", Point=typeof(MainPage)},
                    new FlyoutMenuFlyoutMenuItem {Title = "Informatii", Point=typeof(Informatii)},
                    new FlyoutMenuFlyoutMenuItem {Title = "Setari", Point=typeof(Setari) },
                    new FlyoutMenuFlyoutMenuItem {Title = "Deconectare", Point=typeof(Deconectare) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
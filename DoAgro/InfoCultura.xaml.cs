using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAgro.Documentatie;

namespace DoAgro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoCultura : ContentPage
    {
        public InfoCultura()
        {
            InitializeComponent();
            //labelDenumire.Text = denumire;
        }
    }
}
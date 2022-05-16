using DoAgro.Documentatie;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;

namespace DoAgro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramulMeu : ContentPage
    {
        LocalNotification localNotification;
        Culturi culturi;
        Mesaj mesajNT;
        public ProgramulMeu()
        {
            InitializeComponent();
            List<Culturi> alegeCulturi = new List<Culturi>
            {
                new Culturi{Denumire="Brocoli"},
                new Culturi{Denumire="Castraveti"},
                new Culturi{Denumire="Cartofi albi"},
                new Culturi{Denumire="Ceapa"},
                new Culturi{Denumire="Ceapa verde"},
                new Culturi{Denumire="Floarea soarelui"},
                new Culturi{Denumire="Mazare"},
                new Culturi{Denumire="Porumb"},
                new Culturi{Denumire="Ridiche"},
                new Culturi{Denumire="Rosii"},
                new Culturi{Denumire="Usturoi"},
                new Culturi{Denumire="Varza timpurie"},
                new Culturi{Denumire="Varza de vara/Varza rosie/Varza de toamna"},
                new Culturi{Denumire="Vinete"},
            };

            List<Mesaj> alegeMesaj = new System.Collections.Generic.List<Mesaj>
            {
                new Mesaj{Descriere="Uda cultura"},
                new Mesaj{Descriere="Cultiva"},
                new Mesaj{Descriere="Culege roadele"},
                new Mesaj{Descriere="Da cu erbicid"},
                new Mesaj{Descriere="Da cu insecticid"},
                new Mesaj{Descriere="Da cu pesticid"},
                new Mesaj{Descriere="Pliveste"},
            };

            
            AlegeCultura.ItemsSource = alegeCulturi;
            MesajNotificare.ItemsSource = alegeMesaj;

            ShowData();
        }


        private void Cultura_SelectedIndexChanged(object sender, EventArgs e)
        {
            culturi = ((sender as Picker).SelectedItem as Culturi);
        }
        private void MesajNotificare_SelectedIndexChanged(object sender, EventArgs e)
        {
            mesajNT = ((sender as Picker).SelectedItem as Mesaj);
        }

        private async void ButtonCreeazaProgram_Clicked(object sender, EventArgs e)
        {
            try
            {
                var id = 1000;
                //bool answer = await DisplayAlert("Creeaza program", "Sunteti sigur?", "DA", "NU");
                //switch (answer) {  }
                        if (!string.IsNullOrWhiteSpace(AlegeCultura.Title) && !string.IsNullOrWhiteSpace(SetareOraNotificare.ToString()) && !string.IsNullOrWhiteSpace(MesajNotificare.Title))
                        {
                    await App.Database.SaveNotificationAsync(new LocalNotification
                    {
                        titlu = culturi.Denumire,
                        mesaj = mesajNT.Descriere,
                        oraNotificare = DateTime.Parse(oraSetata.Text),
                        nrNotificare = id++
                    });
                    //AlegeCultura.Title = SetareOraNotificare.Format = string.Empty;
                    AlegeCultura.Title = string.Empty;
                    MesajNotificare.Title = string.Empty;
                    SetareOraNotificare.Format = string.Empty;
                    dataView.ItemsSource = await App.Database.GetNotificationAsync();



                    var sendNotification = new NotificationRequest
                    {
                        BadgeNumber = 1,
                        Title = culturi.Denumire,
                        Description = mesajNT.Descriere,
                        ReturningData = "Este timpul sa va intoarceti in gradina !",
                        CategoryType = NotificationCategoryType.Event,
                        NotificationId = id,
                        Schedule =
                        {
                            NotifyTime = DateTime.Parse(oraSetata.Text),
                            //NotifyRepeatInterval = TimeSpan.FromSeconds(10),
                            //NotifyRepeatInterval = TimeSpan.FromDays(2),
                        },

                        Android = new Plugin.LocalNotification.AndroidOption.AndroidOptions
                        {
                            
                        }
                    };
                    await NotificationCenter.Current.Show(sendNotification);
                }

                
            }
            catch (Exception)
            {
                await DisplayAlert("Eroare", "A aparut o eroare!\nReincercati din nou.", "OK");
            }
        }
        protected async void ShowData()
        {
            base.OnAppearing();
            dataView.ItemsSource = await App.Database.GetNotificationAsync();
        }

        private void SetareOraNotificare_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                oraSetata.Text = SetareOraNotificare.Time.ToString();
            }
        }
        /*
                private async void ItemSelectedCRUD(object sender, SelectedItemChangedEventArgs e)
                {
                    if (e.SelectedItem != null)
                    {
                        LocalNotification localNotification = (LocalNotification)e.SelectedItem;
                        string action = await DisplayActionSheet("Optiuni", "Anulare", null, "Modifica", "Sterge");
                        switch (action)
                        {
                            case "Modifica":
                                if(localNotification !=null)
                                {
                                    localNotification.titlu = culturi.Denumire;
                                    localNotification.oraNotificare = DateTime.Parse(oraSetata.Text);
                                    await App.Database.UpdateNotificationAsync(localNotification);
                                    dataView.ItemsSource = await App.Database.GetNotificationAsync();
                                }
                                break;

                            case "Sterge":
                                if (localNotification != null)
                                {
                                    await App.Database.DeleteNotificationAsync(localNotification);
                                    dataView.ItemsSource = await App.Database.GetNotificationAsync();
                                    AlegeCultura.Title = "";
                                    SetareOraNotificare.Format = "";

                                }
                                break;
                        }
                    }
                }
        */

        private async void ButtonStergeElement_Clicked(object sender, EventArgs e)
        {
            if (localNotification != null)
            {
                await App.Database.DeleteNotificationAsync(localNotification);
                dataView.ItemsSource = await App.Database.GetNotificationAsync();
                AlegeCultura.Title = string.Empty;
                SetareOraNotificare.Format = string.Empty;
                MesajNotificare.Title = string.Empty;
                await DisplayAlert("Programul meu", "Elementul a fost sters", "OK");
            }
        }

        private void dataView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            localNotification = e.CurrentSelection[0] as LocalNotification;
        }

    }
}
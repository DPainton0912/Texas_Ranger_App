using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Texas_Ranger_App.Models;

namespace Texas_Ranger_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationEntryPage : ContentPage
    {
        public ReservationEntryPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var reservation = (Reservations)BindingContext;
            reservation.Timestamp = DateTime.UtcNow;
            await App.Database.SaveReservationAsync(reservation);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var reservation = (Reservations)BindingContext;
            await App.Database.DeleteReservationAsync(reservation);
            await Navigation.PopAsync();
        }
    }
}
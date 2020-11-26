using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Texas_Ranger_App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Texas_Ranger_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : TabbedPage
    {
        private string apiKey = "A9B8F488-3EAD-4F67-B2BB-05EADF44FBAE";

        public MainTabbedPage()
        {
            InitializeComponent();
            JokeLabel.BindingContext = GetJoke();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetReservationsAsync();
        }

        private Joke GetJoke()
        {
            Joke joke;

            var client = new RestClient("https://api.chucknorris.io/jokes/random");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);

            var response = client.Execute(request);

            joke = JsonConvert.DeserializeObject<Joke>(response.Content);

            return joke;
        }

        private async void OnReservationAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReservationEntryPage
            {
                BindingContext = new Reservations()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ReservationEntryPage
                {
                    BindingContext = e.SelectedItem as Reservations
                });
            }
        }

        private async void drinksButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DrinksMenuPage());
        }

        private async void foodButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodMenuPage());
        }
    }
}
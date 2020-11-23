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
            JokeLabel.BindingContext = GetJokes();
        }

        private Jokes GetJokes()
        {
            Jokes joke;

            var client = new RestClient("https://api.chucknorris.io/jokes/random");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);

            var response = client.Execute(request);

            joke = JsonConvert.DeserializeObject<Jokes>(response.Content);

            return joke;
        }
    }
}
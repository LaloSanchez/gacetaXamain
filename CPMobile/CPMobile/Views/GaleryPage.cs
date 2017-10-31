using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin;
using System.IO;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using Akavache.Internal;

using CPMobile.ViewModels;

namespace CPMobile.Views
{
    public class GaleryPage : ContentPage
    {
        GaleryViewModel GaleryViewModel;
        public GaleryPage()
        {
            GaleryViewModel = new GaleryViewModel();
            GaleryViewModel.GetCPFeedCommand.Execute(null);

            Padding = new Thickness(0);
            NavigationPage.SetHasNavigationBar(this, true);
            BackgroundColor = Color.White;

            string json = @"{
'totalCount': 2,
'status': 'success',
'data': [{
'idGaleria':'1',
'url_galeria':'http://images.fromupnorth.com/095/51ce77e5e6224.jpg',
'descripcion':'No hay nadie que ame el dolor mismo, que lo busque, lo encuentre y lo quiera, simplemente porque es el dolor',
'titulo':'Titulo 1'
},{
'idGaleria':'2',
'url_galeria':'http://wallpaper.pickywallpapers.com/1920x1080/hugh-laurie-classic-portrait.jpg',
'descripcion':'No hay nadie que ame el dolor mismo, que lo busque, lo encuentre y lo quiera, simplemente porque es el dolor',
'titulo':'Titulo 2'
},
{
'idGaleria':'3',
'url_galeria':'http://www.canvaz.com/portrait/charcoal-1.jpg',
'descripcion':'No hay nadie que ame el dolor mismo, que lo busque, lo encuentre y lo quiera, simplemente porque es el dolor',
'titulo':'Titulo 3'
},
{
'idGaleria':'4',
'url_galeria':'https://i.pinimg.com/originals/a7/8c/b8/a78cb88989d7213c37626a375dee5cb0.jpg',
'descripcion':'No hay nadie que ame el dolor mismo, que lo busque, lo encuentre y lo quiera, simplemente porque es el dolor',
'titulo':'Titulo 4'
},
{
'idGaleria':'5',
'url_galeria':'https://cdn.pixabay.com/photo/2014/10/30/17/32/boy-509488_960_720.jpg',
'descripcion':'No hay nadie que ame el dolor mismo, que lo busque, lo encuentre y lo quiera, simplemente porque es el dolor',
'titulo':'Titulo 5'
},
{
'idGaleria':'6',
'url_galeria':'http://www.telegraph.co.uk/content/dam/art/2017/07/11/TELEMMGLPICT000134302828_trans_NvBQzQNjv4Bq5AKy6kltchdyQ3tVtY_32bcN2I2SCFxPycrnuGFaoq0.jpeg',
'descripcion':'No hay nadie que ame el dolor mismo, que lo busque, lo encuentre y lo quiera, simplemente porque es el dolor',
'titulo':'Titulo 6'
}
]
}";



            /*List<string> developers = new List<string>();
            var data = JsonConvert.DeserializeObject<RootObject>(json);
            var stack = new StackLayout();
            stack.Padding = new Thickness(0, 0, 0, 0);
            stack.Spacing = 0;
            var profileTapRecognizer = new TapGestureRecognizer
            {
                TappedCallback = (v, o) => {
                    Debug.WriteLine("imagen Click");
                },
                NumberOfTapsRequired = 1
            };
            foreach (var orders in data.data)
            {
                var imagen = new Image
                {
                    Source = new UriImageSource
                    {
                        Uri = new Uri(orders.url_galeria),
                        CachingEnabled = true,
                        CacheValidity = new TimeSpan(7, 0, 0, 0)
                    },
                    //Source = orders.url_galeria,
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.End,
                };
                imagen.GestureRecognizers.Add(new TapGestureRecognizer{
                    TappedCallback = (v, o) => {
                        confirmarDescarga(orders.url_galeria);
                    },
                    NumberOfTapsRequired = 1
                });
                var labelTitulo = new Label
                {
                    Text = orders.titulo,
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                };
                var labelDescripcion = new Label
                {
                    Text = orders.descripcion,
                    FontSize = 10
                };
                stack.Children.Add(imagen);
                stack.Children.Add(labelTitulo);
                stack.Children.Add(labelDescripcion);
            }
            var scroll = new ScrollView { Content = stack };
            */
            var GeneralGaleryList = new ListView
            {
                HasUnevenRows = false,
                ItemTemplate = new DataTemplate(typeof(GaleryList)),
                ItemsSource = GaleryViewModel.Galery,
                BackgroundColor = Color.White
            };
            Content = new StackLayout
            {
                Spacing = 0,
                Children = { GeneralGaleryList }
            };
        }

        private async Task<long> DownloadFile(string url)
        {
            Debug.WriteLine("entro a la descarga");
            long receivedBytes = 0;
            long totalBytes = 0;
            HttpClient client = new HttpClient();

            using (var stream = await client.GetStreamAsync(url))
            {
                byte[] buffer = new byte[4096];
                totalBytes = stream.Length;

                for (;;)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        await Task.Yield();
                        break;
                    }

                    receivedBytes += bytesRead;

                    int received = unchecked((int)receivedBytes);
                    int total = unchecked((int)totalBytes);

                    double percentage = ((float)received) / total;

                    //progressBar1.Progress = percentage;
                }
            }

            return receivedBytes;
        }


        public async void confirmarDescarga(string liga)
        {
            var answerDescarga = await DisplayAlert("Descargar", "Deseas descargar la Imagen?", "Si", "No");
            if (answerDescarga)
            {
                Debug.WriteLine("dijo si");
                DownloadFile(liga);
            }
            else
            {
                Debug.WriteLine("dijo no");
            }
        }
    }
}

public class Datum
{
    public string idGaleria { get; set; }
    public string url_galeria { get; set; }
    public string descripcion { get; set; }
    public string titulo { get; set; }
}

public class RootObject
{
    public int totalCount { get; set; }
    public string status { get; set; }
    public List<Datum> data { get; set; }
}
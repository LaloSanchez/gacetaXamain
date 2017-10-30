using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using Xamarin;
using System.Net;
namespace CPMobile.Views
{
    public class GaleryPage : ContentPage
    {
        public GaleryPage()
        {
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



            List<string> developers = new List<string>();
            var data = JsonConvert.DeserializeObject<RootObject>(json);
            var stack = new StackLayout();
            stack.Padding = new Thickness(0, 0, 0, 0);
            stack.Spacing = 0;
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
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    imagen.Opacity = .5;
                };
                imagen.GestureRecognizers.Add(tapGestureRecognizer);
            }
            var scroll = new ScrollView { Content = stack };
            Content = new StackLayout
            {
                Spacing = 0,
                Children = { scroll }
            };


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
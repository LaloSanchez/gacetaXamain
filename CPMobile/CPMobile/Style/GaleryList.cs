using CPMobile.Service;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile
{
    public class GaleryList : ViewCell
    {
        public GaleryList()
        {
            var imagen = new Image
            {
                
                //Source = orders.url_galeria,
                //VerticalOptions = LayoutOptions.End,
                //HorizontalOptions = LayoutOptions.End,
            };
            imagen.SetBinding(Image.SourceProperty, "url_imagen");
            imagen.HeightRequest = 200;
            imagen.HorizontalOptions = LayoutOptions.FillAndExpand;
            var labelTitulo = new Label
            {
                XAlign = TextAlignment.Center,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };
            labelTitulo.SetBinding(Label.TextProperty, "titulo");
            var labelDescripcion = new Label
            {
                XAlign = TextAlignment.Center,
                FontAttributes = FontAttributes.Italic,
                FontSize = 10
            };
            labelDescripcion.SetBinding(Label.TextProperty, "descripcion");

            var ContentGalery = new StackLayout
            {
                Spacing = 0,
                HeightRequest=8000,
                Children = { imagen, labelTitulo, labelDescripcion }
            };
            var scroll = new ScrollView
            {
                Content = ContentGalery
            };

            this.View = ContentGalery;


            /*------ Creating Contact Action 1 Start --------//
            var moreAction = new MenuItem { Text = "Favorite" };
            moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            moreAction.Clicked += async (sender, e) => {
                await Task.Run(() => {
                    var mi = ((MenuItem)sender);

                    var favListItems = mi.CommandParameter as CPMobile.Models.Item;
                    FavoriteDataService.SaveListItems(favListItems);
                    //Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter as CPMobile.Models.Item);
                });
            };
            ContextActions.Add(moreAction);
            //var tapImage = new Image()
            //{
            //    Source = "tap.png",
            //    HorizontalOptions = LayoutOptions.End,
            //    HeightRequest = 12,
            //};

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { vetDetailsLayout }
            };

            this.View = cellLayout;*/
        }
    }
}
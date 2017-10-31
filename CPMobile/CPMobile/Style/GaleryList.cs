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
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
            };
            imagen.SetBinding(Image.SourceProperty, "url_imagen");
            var labelTitulo = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };
            labelTitulo.SetBinding(Label.TextProperty, "titulo");
            var labelDescripcion = new Label
            {
                FontSize = 10
            };
            labelDescripcion.SetBinding(Label.TextProperty, "descripcion");

            var ContentGalery = new StackLayout
            {
                Spacing = 0,
                HeightRequest=5000,
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
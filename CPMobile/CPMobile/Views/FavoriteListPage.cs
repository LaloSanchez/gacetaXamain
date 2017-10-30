using CPMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using CPMobile.Helper;

using Xamarin.Forms;

namespace CPMobile.Views
{
    public class FavoriteListPage : ContentPage
    {
        FavoriteListViewModel favViewModel;
        Dictionary<string, string> Gacetas = new Dictionary<string, string>
        {
            { "Gaceta 1", "http://dticursos.pjedomex.gob.mx/fianzas/archivos/recibosUnicos/358833.pdf" }, 
            { "Gaceta 2", "http://dticursos.pjedomex.gob.mx/fianzas/archivos/recibosUnicos/358833.pdf" },
            { "Gaceta3", "http://dticursos.pjedomex.gob.mx/fianzas/archivos/recibosUnicos/358833.pdf" }, 
            { "Gaceta 4", "http://dticursos.pjedomex.gob.mx/fianzas/archivos/recibosUnicos/358833.pdf" }
        };

        public FavoriteListPage()
        {
            Title = "Gacetas Anteriores";
            NavigationPage.SetHasNavigationBar(this, true);
            BindingContext = favViewModel = new FavoriteListViewModel(this);
            // favViewModel.GetFavoriteListCommand.Execute(null);

            Gacetas.Add("Gaceta 5", "http://dticursos.pjedomex.gob.mx/fianzas/archivos/recibosUnicos/358833.pdf");

            Image logo = new Image
            {
                Source = "icon.png",
                WidthRequest=500,
                HeightRequest=150
            };

            Label tituloSec = new Label
            {
                Text = "Seleccione gaceta a descargar",
                FontSize=18,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Picker picker = new Picker
           {
               Title = "Gacetas UAQ",
                VerticalOptions = LayoutOptions.Center
           };

            foreach (string GacetaAnterior in Gacetas.Keys)
            {
                picker.Items.Add(GacetaAnterior);
            }

            picker.SelectedIndexChanged += (sender, e) =>
            {
                //var favPage = new WebViewPage(selectedObject.titulo, selectedObject.websiteLink.HttpUrlFix());
                if (picker.SelectedIndex == -1)
                    {
                    }
                    else
                    {
                        //string colorName = picker.Items[picker.SelectedIndex];
                        //boxView.Color = nameToColor[colorName];
                    }
               
            };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = {logo,tituloSec, picker }
            };
            
            
            //MessagingCenter.Subscribe(this, "DeleteThis", async (string id) =>
            //{
            //    if (String.IsNullOrEmpty(id)) return;
            //    favViewModel.GetFavoriteListCommand.Execute(null); 
            //});
           // favlist.SetBinding(MenuItem.CommandProperty, favViewModel.DeleteItemCommand);

        }

        public void FilterLocations(ListView lv, string filter)
        {
            lv.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter))
            {
                lv.ItemsSource = favViewModel.FavList;
            }
            else
            {
                lv.ItemsSource = favViewModel.FavList
                        .Where(x => x.titulo.ToLower()
                            .Contains(filter.ToLower()));
            }
            lv.EndRefresh();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (favViewModel.FavList.Count > 0 || favViewModel.IsBusy)
                return;

            favViewModel.GetFavoriteListCommand.Execute(null); 
        }
    }
    
}

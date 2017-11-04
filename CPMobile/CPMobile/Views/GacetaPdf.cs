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
    public class GacetaPdf : ContentPage
    {
        GacetaPdfViewModel GacetaPdfViewModel;
        public GacetaPdf()
        {
            Title = "Gacetas Pdf";
            GacetaPdfViewModel = new GacetaPdfViewModel();
            GacetaPdfViewModel.GetCPFeedCommand.Execute(null);

            Padding = new Thickness(0);
            NavigationPage.SetHasNavigationBar(this, true);
            BackgroundColor = Color.White;
            var algo = new DataTemplate(typeof(GacetasAnteriores));
            var GeneralGaleryList = new ListView
            {
                HasUnevenRows = false,
                ItemTemplate = new DataTemplate(typeof(GacetasAnteriores)),
                ItemsSource = GacetaPdfViewModel.GacetaPdf,
                BackgroundColor = Color.White
            };
            var pick = new Picker
            {
            };
            //foreach(Models.GacetaPdf gaceta in GacetaPdfViewModel.GacetaPdf){
            //    pick.Items.Add(gaceta.titulo);
            //}

            GeneralGaleryList.RowHeight = 250;
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

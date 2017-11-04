using CPMobile.Service;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile
{
    public class GacetasAnteriores : ViewCell
    {
        public GacetasAnteriores()
        {
            var imagen = new Image
            {

                //Source = orders.url_galeria,
                //VerticalOptions = LayoutOptions.End,
                //HorizontalOptions = LayoutOptions.End,
            };
            imagen.SetBinding(Image.SourceProperty, "url_pdf");
            imagen.HeightRequest = 200;
            imagen.HorizontalOptions = LayoutOptions.FillAndExpand;
            var webview = new WebView {
                Source = new UrlWebViewSource
                {
                    Url = "http://189.211.201.181:75/pdfs/pdfs/G056.pdf",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //webview.SetBinding(WebView.SourceProperty,"url_pdf");
            //webview.Source = "http://189.211.201.181:75/pdfs/pdfs/G056.pdf";
            var labelTitulo = new Label
            {
                XAlign = TextAlignment.Center,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };
            labelTitulo.SetBinding(Label.TextProperty, "titulo");
            var picker = new Picker { Title="Gacetas" };
            picker.Items.Add("titulo");
            //pick.SetBinding(Picker.ItemSourceProperty,"titulo");
            var ContentGalery = new StackLayout
            {
                Spacing = 0,
                HeightRequest = 8000,
                Children = { webview, labelTitulo }
            };
            var scroll = new ScrollView
            {
                Content = ContentGalery
            };

            this.View = ContentGalery;


        }
    }
}
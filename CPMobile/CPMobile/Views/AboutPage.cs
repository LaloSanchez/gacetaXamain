using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPMobile.Views
{
    public class AboutPage: ContentPage
    {
        public static int fontSize = 14;
        public AboutPage()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            BackgroundColor = Color.White;

            Title = "Acerca de...";
            var Gaceta = new Label
            {
                Text = "Gaceta UAQ",
                BackgroundColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                XAlign = TextAlignment.Center,
                FontSize = 22,
                WidthRequest = 50,
                HeightRequest = 50
            };

            var Propietario = new Label
            {
                Text = "Propietario: Universidad Autónoma de Querétaro (www.uaq.mx)",
                BackgroundColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                XAlign = TextAlignment.Center,
                FontSize = 19,
                WidthRequest = 50,
                HeightRequest = 50
            };

            var Author = new Label
            {
                Text = "Desarrollado por: Andrade's Company S.A. de C.V. (andradescompany.com.mx)",
                BackgroundColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                XAlign = TextAlignment.Center,
                FontSize = 15,
                WidthRequest = 100,
                HeightRequest = 100
            };

            var Version = new Label
            {
                Text = "Version: 1.0.0.0",
                BackgroundColor = Color.White,
                FontSize = 15,
                XAlign = TextAlignment.Center,
                FontAttributes = FontAttributes.Italic,
                WidthRequest = 50,
                HeightRequest = 50
            };

            var Anio = new Label
            {
                Text = "Año: 2017",
                BackgroundColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                XAlign = TextAlignment.Center,
                FontSize = 15,
                WidthRequest = 50,
                HeightRequest = 50
            };
            var Actualizacion = new Label
            {
                Text = "Ultima actualización: 03 de noviembre del 2017",
                BackgroundColor = Color.White,
                FontAttributes = FontAttributes.Italic,
                XAlign = TextAlignment.Center,
                FontSize = 15,
                WidthRequest = 50,
                HeightRequest = 50
            };

            Content = new StackLayout
            {
                Padding = new Thickness(30, 30, 30, 0),
                Spacing = 12,
                Children = {Gaceta,Propietario, Version, Author  ,Anio,Actualizacion }
            };
        }
    }
}

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
        RelativeLayout relativeLayout;
        public AboutPage()
        {
            Padding = new Thickness(20);
            NavigationPage.SetHasNavigationBar(this, true);
            BackgroundColor = Color.White;


            var Author = new Label
            {
                Text = "Desarrollado por Andrade's Company",
                BackgroundColor = Color.White,
                //Font = Font.SystemFontOfSize(15),
                WidthRequest = 50,
                HeightRequest = 50
            };


            List<string> developers =new List<string>();
            developers.Add("Paoran Abascal Garcia");
            developers.Add("Yadira Villa Cruz");
            relativeLayout = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //foreach (String developer in developers)
            //{
                //Debug.WriteLine("found resource: " + developer);
                var Desarrollador1 = new Label
                {
                    Text = developers[0],
                    BackgroundColor = Color.White,
                    //Font = Font.SystemFontOfSize(30),
                    WidthRequest = 150,
                    HeightRequest = 50
                };
                //relativeLayout.Children.Add(Desarrollador1);
                //Debug.WriteLine("found resource: " + relativeLayout);
            //}

            Content = new StackLayout
            {
                Spacing = 10,
                Children = { Author,Desarrollador1 }
            };
        }
    }
}

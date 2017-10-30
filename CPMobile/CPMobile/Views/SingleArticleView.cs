using System;

using Xamarin.Forms;

namespace CPMobile.Views
{
    public class SingleArticleView : ContentPage
    {
        public SingleArticleView(CPMobile.Models.Item objArticle)
        {
            Content = new StackLayout
            {

                Children = {
                    new Image { Source = "http://tutrip.4hserver.com/images/img1.jpg"},//objArticle.url_imagen },
                    new Label { Text = objArticle.titulo,FontSize=14},
                    new Label {Text = objArticle.contenido,FontSize=10},
                }
            };
            var scroll = new ScrollView { Content = Content };
            Content = new StackLayout
            {
                Spacing = 0,
                Children = { scroll }
            };
        }

        protected override bool OnBackButtonPressed()
        {
            // If you want to continue going back
            base.OnBackButtonPressed();
            return false;

            //// If you want to stop the back button
            //return true;

        }
    }
}


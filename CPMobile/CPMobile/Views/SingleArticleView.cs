using System;

using Xamarin.Forms;

namespace CPMobile.Views
{
    public class SingleArticleView : ContentPage
    {
        public SingleArticleView(CPMobile.Models.Item objArticle)
        {
            Title = objArticle.titulo;
            var Texto = new StackLayout {
                Padding = new Thickness(20,5,20,0),
                Children = {
                    new Label { Text = objArticle.titulo,FontSize=16,XAlign = TextAlignment.Center},
                    new Label {Text = objArticle.contenido,FontSize=12}
                }
            };
            Content = new StackLayout
            {
                Children = {
                    new Image { Source = objArticle.url_imagen,VerticalOptions = LayoutOptions.Start},//objArticle.url_imagen },
                    Texto
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
            Navigation.InsertPageBefore(new RootPage(), this);
            Navigation.PopAsync();
            return false;

            //// If you want to stop the back button
            //return true;

        }
    }
}


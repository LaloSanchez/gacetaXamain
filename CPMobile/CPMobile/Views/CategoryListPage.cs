using CPMobile.ViewModels;
using Xamarin.Forms;
using CPMobile.Models;
using System.Diagnostics;

namespace CPMobile.Views
{
    public class CategoryListPage : ContentView
    {
        CategoryViewModel categoriaViewModel;
        public CategoryListPage()
        {
            categoriaViewModel = new CategoryViewModel();
            categoriaViewModel.GetCPFeedCommand.Execute(null);
            var activityIndicator = new ActivityIndicator
            {
                Color = Color.White,
            };
            activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            var genralArticlelist = new ListView
            {
                HasUnevenRows = false,
                ItemTemplate = new DataTemplate(typeof(CPListCell)),
                ItemsSource = categoriaViewModel.Categorias,
                BackgroundColor = Color.White,
                RowHeight = 120,
            };

            //vetlist.SetBinding<ArticlePageViewModel>();
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { genralArticlelist }
            };

            genralArticlelist.ItemSelected += (sender, e) =>
            {
                var selectedObject = e.SelectedItem as CPMobile.Models.Item;
                var SingleArticleView = new SingleArticleView(selectedObject);
                //var WebViewPage = new WebViewPage("General Articles",string.Format("http:{0}",selectedObject.websiteLink));
                Navigation.PushAsync(SingleArticleView);
                // Navigation.PushAsync( );
            };

        }


    }
}

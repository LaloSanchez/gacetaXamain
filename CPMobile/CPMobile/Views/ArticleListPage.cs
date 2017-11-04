using CPMobile.ViewModels;
using Xamarin.Forms;
using CPMobile.Models;
using System.Diagnostics;
using System;

namespace CPMobile.Views
{
    public class ArticleListPage:ContentView
    {
        ArticleViewModel articleViewModel;
        public ArticleListPage(int cveCategoria)
        {
            articleViewModel = new ArticleViewModel(cveCategoria);
           articleViewModel.GetCPFeedCommand.Execute(null);
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
                ItemsSource = articleViewModel.Articles,
                BackgroundColor = Color.White,
                RowHeight=120,
            };
           
            //vetlist.SetBinding<ArticlePageViewModel>();
             Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { genralArticlelist  }
            };

             genralArticlelist.ItemSelected += async (sender, e) =>
             {
                 var selectedObject = e.SelectedItem as CPMobile.Models.Item;
                 var SingleArticleView = new SingleArticleView(selectedObject);
                 //var WebViewPage = new WebViewPage("General Articles",string.Format("http:{0}",selectedObject.websiteLink));
                 var newPage = new ContentPage();
                 await Navigation.PushAsync(SingleArticleView);
                 
             };
           
        }

      
    }
}

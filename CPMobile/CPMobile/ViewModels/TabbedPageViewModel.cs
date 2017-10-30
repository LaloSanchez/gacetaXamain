using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using System;
using System.Threading;
using System.Threading.Tasks;
using CPMobile.Helper;
using System.Diagnostics;
using CPMobile.Models;
using System.Reactive.Linq;
using Xamarin.Forms;

namespace CPMobile.ViewModels
{
    public class TabbedPageViewModel : BaseViewModel
    {
        string baseUrl = "";
        ArticlePageViewModel articuloCatego;
        CategoryViewModel categoria;
        string ca;
        readonly ICPFeeds cpFeed;
        public TabbedPageViewModel()
        {


            // consulta de categorias

            // termina  categorias

            Title = "CodeProject";
            Icon = "icon.png";
            categoria = new CategoryViewModel();

             categoria.GetCPFeedCommand.Execute(null);
            var activityIndicator = new ActivityIndicator
            {
                Color = Color.White,
            };
            //activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            ca = categoria.jsonResp;
            try{
                foreach (var categ in ca)
                {
                    Debug.WriteLine("entro por" + categ);
                    //Debug.WriteLine(string.Join(",", }article));
                }
            }catch(Exception ex){
                Debug.WriteLine(ex);
            }


            var categos = new List<ICarouselViewModel> { };
            for (int i = 1;i<=4;i++){
                articuloCatego = new ArticlePageViewModel(i);
                articuloCatego.TabText = "Categoria"+i;  
                categos.Add(articuloCatego);
            }

            Pages = new List<ICarouselViewModel>
            {
            };

            Pages = categos;
        }

        private IEnumerable<ICarouselViewModel> _pages;

        public IEnumerable<ICarouselViewModel> Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                SetObservableProperty(ref _pages, value);
                CurrentPage = Pages.FirstOrDefault();
            }
        }

        private ICarouselViewModel _currentPage;

        public ICarouselViewModel CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                SetObservableProperty(ref _currentPage, value);
            }
        }
    }
}

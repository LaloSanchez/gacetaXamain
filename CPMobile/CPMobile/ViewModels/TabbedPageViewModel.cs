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
using CPMobile.ViewModels;

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

            Title = "";
            Icon = "icon.png";
            categoria = new CategoryViewModel();

             categoria.GetCPFeedCommand.Execute(null);

            var activityIndicator = new ActivityIndicator
            {
                Color = Color.White,
            };
            //while(true){
            //    var bo = categoria.IsBusy;
            //    if(!bo){
            //        break;
            //    }
            //}
            Boolean ocupa = categoria.IsBusy;
            //activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            ca = categoria.jsonResp;
            //while(true){
            //    if(!"isBusy"){
            //        break;
            //    }
            //}
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
                switch(i){
                    case 1:
                        articuloCatego.TabText = "COMUNIDAD";
                        break;
                    case 2:
                        articuloCatego.TabText = "CULTURA";
                        break;
                    case 3:
                        articuloCatego.TabText = "ACADEMIA";
                        break;
                    case 4:
                        articuloCatego.TabText = "DEPORTES";
                        break;

                }
                articuloCatego.TabIcon = "about.png";
                //articuloCatego.TabText = "Categoria"+i;  
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

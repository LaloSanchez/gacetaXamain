using System;
using CPMobile.Views;
using Xamarin.Forms;
using System.Diagnostics;

namespace CPMobile.ViewModels
{
    public class ArticlePageViewModel :ICarouselViewModel
    {
        public int cveCategoria;
        public ArticlePageViewModel(int cveCateg){
            cveCategoria = cveCateg;
        }

        public ContentView View
        {
            get { return new ArticleListPage(cveCategoria); }
        }


        public string TabText
            { get; set; }

        public string TabIcon
        {
            get; set;
        }
    }
}

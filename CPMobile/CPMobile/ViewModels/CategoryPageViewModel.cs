using System;
using CPMobile.Views;
using Xamarin.Forms;
using System.Diagnostics;

namespace CPMobile.ViewModels
{
    public class CategoryPageViewModel : ICarouselViewModel
    {
       
        public ContentView View
        {
            get { return new CategoryListPage(); }
        }


        public string TabText
        { get; set; }

        public string TabIcon
        {
            get
            {
                return "article.png";
            }
        }
    }
}

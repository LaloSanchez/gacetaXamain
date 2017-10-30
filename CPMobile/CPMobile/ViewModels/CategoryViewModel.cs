using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Reactive.Linq;
using CPMobile.Models;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace CPMobile.ViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        readonly ICPFeeds cpFeed;

        public List<Categoria> Categorias { get; set; }
        public string jsonResp { set; get; }
        public CategoryViewModel()
        {
            cpFeed = DependencyService.Get<ICPFeeds>();
            Categorias = new List<Categoria>();
            string jsonResp ;

        }

        public void CallInit()
        {
            ExecuteInit();
        }

        private async Task ExecuteInit()
        {
            //await cpFeed.Init();
        }

        private Command getCPFeedCommand;
        public Command GetCPFeedCommand
        {
            get
            {
                return  (getCPFeedCommand = new Command(async () => await ExecuteGetCPFeedCommand()));
            }
        }



        public async Task ExecuteGetCPFeedCommand()
        {
           
            //GetCPFeedCommand.ChangeCanExecute();
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var cat = await cpFeed.GetCategorias();
                jsonResp = cat;
                //Debug.WriteLine(categos.Categos);
                //foreach (var categoria in categos.Categos)
                //{
                //    Debug.WriteLine(categoria);
                //    Categorias.Add(categoria);

                //}
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

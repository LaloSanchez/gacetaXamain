using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Reactive.Linq;
using CPMobile.Models;
using Xamarin.Forms;
using System.Diagnostics;
using Akavache;

namespace CPMobile.ViewModels
{
    public class ArticleViewModel:BaseViewModel
    {
        readonly ICPFeeds cpFeed;
        public int cveCateg;

        public ObservableCollection<Item> Articles { get; set; }
        public ArticleViewModel(int cveCategoria)
        {
            cpFeed = DependencyService.Get<ICPFeeds>();
            Title = "CodeProject";
            Icon = "icon.png";
            cveCateg = cveCategoria;
            Articles = new ObservableCollection<Item>();

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
                return getCPFeedCommand ??
                    (getCPFeedCommand = new Command(async () => await ExecuteGetCPFeedCommand(cveCateg), () => { return !IsBusy; }));
            }
        }



        private async Task ExecuteGetCPFeedCommand(int cveCategoria)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            //GetCPFeedCommand.ChangeCanExecute();

            try
            {
                var articles =await cpFeed.GetArticleAsync(1, cveCategoria);
                //BlobCache.LocalMachine.GetOrFetchObject<CPFeed>("DefaultArticle",
                                                                //async () => await cpFeed.GetArticleAsync(1, cveCategoria),
                                                                                        //    DateTimeOffset.Now.AddDays(0)
                                                                                        //);

                Debug.WriteLine(articles);
                foreach (var article in articles.items)
                {
                    Debug.WriteLine(article.titulo);
                    //Debug.WriteLine(string.Join(",", article));
                    Articles.Add(article);
                }
                IsBusy = false;
            }
            catch(Exception ex)
            {

            }
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Reactive.Linq;
using CPMobile.Models;
using Xamarin.Forms;
using Akavache;
using System.Diagnostics;

namespace CPMobile.ViewModels
{
    public class GacetaPdfViewModel : BaseViewModel
    {
        readonly ICPFeeds cpFeed;

        public ObservableCollection<GacetaPdf> GacetaPdf { get; set; }
        public GacetaPdfViewModel()
        {
            cpFeed = DependencyService.Get<ICPFeeds>();
            Title = "CodeProject";
            Icon = "icon.png";
            GacetaPdf = new ObservableCollection<GacetaPdf>();
        }


        private Command getCPFeedCommand;
        public Command GetCPFeedCommand
        {
            get
            {
                return getCPFeedCommand ??
                    (getCPFeedCommand = new Command(async () => await ExecuteGetCPFeedCommand(), () => { return !IsBusy; }));
            }
        }



        private async Task ExecuteGetCPFeedCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            //GetCPFeedCommand.ChangeCanExecute();

            try
            {

                var galeria = await cpFeed.GetGacetaPdfAsync();
                Debug.WriteLine(galeria);
                foreach (var gale in galeria.itemsGacetasPdf)
                {
                    GacetaPdf.Add(gale);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
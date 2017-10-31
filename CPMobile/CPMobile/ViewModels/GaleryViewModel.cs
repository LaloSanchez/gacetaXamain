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
    public class GaleryViewModel : BaseViewModel
    {
        readonly ICPFeeds cpFeed;

        public ObservableCollection<Galery> Galery { get; set; }
        public GaleryViewModel()
        {
            cpFeed = DependencyService.Get<ICPFeeds>();
            Title = "CodeProject";
            Icon = "icon.png";
            Galery = new ObservableCollection<Galery>();
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

                var galeria = await cpFeed.GetGaleryAsync();
                Debug.WriteLine(galeria);
                foreach (var gale in galeria.itemsGalery)
                {
                    Galery.Add(gale);
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
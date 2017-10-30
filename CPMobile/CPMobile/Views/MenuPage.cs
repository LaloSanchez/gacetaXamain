using Xamarin.Forms;
using CPMobile.Helper;

namespace CPMobile.Views
{
    public class MenuTableView :TableView
    {

    }
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; set; }
        RootPage rootPage;
        TableView tableView;

        public MenuPage(RootPage rootPage)
        {
            Icon = "menu.png";
            Title = "menu"; // The Title property must be set.

            this.rootPage = rootPage;

            //var logoutButton = new Button { Text = "Salir", TextColor=Color.White };
            //logoutButton.Clicked += (sender, e) =>
            //{
            //    Settings.AuthLoginToken = "";
                
            //    Navigation.PushModalAsync(new LoginPage());

            //    //Special Handel for Android Back button
            //    if (Device.OS == TargetPlatform.Android)
            //    Application.Current.MainPage = new LoginPage();
            //};
            var layout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#04468d"),
            };
            var section = new TableSection()
            {
                new MenuCell {Text = "Gaceta UAQ",Host= this,ImageSrc="icon.png"},
                new MenuCell {Text = "Inicio",Host= this,ImageSrc="home_black.png"},
                new MenuCell {Text = "Galeria",Host= this,ImageSrc="star_black.png"},
                new MenuCell {Text = "Anteriores",Host= this,ImageSrc="home_black.png"},
                new MenuCell {Text = "Acerca de",Host= this,ImageSrc="about_black.png"},
            };
            
            var root = new TableRoot() { section };

            tableView = new MenuTableView()
            {
                Root = root,
                Intent = TableIntent.Data,
                //BackgroundColor = Color.FromHex("2C3E50"),
                BackgroundColor = Color.White,

            };

            //var settingView = new SettingsUserView();

            //settingView.tapped += (object sender, TapViewEventHandler e) =>
            //{

            //    Navigation.PushAsync(new Profile());
            //    // var home = new NavigationPage(new Profile());
            //    // rootPage.Detail = home;
            //};

            //layout.Children.Add(settingView);
            //layout.Children.Add(new BoxView()
            //{
            //    HeightRequest = 1,
            //    BackgroundColor = AppStyle.DarkLabelColor,
            //});
            layout.Children.Add(tableView);
            //layout.Children.Add(logoutButton);

            Content = layout;

            //var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped +=
            //    (sender, e) =>
            //    {
            //        NavigationPage profile = new NavigationPage(new Profile(settingView.profileViewModel.myProfile)) { BarBackgroundColor = App.BrandColor,BarTextColor = Color.White };
            //        rootPage.Detail = profile;
            //        rootPage.IsPresented = false;
            //    };
            //settingView.GestureRecognizers.Add(tapGestureRecognizer);
 
        }

        NavigationPage home, galery,About, favorites;
        public void Selected(string item)
        {

            switch (item)
            {
                case "Inicio":
                    if (home == null)
                        home = new NavigationPage(new MainListPage()) { BarBackgroundColor = App.BrandColor, BarTextColor = Color.White };
                    rootPage.Detail = home;
                    break;
                case "Galeria":
                    if (galery == null)
                        galery = new NavigationPage(new GaleryPage()) { BarBackgroundColor = App.BrandColor, BarTextColor = Color.White };
                    rootPage.Detail = galery;
                    break;
                case "Anteriores":
                    favorites = new NavigationPage(new FavoriteListPage()) { BarBackgroundColor = App.BrandColor, BarTextColor = Color.White };
                    rootPage.Detail = favorites;
                    break;
                case "Acerca de":
                    About = new NavigationPage(new AboutPage()) { BarBackgroundColor = App.BrandColor, BarTextColor = Color.White };
                    rootPage.Detail = About;
                    break;
            };
            rootPage.IsPresented = false;  // close the slide-out
        }

    }

    
}

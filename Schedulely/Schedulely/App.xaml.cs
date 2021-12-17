using Xamarin.Forms;
using Schedulely.ViewModels;
using Schedulely.Views;
using Schedulely.Services;

namespace Schedulely
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            MainPage = new NavigationPage(new OverviewPage());
            DependencyService.Register<MeetingDataStore>();
            DependencyService.Register<GroupDataStore>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

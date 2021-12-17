using System;
using Xamarin.Forms;
using Schedulely.Views;

namespace Schedulely
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
              Routing.RegisterRoute(nameof(AddNewMeetingPage), typeof(AddNewMeetingPage));
              Routing.RegisterRoute(nameof(OverviewPage), typeof(OverviewPage));
              Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//OverviewPage");
        }
    }
}

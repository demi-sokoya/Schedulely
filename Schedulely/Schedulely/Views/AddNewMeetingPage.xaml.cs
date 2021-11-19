using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedulely.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewMeetingPage : ContentPage
    {
        public AddNewMeetingPage()
        {
            InitializeComponent();
        }

        //public OnSaveClicked()
        //{
        //    return;
        //}

        private void Editor_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}
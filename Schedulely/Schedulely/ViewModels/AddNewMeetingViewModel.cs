using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;
using Schedulely.Models;
using static Schedulely.Models.Meeting;

namespace Schedulely.ViewModels
{
    class AddNewMeetingViewModel : ViewModelBase
    {
        
        public string MeetingTitle { get; set; }
        public Group ChosenGroup { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string> Participants { get; set; }

        public AsyncCommand AddCommand { get; }
        public AsyncCommand RefreshCommand { get; }

        //TimePicker startTime = new TimePicker
        //{
        //    Time = new TimeSpan(DateTime.Now.Hour, (DateTime.Now.Minute < 15) ? 0 : (DateTime.Now.Minute > 45) ? 00 : 30, 0)

        //};
        public AddNewMeetingViewModel()
        {
            Groups = new MvvmHelpers.ObservableRangeCollection<Group>();

            //setting the default values fro when the page loads
            MeetingTitle = "New Meeting";
            ChosenGroup = null;
            Date = DateTime.Now;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            Participants = new List<string>();
            AddCommand = new AsyncCommand(Add);
            RefreshCommand = new AsyncCommand(Refresh);
            Load();
        }

        public async void Load()
        {
            IEnumerable<Group> groups = await GroupDataStore.GetGroups();
            Groups.AddRange(groups);
        }

        async Task Add()
        {
            var newMeeting = new Meeting { Title = MeetingTitle, Date = Date, StartTime = StartTime, EndTime = EndTime, Participants = Participants, ChosenGroup = ChosenGroup};
            await MeetingDataStore.AddMeeting(newMeeting);

            //Break just below this line to see a list of all meetings.
            IEnumerable<Meeting> meetings = await MeetingDataStore.GetMeetings();

        }


        public async void RefreshLoad()
        {
            IEnumerable<Group> groups = await GroupDataStore.GetGroups();
            Groups.AddRange(groups);


        }

        private async Task Refresh()
        {
            IsBusy = true;

            Groups.Clear();
            RefreshLoad();

            IsBusy = false;
        }


    }
}

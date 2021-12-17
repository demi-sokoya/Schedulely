using MvvmHelpers;
using Schedulely.Models;
using Schedulely.Services;
using Xamarin.Forms;

namespace Schedulely.ViewModels
{
    class ViewModelBase : BaseViewModel
    {
        public IMeetingDataStore<Meeting> MeetingDataStore => DependencyService.Get<IMeetingDataStore<Meeting>>();

        public IGroupDataStore<Group> GroupDataStore => DependencyService.Get<IGroupDataStore<Group>>();

        private ObservableRangeCollection<Group> _Groups;
        public ObservableRangeCollection<Group> Groups
        {
            get { return _Groups; }
            set
            {
                _Groups = value;
                OnPropertyChanged();
            }
        }

    }

}

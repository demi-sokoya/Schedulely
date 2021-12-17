using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.ObjectModel;
using Schedulely.Models;
using static Schedulely.Models.Group;

namespace Schedulely.ViewModels
{
    class GroupViewModel : ViewModelBase
    {


        public Group SelectedGroup { get; set; }

        public string GroupName { get; set; }
        public string GroupColor { get; set; }

        public AsyncCommand AddCommand { get; }
        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand RemoveCommand { get; }



        public GroupViewModel()
        {
            Groups = new MvvmHelpers.ObservableRangeCollection<Group>();
            AddCommand = new AsyncCommand(Add);
            Load();
            RefreshCommand = new AsyncCommand(Refresh);
            RemoveCommand = new AsyncCommand(Remove);


        }

        public async void Load()
        {
            IEnumerable<Group> categories = await GroupDataStore.GetGroups();
            Groups.AddRange(categories);
        }

        async Task Add()
        { 
           if (GroupName.Length > 0)
            {
                var newGroup = new Group { GroupName = GroupName, Color = GroupColor };
                await GroupDataStore.AddGroup(newGroup);

                IEnumerable<Group> groups = await GroupDataStore.GetGroups();

                Refresh();
            }
            
          
            


            
        }

        async Task Remove()
        {
            Groups.Remove(SelectedGroup);
            await GroupDataStore.RemoveGroup(SelectedGroup);
        }

        private async Task Refresh()
        {
            IsBusy = true;

            Groups.Clear();
            Load();

            IsBusy = false;
        }


        }
    }
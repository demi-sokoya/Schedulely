using System;
using System.Collections.Generic;
using System.Text;
using Schedulely.Models;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Schedulely.Services
{
    class GroupDataStore : IGroupDataStore<Group>
    {
        public static string FilePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "Groups.json");
            }
        }

        private List<Group> ReadFile()
        {
            File.Delete(FilePath);
            try
            {
                var jsonString = File.ReadAllText(FilePath);

                var groups = JsonConvert.DeserializeObject<List<Group>>(jsonString);

                return groups;
            }
            catch (Exception e)
            {
                var defaultGroups = GetDefaultGroups();

                WriteFile(defaultGroups);

                return defaultGroups;
            }
        }

        private List<Group> GetDefaultGroups()
        {
            var groups = new List<Group>()
            {
                new Group() { GroupId = 1, GroupName = "Test Group 1", Color = "#00FFFF" },
                new Group() { GroupId = 2, GroupName = "Test Group 2", Color = "#00FF0" },
                new Group { GroupId = 1, GroupName = "Test Group 3", Color ="#FF0000" }
            };

            return groups;
        }

        private void WriteFile(List<Group> groups)
        {
            var jsonString = JsonConvert.SerializeObject(groups);

            File.WriteAllText(FilePath, jsonString);
        }

        public async Task<Group> GetGroup(int groupId)
        {
            var groups = ReadFile();

            var Group = groups.Find(p => p.GroupId == groupId);

            return Group;
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            var groups = ReadFile();

            return groups;
        }

        public async Task UpdateGroup(Group group)
        {
            var groups = ReadFile();
            groups[groups.FindIndex(p => p.GroupId == group.GroupId)] = group;

            WriteFile(groups);
        }

        public async Task AddGroup(Group group)
        {
            var groups = ReadFile();
            groups.Add(group);

            WriteFile(groups);
        }
    }
}

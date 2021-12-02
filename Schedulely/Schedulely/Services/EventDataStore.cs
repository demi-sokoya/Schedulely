using Newtonsoft.Json;
using Schedulely.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Schedulely.Services
{
    class MeetingDataStore : IMeetingDataStore<Meeting>
    {
        public static string FilePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "Meetings.json");
            }
        }

        private List<Meeting> ReadFile()
        {
            File.Delete(FilePath);
            try
            {
                var jsonString = File.ReadAllText(FilePath);

                var Meetings = JsonConvert.DeserializeObject<List<Meeting>>(jsonString);

                return Meetings;
            }
            catch (Exception e)
            {
                var defaultMeetings = GetDefaultMeetings();

                WriteFile(defaultMeetings);

                return defaultMeetings;
            }
        }

        private List<Meeting> GetDefaultMeetings()
        {
            var Meetings = new List<Meeting>()
            {
                //new Meeting { Id = 1, Name = "Meeting A Local Json File", Description = "This is Meeting a." },
                //new Meeting { Id = 2, Name = "Meeting B Local Json File", Description = "This is Meeting b." },
                //new Meeting { Id = 3, Name = "Meeting C Local Json File", Description = "This is Meeting c." },
                //new Meeting { Id = 4, Name = "Meeting D Local Json File", Description = "This is Meeting d." }

                //new Meeting { Id = 1, Amount = 60, Date = DateTime.Now, Recurring = false, Notes = "Dummy entry", Type = Meeting.MeetingType.Expense}
            };

            return Meetings;
        }

        private void WriteFile(List<Meeting> Meetings)
        {
            var jsonString = JsonConvert.SerializeObject(Meetings);

            File.WriteAllText(FilePath, jsonString);
        }

        public async Task<Meeting> GetMeeting(int MeetingId)
        {
            var Meetings = ReadFile();

            var Meeting = Meetings.Find(p => p.Id == MeetingId);

            return Meeting;
        }

        public async Task<IEnumerable<Meeting>> GetMeetings()
        {
            var Meetings = ReadFile();

            return Meetings;
        }

        public async Task UpdateMeeting(Meeting Meeting)
        {
            var Meetings = ReadFile();
            Meetings[Meetings.FindIndex(p => p.Id == Meeting.Id)] = Meeting;

            WriteFile(Meetings);
        }

        public async Task AddMeeting(Meeting Meeting)
        {
            var Meetings = ReadFile();
            Meetings.Add(Meeting);

            WriteFile(Meetings);
        }
    }
}


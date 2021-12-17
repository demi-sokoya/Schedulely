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
                var filePath =  Path.Combine(basePath, "Meetings.json");
                if (!File.Exists(filePath)) {
                    

                    
                        using (var tw = new StreamWriter(filePath, true))
                        {
                            tw.WriteLine("");
                        }

                    
                }
                return filePath;
                
            }
        }

        private List<Meeting> ReadFile()
        {
            
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
                new Meeting { Id= 1, Title = "New Meeting"}
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


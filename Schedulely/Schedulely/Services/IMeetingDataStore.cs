using System;
using System.Collections.Generic;
using System.Text;
using Schedulely.Models;
using System.Threading.Tasks;


namespace Schedulely.Services
{

    public interface IMeetingDataStore<T>
    {
        Task<IEnumerable<Meeting>> GetMeetings();
            Task<Meeting> GetMeeting(int meetingId);
            Task AddMeeting(Meeting meeting);
            Task UpdateMeeting(Meeting meeting);
    }
}
        


using System;
using System.Collections.Generic;
using System.Text;

namespace Schedulely.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Group> GroupId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set;  }
        public List<string> Participants { get; set; }
    }
}

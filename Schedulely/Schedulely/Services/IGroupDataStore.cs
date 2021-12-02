using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Schedulely.Models;

namespace Schedulely.Services
{
    public interface IGroupDataStore<T>
    {
        Task<IEnumerable<Group>> GetGroups();
        Task<Group> GetGroup(int groupId);
        Task AddGroup(Group group);
        Task UpdateGroup(Group group);
    }
}

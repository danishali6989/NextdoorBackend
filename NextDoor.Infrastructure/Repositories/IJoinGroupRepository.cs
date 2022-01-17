using NextDoor.Entities;
using NextDoor.Models.Group;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Repositories
{
    public interface IJoinGroupRepository
    {
        Task AddJoinGroupAsync(JoinGroup entity);
    }
}

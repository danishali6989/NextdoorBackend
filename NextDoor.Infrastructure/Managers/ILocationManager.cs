using NextDoor.Models.Location;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface ILocationManager
    {
        Task AddAsync(AddLocationModel model); 
    }
}

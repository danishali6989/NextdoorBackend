using NextDoor.Models.MasterCre;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface IMasterCredentialManager
    {
        Task AddAsync(AddMasterModel model);
    }
}

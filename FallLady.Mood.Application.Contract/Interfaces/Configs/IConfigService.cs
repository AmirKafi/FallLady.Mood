using FallLady.Mood.Application.Contract.Dto.Configs;
using FallLady.Mood.Application.Contract.Dto.Teacher;
using FallLady.Mood.Utility.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Interfaces.Configs
{
    public interface IConfigService
    {
        Task<ServiceResponse<bool>> SaveConfig(ConfigSaveDto dto);
        Task<ServiceResponse<ConfigDto>> GetConfig();
    }
}

using FallLady.Mood.Application.Contract.Dto.Configs;
using FallLady.Mood.Application.Contract.Interfaces.Configs;
using FallLady.Mood.Application.Contract.Mappers.Configs;
using FallLady.Mood.Domain.Domain.Configs;
using FallLady.Mood.Utility.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Services.Configs
{
    public class ConfigService : IConfigService
    {
        #region Constructor

        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        #endregion
        public async Task<ServiceResponse<ConfigDto>> GetConfig()
        {
            var result = new ServiceResponse<ConfigDto>();

            try
            {
                var config = _configRepository.GetQuerable().AsNoTracking()
                                              .FirstOrDefault();
                result.SetData(config.ToDto());
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }

        public async Task<ServiceResponse<bool>> SaveConfig(ConfigSaveDto dto)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var config = _configRepository.GetQuerable().AsNoTracking();

                if (config.Count() != 0)
                {
                    await _configRepository.Update(dto.ToModel());
                    result.SetData(true);
                }
                else
                {
                    await _configRepository.Add(dto.ToModel());
                    result.SetData(true);
                }
            }
            catch (Exception ex)
            {
                result.SetException(ex);
            }

            return result;
        }
    }
}

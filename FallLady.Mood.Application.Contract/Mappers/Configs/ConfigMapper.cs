using FallLady.Mood.Application.Contract.Dto.Configs;
using FallLady.Mood.Domain.Domain.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Mood.Application.Contract.Mappers.Configs
{
    public static class ConfigMapper
    {
        public static Config ToModel(this ConfigSaveDto dto)
        {
            return new Config(dto.Email,
                              dto.Address,
                              dto.ContactNumber);
        }

        public static ConfigDto ToDto(this Config? model)
        {
            if(model == null)
                throw new ArgumentNullException("عملیات با خطا مواجه شد");

            return new ConfigDto()
            {
                Address= model.Address,
                Email= model.Email,
                ContactNumber = model.ContactNumber
            };
        }
    }
}

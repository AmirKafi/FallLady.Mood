using FallLady.Mood.Domain.Domain.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallLady.Persistance.Repositories.Configs
{
    public class ConfigRepository:CrudRepository<Config,int>,IConfigRepository
    {
    }
}

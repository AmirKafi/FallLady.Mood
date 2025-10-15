using Autofac;
using FallLady.Mood.Config;
using FallLady.Mood.Utility.Extentions;
using FallLady.Persistance;
using System.ComponentModel;

namespace FallLady.Mood
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Bootstrapper.WireUp(builder);
        }
    }
}

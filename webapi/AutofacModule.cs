using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.DAL;

namespace webapi
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DataAccess())
                .As<IDataAccess>()
                .InstancePerLifetimeScope();
        }
    }
}

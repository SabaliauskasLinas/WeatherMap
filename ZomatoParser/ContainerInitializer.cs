using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoParser
{
    public static class ContainerInitializer
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            return builder.Build();
        }
    }
}

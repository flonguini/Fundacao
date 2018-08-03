using Autofac;
using Fundacao.Models;
using System.Linq;
using System.Reflection;

namespace Fundacao
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<GeometriaModel>().As<IGeometriaModel>(); //Registra a interface IGeometriaModel como GeometriaModel

            //Registra a partir de uma pasta
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(Fundacao)))
                .Where(t => t.Namespace.Contains("Models"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}

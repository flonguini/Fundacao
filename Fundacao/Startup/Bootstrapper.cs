using Autofac;
using Autofac.Core;
using Fundacao.ViewModels;
using Fundacao.Views;
using SapataLibrary.Model;
using System;
using System.Linq;
using System.Reflection;

namespace Fundacao.Startup
{
    public static class Bootstrapper
    {
        private static IContainer _container;
        
        //public IContainer Bootstrap()
        //{
            

        //    //builder.RegisterAssemblyTypes(Assembly.Load(nameof(SapataLibrary)))
        //    //    .Where(t => t.Namespace.Contains("Model"))
        //    //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

        //    return builder.Build();
        //}

        public static void Start()
        {
            if (_container != null)
                return;

            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<GeometriaModel>().As<IGeometriaModel>();
            //builder.RegisterType<SapataModel>().As<ISapataModel>();
            builder.RegisterType<SapataModel>().As<ISapataModel>().WithParameter(new TypedParameter(typeof(DadosEntradaModel), null));
            builder.RegisterType<DadosEntradaModel>().As<IDadosEntradaModel>();
            builder.RegisterType<SapataViewModel>().As<ISapataViewModel>();

            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            if (_container == null)
            {
                throw new Exception("Bootstrapper hasn't been started!");
            }

            return _container.Resolve<T>(new Parameter[0]);
        }

    }
}

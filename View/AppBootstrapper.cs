using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using Model.Services;
using SimpleInjector;
using View;
using View.ViewModels;

namespace View
{
    internal class AppBootstrapper : BootstrapperBase
    {
        public static readonly Container ContainerInstance = new Container();
        public AppBootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            ContainerInstance.Register<IWindowManager, WindowManager>();
            ContainerInstance.RegisterSingleton<IEventAggregator, EventAggregator>();
            ContainerInstance.Register<MainWindowViewModel, MainWindowViewModel>();
            ContainerInstance.Verify();
        }
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
        IServiceProvider provider = ContainerInstance;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }
        protected override object GetInstance(System.Type service, string key)
        {
            return ContainerInstance.GetInstance(service);
        }
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
            Assembly.GetExecutingAssembly()
        };
        }
        protected override void BuildUp(object instance)
        {
            var registration = ContainerInstance.GetRegistration(instance.GetType(), true);
            registration.Registration.InitializeInstance(instance);
        }
    }
}
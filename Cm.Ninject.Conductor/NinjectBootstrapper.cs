using System;
using System.Collections.Generic;

namespace Cm.Ninject.Conductor
{
    using Caliburn.Micro;
    using global::Ninject;
    using global::Ninject.Modules;
    using System.Windows;

    public class NinjectBootstrapper : BootstrapperBase
    {
        private static readonly IKernel Kernel = new StandardKernel();
        public NinjectBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            Kernel.Load(new BindingsModuleWpf());
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            var windowManager = Kernel.Get<IWindowManager>();
            DisplayRootViewFor<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            return Kernel.Get(service);
        }

        public static T GetInstance<T>()
        {
            return (T) Kernel.Get(typeof(T));
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            Kernel.Inject(instance);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            //System.Windows.MessageBox.Show("Bye Bye");
            Kernel.Dispose();
            base.OnExit(sender, e);
        }
    }

    public class BindingsModuleWpf : NinjectModule
    {
        public override void Load()
        {
            if (Kernel != null)
            {
                Kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
                Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            }
        }
    }
}

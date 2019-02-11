
using System;
using Ninject;

namespace ChatApp.Core
{
    public static class IoC
    {
        //IoC container kernel
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        /// <summary>
        /// IoC container setup, which binds alll information required.
        /// It must be called upon application startup to ensure all service can be found
        /// </summary>
        public static void Setup()
        {
            // bind all required viewmodels

            BindViewModels();
        }

        private static void BindViewModels()
        {
            // binding a single instance of application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}

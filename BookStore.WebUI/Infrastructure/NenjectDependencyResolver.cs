 
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookStore.BookStore.Domain.Entities;



namespace AS_MVC.Infrastructure
{
    public class NenjectDependencyResolver : IDependencyResolver
    {

        private IKernel Kernel;

        public NenjectDependencyResolver(IKernel KernelParam)
        {
            Kernel = KernelParam;
            AddBindings();
        }


        private void AddBindings()
        {
            Kernel.Bind<IBookRepository>().To<book>();
            //Kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam",50m) ;
            //Kernel.Bind<IDiscountHelper>().To<FlexableDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();


        }







        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}
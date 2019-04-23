 
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.Domain.Concrete;
using System.Configuration;

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

           // EmailSettings emailSettings = new EmailSettings
          //  {WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"]?? "false") };


            Kernel.Bind<IBookRepository>().To<EFBookRepository>();
            Kernel.Bind<IOrderProcessor>().To<SendEmail>();




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
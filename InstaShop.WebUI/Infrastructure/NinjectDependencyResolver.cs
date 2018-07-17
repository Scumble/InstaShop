using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using Ninject;
using InstaShop.Domain.Abstract;
using InstaShop.Domain.Entities;
using InstaShop.Domain.Concrete;
using System.Web.Mvc;

namespace InstaShop.WebUI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IClothesRepository>().To<EFItemRepository>(); ;
        }
    }
}

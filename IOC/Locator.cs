using DAL.UnitOfWork;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IOC
{
    public static class Locator 
    {
        public static UnityContainer UnityContainer = new UnityContainer();
        public static void CreateLocator()
        {            
            UnityContainer.RegisterType<IUserServices, UserServices>();
            UnityContainer.RegisterType<ITSMUnitOfWork, TSMUnitOfWork>();
        }
        public static T GetT<T>()
        {
            return UnityContainer.Resolve<T>();
        }
    }
}

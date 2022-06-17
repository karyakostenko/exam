using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using BusinessLogic.BuisnessLogic;
using BusinessLogic.Interfaces;
using DatabaseImplements.Implements;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<Form1>());
        }

        private static IUnityContainer BuildUnityContainer()  // IoC контейнер или (юнити контейнер)
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IMarketStorage, MarketStorage>(new HierarchicalLifetimeManager()); // реализация магазина IMarketStorage какой зависимости, MarketStorage какую реализацию подставлять
            currentContainer.RegisterType<IGoodsStorage, GoodsStorage>(new HierarchicalLifetimeManager()); // реализация товаров
            currentContainer.RegisterType<GoodsLogic>(new HierarchicalLifetimeManager());  //для перачи методов 
            currentContainer.RegisterType<MarketLogic>(new HierarchicalLifetimeManager()); //для перачи методов 

            return currentContainer;
        }
    }
}

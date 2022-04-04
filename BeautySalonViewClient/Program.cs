using System;
using BeautySalonBusinessLogic.BusinessLogics;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.StoragesContracts;
using BeautySalonDatabaseImplement.Implements;
using BeautySalonBusinessLogic.OfficePackage;
using BeautySalonBusinessLogic.OfficePackage.Implements;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using BeautySalonContracts.ViewModels;

namespace BeautySalonViewClient
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static ClientViewModel Client;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormInitial>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICosmeticStorage, CosmeticStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDistributionStorage, DistributionStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProcedureStorage, ProcedureStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseStorage, PurchaseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReceiptStorage, ReceiptStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IVisitStorage, VisitStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICosmeticLogic, CosmeticLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDistributionLogic, DistributionLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeLogic, EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProcedureLogic, ProcedureLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseLogic, PurchaseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReceiptLogic, ReceiptLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IVisitLogic, VisitLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<IPlaneLogic, PlaneLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<IReportLogic, ReportLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}

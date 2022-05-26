using BeautySalonBusinessLogic.BusinessLogics;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.StoragesContracts;
using BeautySalonDatabaseImplement.Implements;
using System;
using System.Configuration;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IUnityContainer container = null;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            /*
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
            }); */

            var mainWindow = Container.Resolve<WindowInital>();
            mainWindow.Show();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICosmeticStorage, CosmeticStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDistributionStorage, DistributionStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReceiptStorage, ReceiptStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IVisitStorage, VisitStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseStorage, PurchaseStorage>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<IReportStorage, ReportStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ICosmeticLogic, CosmeticLogic >(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDistributionLogic, DistributionLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeLogic, EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReceiptLogic, ReceiptLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<ReportLogicEmployee>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<MailLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}

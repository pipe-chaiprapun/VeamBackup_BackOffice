using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Concrete;
using Backup.ClassLibrary.Concrete.Nakivo;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.WebAPI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
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
            kernel.Bind<IAppRep>().To<App>();
            kernel.Bind<IAuthorizationRep>().To<Authorization>();
            kernel.Bind<IClients>().To<Clients>();
            kernel.Bind<IPackages>().To<Packages>();
            kernel.Bind<IPayments>().To<Payments>();
            kernel.Bind<IUser>().To<User>();
            kernel.Bind<IPosition>().To<Position>();
            kernel.Bind<IAddUser>().To<AddUser>();
            kernel.Bind<IReport>().To<Report>();
            kernel.Bind<ILogAction>().To<LogAction>();
            kernel.Bind<ISetting>().To<Setting>();
            kernel.Bind<Ipolicy>().To<Policy>();
            kernel.Bind<IDashboard>().To<Dashboard>();
            kernel.Bind<IVeeamCC>().To<VeeamCC>();
            kernel.Bind<Iinvoices>().To<Invoices>();
            kernel.Bind<IUpgradePackage>().To<UpgradePackage>();
            kernel.Bind<IRefund>().To<Refund>();
            kernel.Bind<IRequest>().To<Request>();
            kernel.Bind<IRequestNewPackage>().To<RequestNewPackage>();
            kernel.Bind<IRequestsHistory>().To<RequestsHistory>();
            kernel.Bind<IReseller>().To<ImpReseller>();
            kernel.Bind<IResallerInvoice>().To<ResallerInvoice>();
            kernel.Bind<IProlongPackage>().To<ProlongPackage>();
            kernel.Bind<INakivoAPI>().To<NakivoAPI>();
            kernel.Bind<IGetTable>().To<GetTable>();
            kernel.Bind<IVeeamCC2>().To<VeeamCC2>();
            kernel.Bind<IExport>().To<Export>();
            kernel.Bind<IOption>().To<Option>();
            kernel.Bind<IPromoCode>().To<PromoCode>();
        } 
    }
}
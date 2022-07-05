namespace Backup.ClassLibrary.Concrete
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Backup.ClassLibrary.Entity;
    using System.Collections.Generic;

    public partial class BackOfficeDB : DbContext
    {
        public BackOfficeDB()
            : base("name=BackOfficeDB")
        {
        }
        public virtual DbSet<EmailAddress> EmailAddress { get; set; }
        public virtual DbSet<Log_SignIn> Log_SignIn { get; set; }
        public virtual DbSet<vBackOfficeClients> vBackOfficeClients { get; set; }
        public virtual DbSet<vBackOfficePackages> vBackOfficePackages { get; set; }
        public virtual DbSet<vBackOfficeLogActions> vBackOfficeLogActions { get; set; }
        public virtual DbSet<vBackOfficeUser> vBackOfficeUser { get; set; }
        public virtual DbSet<BO_Position> BO_Position { get; set; }
        public virtual DbSet<BO_Employee> BO_Employee { get; set; }
        public virtual DbSet<BO_Log_Signin> BO_Log_Signin { get; set; }
        public virtual DbSet<Package_Type> Package_Type { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ChatMessage> ChatMessage { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<BO_LogActionsEmployee> BO_LogActionsEmployee { get; set; }
        public virtual DbSet<vBOInvoiceDetails> vBOInvoiceDetails { get; set; }
        public virtual DbSet<CustomerOnline> CustomerOnline { get; set; }
        public virtual DbSet<UserOnline> UserOnline { get; set; }
        public virtual DbSet<Products_Price> Products_Price { get; set; }
        public virtual DbSet<Paypal_Refund> Paypal_Refund { get; set; }
        public virtual DbSet<v_BOinvoice> v_BOinvoice { get; set; }
        public virtual DbSet<vBackOfficeRequest> vBackOfficeRequest { get; set; }
        public virtual DbSet<Packages_m> Packages2 { get; set; }
        public virtual DbSet<Report_Refund> Report_Refund { get; set; }
        public virtual DbSet<VBackupBackOfficeRequestsNewPackage> VBackupBackOfficeRequestsNewPackages { get; set; }
        public virtual DbSet<VBackOfficeRequestsHistory> VBackOfficeRequestsHistories { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Veeam_Tenant> Veeam_Tenant { get; set; }
        public virtual DbSet<vBackOfficeUPgrade> vBackOfficeUPgrade { get; set; }
        public virtual DbSet<vBOviewInvoiceTab> vBOviewInvoiceTab { get; set; }
        public virtual DbSet<v_Repository> v_Repository { get; set; }
        public virtual DbSet<Package_VeeamBackup> Package_VeeamBackup { get; set; }
        public virtual DbSet<Package_VeeamReplication> Package_VeeamReplication { get; set; }
        public virtual DbSet<Customer_Notification> Customer_Notification { get; set; }
        public virtual DbSet<Reseller> Resellers { get; set; }
        public virtual DbSet<Reseller_Address> Reseller_Address { get; set; }
        public virtual DbSet<Reseller_Company> Reseller_Company { get; set; }
        public virtual DbSet<Reseller_sales> Reseller_sales { get; set; }
        public virtual DbSet<Reseller_Contract> Reseller_Contract { get; set; }
        public virtual DbSet<Reseller_Payment> Reseller_Payment { get; set; }

        public virtual DbSet<v_Reseller> v_Reseller { get; set; }
        public virtual DbSet<Reseller_Key> Reseller_Key { get; set; }
        public virtual DbSet<Reseller_Bills> Reseller_Bills { get; set; }
        public virtual DbSet<v_Reseller_Invoices_BO> v_Reseller_Invoices_BO { get; set; }
        public virtual DbSet<v_Reseller_Invoices_View_BO> v_Reseller_Invoices_View_BO { get; set; }

        public virtual DbSet<v_Reseller_Order> v_Reseller_Order { get; set; }
        public virtual DbSet<v_Reseller_Bill> v_Reseller_Bill { get; set; }
        public virtual DbSet<Reseller_Notification> Reseller_Notification { get; set; }

        public virtual DbSet<StatusCode> StatusCodes { get; set; }
        public virtual DbSet<v_PackageTap> v_PackageTap { get; set; }
        public virtual DbSet<v_PackageTap_viewReport> v_PackageTap_viewReport { get; set; }
        public virtual DbSet<vBackOfficeClients_new> vBackOfficeClients_new { get; set; }

        public virtual DbSet<v_Get_InvoviceById_package_backup> v_Get_InvoviceById_package_backup { get; set; }
        public virtual DbSet<v_Get_InvoviceById_package_replication> v_Get_InvoviceById_package_replication { get; set; }
        public virtual DbSet<v_Get_InvoviceById_package_backup_resaller> v_Get_InvoviceById_package_backup_resaller { get; set; }
        public virtual DbSet<v_Get_InvoviceById_package_replication_resaller> v_Get_InvoviceById_package_replication_resaller { get; set; }

        public virtual DbSet<v_ChangeStatusBill> v_ChangeStatusBill { get; set; }

        public virtual DbSet<v_Products_Price> v_Products_Price { get; set; }
        public virtual DbSet<v_Get_InvoviceById_package_backup_Nakivo> v_Get_InvoviceById_package_backup_Nakivo { get; set; }
        public virtual DbSet<v_Get_InvoviceById_package_backup_Nakivo_resaller> v_Get_InvoviceById_package_backup_Nakivo_resaller { get; set; }
        public virtual DbSet<Option9T> Option9T { get; set; }
        public virtual DbSet<Package_manage> Package_manage { get; set; }
        public virtual DbSet<Promo_code> Promo_code { get; set; }
        public virtual DbSet<v_GetPackage_manage> v_GetPackage_manage { get; set; }

    }
}

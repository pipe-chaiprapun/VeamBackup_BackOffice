using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backup.ClassLibrary.Abstract;
using Moq;
using VeeamBackOfficeUnit.Test.Models;
using BackOffice.WebAPI.Authen;
using Newtonsoft.Json;
using System.Collections.Generic;
using Backup.ClassLibrary.Entity;
using Backup.ClassLibrary.Models;

namespace VeeamBackOfficeUnit.Test
{
    /// <summary>
    /// UnitTest PackageController by FarkramDev
    /// </summary>
    [TestClass]
    public class PackageController
    {
        private string token = string.Empty;
        private Mock<IPackages> _package;
        private Mock<IAppRep> _EFapp;
        private Mock<Iinvoices> _INV;
        private Mock<IUpgradePackage> _Upgrade;
        private BackOffice.WebAPI.Controllers.PackageController package;

        [TestInitialize]
        public void Initialize()
        {
            token = Authentication.SetAuthenticated(DataMock.Employee, TimeSpan.FromMinutes(120).Minutes); //Set Authentication Mock
            _package = new Mock<IPackages>();
            _EFapp = new Mock<IAppRep>();
            _INV = new Mock<Iinvoices>();
            _Upgrade = new Mock<IUpgradePackage>();
            package = new BackOffice.WebAPI.Controllers.PackageController(_INV.Object,_package.Object, _EFapp.Object, _Upgrade.Object);
            package.ip_address = "Run Test IP";
        }

        [TestMethod]
        public void PostAllPackages()
        {
            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("package page", "package all page user: " + user.emp_permission, package.ip_address, user.emp_id)).Returns(true);
            _package.Setup(s => s.getAllPackages).Returns(new List<v_PackageTap>
            {
                new v_PackageTap{
                    PackageNo = 525,
                    PriceTotal = decimal.Parse("54.9000"),
                    Vms = 1,
                    UserType = "Normal User",
                    StartDate = DateTime.Parse("2017-07-22"),
                    EndDate = DateTime.Parse("2017-08-21"),
                    Name = "manop",
                    Family = "chayangkoor",
                    Company = "addlink",
                    Stroage = 500,
                    PhoneNumber = "0804786449",
                    buff_pck_type_id = 11,
                    Type = "Veeam Backup",
                    Status = "Paid",
                    buff_cust_id = 10022,
                    buff_cart_id = 1221,
                    ClientID = "NM11192",
                    buff_pck_status = "pa",
                    buff_vcc_id = 100006
                },
                new v_PackageTap{
                    PackageNo = 566,
                    PriceTotal = decimal.Parse("54.9000"),
                    Vms = 1,
                    UserType = "Enterprise",
                    StartDate = DateTime.Parse("2017-07-22"),
                    EndDate = DateTime.Parse("2017-08-21"),
                    Name = "koko",
                    Family = "momo",
                    Company = "addlink",
                    Stroage = 500,
                    PhoneNumber = "0885952673",
                    buff_pck_type_id = 11,
                    Type = "Veeam Backup",
                    Status = "Paid",
                    buff_cust_id = 10025,
                    buff_cart_id = 1243,
                    ClientID = "ET11195",
                    buff_pck_status = "pa",
                    buff_vcc_id = 100019
                }
            });

            var data = package.PostAllPackages();
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<v_PackageTap> list = JsonConvert.DeserializeObject<List<v_PackageTap>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void PostAllTypePackages()
        {
            //Get authentication from mock initialize authen token
            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("package page", "package type all page user: " + user.emp_permission, package.ip_address, user.emp_id)).Returns(true);
            _package.Setup(s => s.getAllTypePackages).Returns(new List<Package_Type>
            {
                new Package_Type{
                    pck_type_id = 11,
                    pck_type_name = "Veeam Backup"
                },
                new Package_Type{
                    pck_type_id = 12,
                    pck_type_name = "Veeam Replication"
                }
            });

            var data = package.PostAllTypePackages();
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<Package_Type> list = JsonConvert.DeserializeObject<List<Package_Type>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void PostCreateVeeamBackup()
        {
            create_inv_backup req = new create_inv_backup { ClientId = 10004, SendInvoice = false, StorageBrand = true, StorageGB = 1000, VMsQty = 2 };
            m_create_inv_backup value = new m_create_inv_backup
            {
                cust_id = req.ClientId,
                free_trial = 0,
                premiums_storage = req.StorageBrand.Equals(true) ? 1 : 0,
                storage = req.StorageGB,
                vmQty = req.VMsQty
            };

            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("package page", "Post Create Invoice Veeam Backup: " + user.emp_permission, package.ip_address, user.emp_id)).Returns(true);
            _package.Setup(s => s.addCreditInvoiceBackup(value)).Returns(new List<vBOviewInvoiceTab> {
                new vBOviewInvoiceTab{
                    invoice_no = "29082519",
                    username = "VCC100011",
                    password = "RdRxjwXn9VlF9AbnrnMjdbUL3svgHIENAk2KAobW+Q7RB3F3lymzY0arEyYBTLyOKEDOkdUyjLon5qh22O3Y+7H187syUYYLP25fGsYhnqcrRtfLV/n22A+Q187E7G0/zU75esXK2boBNvWs5uDpwjXOlnDsqkQW11dn0AtIvYU=",
                    payment_id = "PAY-2PJ20724FC664602XLF7PO4I",
                    issued = "08/09/2017",
                    due = "30/08/2017",
                    vm = 2,
                    vm_total_price = decimal.Parse("19.8000"),
                    storage = 1000,
                    storage_total_price = decimal.Parse("90.0000"),
                    cart_total_price = decimal.Parse("109.8000"),
                    fees = decimal.Parse("0.000000"),
                    pck_start_dt = "31/07/2017",
                    pck_end_dt = "30/08/2017",
                    email = "t1@t1.com",
                    phone_num = "0123456784",
                    company_name = "Test company_name",
                    firstname = "Test firstname",
                    lastname = "Test lastname",
                    address = "Test address",
                    country = "Australia",
                    city = "moung",
                    province = "Queensland",
                    post_code = "12345",
                    processor = null,
                    ram = null,
                    ip_address = null,
                    networks = null,
                    internet_traffic = null,
                    vm_price = null,
                    storage_price = null,
                    processor_price = null,
                    ram_price = null,
                    ip_address_price = null,
                    internet_traffic_price = null,
                    type_storage = null,
                    pck_type_id= 11,
                    pck_id = 33,
                    name = "Repli",
                    vcc_id = 10011,
                    cust_id = 10004
                }
            });

        _package.Setup(s => s.GetCustomer_Notification(value.cust_id)).Returns(
         new Customer_Notification
            {
            cust_id = 10004,
            pck_sys_create = true,
            pck_sys_expire = true,
            pck_sys_request = true,
            pck_sys_suspend = true,
            inv_sys_new = true,
            inv_sys_over = true,
            new_sys_new = true,
            new_sys_promotion = true

         });

            var data = package.PostCreateVeeamBackup(req);

        }

        [TestMethod]
        public void PostCreateVeeamReplication()
        {
            create_inv_replication value = new create_inv_replication
            {
                cust_id = 11194,
                vmQty = 1,
                storage = 500,
                premiums_storage = true,
                SendInvoice = false,
                processor = 4,
                ram = 8,
                ipaddress = 1,
                networks = 2,
                internet_traffic = 0
            };

        m_create_inv_replication req = new m_create_inv_replication
            {
                cust_id = value.cust_id,
                free_trial = 0,
                premiums_storage = 1,
                storage = value.storage,
                vmQty = value.vmQty,
                processor = value.processor,
                ram = value.ram,
                ipaddress = value.ipaddress,
                networks = value.networks,
                internet_traffic = value.internet_traffic
            };

            var user = Authentication.User;
            _EFapp.Setup(s => s.save_logaction("package page", "Post Create Invoice Veeam Backup: " + user.emp_permission, package.ip_address, user.emp_id)).Returns(true);
            _package.Setup(s => s.addCreditInvoiceReplication(req)).Returns(new List<vBOviewInvoiceTab> {
                new vBOviewInvoiceTab    {
                    payment_id = null,
                    invoice_no = "1709231395393",
                    username = "VCC100201",
                    password = "KIfjRMwTVpHxXFsP2DCLYhZb5XNvVBnplMilF+VFkCP6uSqitpxuX6uq0ZMKYGkAxzTzMJqkKB5YRGyELHwkbXmn4Sdofkl+ZvN5gFpMSrWM2xKzwbVdi9f8fWN2Gat0m45fP188coHAjuWBCU9atEKftqUbpYhGx2KVV1TDavw=",
                    issued = "23/09/2017",
                    due = "23/10/2017",
                    vm = null,
                    vm_total_price = null,
                    storage = null,
                    storage_total_price = null,
                    cart_total_price = decimal.Parse("103.34"),
                    fees = 0,
                    pck_start_dt = "23/09/2017",
                    pck_end_dt = "23/10/2017",
                    email = "pondzanakak@hotmail.com",
                    phone_num = "0989617718",
                    company_name = "addlink",
                    firstname = "pond",
                    lastname = "pond",
                    address = "14",
                    country = "Thailand",
                    city = "sds",
                    province = "Ubon Ratchathani",
                    post_code = "34190",
                    processor = 4,
                    ram = 8,
                    ip_address = 1,
                    networks = 2,
                    internet_traffic = 0,
                    vm_price = decimal.Parse("15"),
                    storage_price = decimal.Parse("75"),
                    processor_price = decimal.Parse("1.28"),
                    ram_price = decimal.Parse("6.56"),
                    ip_address_price = decimal.Parse("5.5"),
                    internet_traffic_price = 0,
                    type_storage = true,
                    pck_type_id = 11,
                    pck_id = 393,
                    name = "Replication",
                    vcc_id = 100201,
                    cust_id = 11194,
                    cart_id = 1395
                }
            });

            _package.Setup(s => s.GetCustomer_Notification(value.cust_id)).Returns(
                new Customer_Notification {

                    cust_id = 11194,
                    pck_sys_create = true,
                    pck_sys_expire = true,
                    pck_sys_request = true,
                    pck_sys_suspend = true,
                    inv_sys_new = true,
                    inv_sys_over = true,
                    new_sys_new = true,
                    new_sys_promotion = true
                
            });
            var data = package.PostCreateVeeamReplication(value);
            var objResult = data.GetType().GetProperty("Content").GetValue(data);
            string jsonData = JsonConvert.SerializeObject(objResult);
            List<vBackOfficePackages> list = JsonConvert.DeserializeObject<List<vBackOfficePackages>>(jsonData);
            Assert.IsNotNull(objResult);
            Assert.AreEqual(0, list.Count);

        }
    }
}
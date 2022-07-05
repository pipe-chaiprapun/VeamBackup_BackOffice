using Backup.ClassLibrary.Abstract;
using Backup.ClassLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Backup.ClassLibrary.Models;
using Backup.ClassLibrary.Concrete.VeeamCloudConnect;
using Backup.ClassLibrary.Concrete.Security;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace Backup.ClassLibrary.Concrete
{

    public class ImpReseller : IReseller
    {
        private BackOfficeDB db = new BackOfficeDB();
        private App_Securities key = new App_Securities();
        private m_MessageTemp message = new m_MessageTemp();

        public IEnumerable<v_Reseller> GetReseller => db.v_Reseller.Where(s => s.status != "re");

        public IEnumerable<v_Reseller_Bill> GetBill => db.v_Reseller_Bill;
        public IEnumerable<v_Reseller_Order> GetReseller_Order => db.v_Reseller_Order;

        public v_Reseller addReseller(from_reseller val)
        {
            //val.password = App_Hash.PasswordHash(val.password);
            var result = db.Database.SqlQuery<v_Reseller>("[backup].[s_AddReseller] @company_name,@website,@company_email,@company_phone,@company_country,@company_provine,@company_city,@company_adderss,@company_postcode,@vat_id,@first_name,@last_name,@reseller_email,@reseller_phone,@reseller_country,@reseller_provine,@reseller_city,@reseller_adderss,@reseller_postcode,@reseller_role,@password,@job_title,@seller_id,@status",
                new SqlParameter("@company_name", val.company_name),
                new SqlParameter("@website", val.website),
                new SqlParameter("@company_email", val.company_email),
                new SqlParameter("@company_phone", val.company_phone),
                new SqlParameter("@company_country", val.company_country),
                new SqlParameter("@company_provine", val.company_provine),
                new SqlParameter("@company_city", val.company_city),
                new SqlParameter("@company_adderss", val.company_address),
                new SqlParameter("@company_postcode", val.company_postcode),
                new SqlParameter("@vat_id", val.vat_id),
                new SqlParameter("@first_name", val.first_name),
                new SqlParameter("@last_name", val.last_name),
                new SqlParameter("@reseller_email", val.reseller_email),
                new SqlParameter("@reseller_phone", val.reseller_phone),
                new SqlParameter("@reseller_country", val.reseller_country),
                new SqlParameter("@reseller_provine", val.reseller_provine),
                new SqlParameter("@reseller_city", val.reseller_city),
                new SqlParameter("@reseller_adderss", val.company_address),
                new SqlParameter("@reseller_postcode", val.reseller_postcode),
                new SqlParameter("@reseller_role", val.reseller_role),
                new SqlParameter("@password", val.password),
                new SqlParameter("@job_title",val.job_title),
                new SqlParameter("@seller_id",val.seller_id),
                new SqlParameter("@status","nw")
                ).Single();

            return result;
        }

        public bool removeReseller(int id)
        {
            var remove = db.Resellers.FirstOrDefault(s => s.seller_id == id);
            remove.status = "rm";
            int res = db.SaveChanges();
            if (res > 0) return true;
            return false;
        }

        public bool updateReseller(from_reseller_update val)
        {

            var qry = db.Resellers.FirstOrDefault(r => r.seller_id == val.seller_id);

            var re = db.Database.ExecuteSqlCommand("UPDATE [backup].[Reseller] SET email = @reseller_email WHERE seller_id = @seller_id",
                new SqlParameter("@seller_id",val.seller_id),
                new SqlParameter("@reseller_email",val.reseller_email)
                );
            var ad = db.Database.ExecuteSqlCommand("UPDATE[backup].[Reseller_Address] SET first_name = @first_name,last_name = @last_name," +
                "reseller_phone = @reseller_phone,country = @reseller_country,provine = @reseller_provine,city = @reseller_city," +
                "adderss = @reseller_adderss,postcode = @reseller_postcode,[role] = @reseller_role,job_title = @job_title WHERE seller_id = @seller_id",
                new SqlParameter("@seller_id", val.seller_id),
                new SqlParameter("@first_name", val.first_name),
                new SqlParameter("@last_name", val.last_name),
                new SqlParameter("@reseller_phone", val.reseller_phone),
                new SqlParameter("@reseller_country", val.reseller_country),
                new SqlParameter("@reseller_provine", val.reseller_provine),
                new SqlParameter("@reseller_city", val.reseller_city),
                new SqlParameter("@reseller_adderss", val.reseller_address),
                new SqlParameter("@reseller_postcode", val.reseller_postcode),
                new SqlParameter("@reseller_role", val.reseller_role),
                new SqlParameter("@job_title", val.job_title)
                );
            var com = db.Database.ExecuteSqlCommand("UPDATE [backup].[Reseller_Company]  SET company_name = @company_name,website = @website," +
                "email = @company_email,company_phone = @company_phone,country = @company_country,provine = @company_provine,city = @company_city," +
                "adderss = @company_adderss,postcode = @company_postcode,vat_id = @vat_id WHERE seller_id = @seller_id",
                new SqlParameter("@seller_id", val.seller_id),
                new SqlParameter("@company_name", val.company_name),
                new SqlParameter("@website", val.website),
                new SqlParameter("@company_email", val.company_email),
                new SqlParameter("@company_phone", val.company_phone),
                new SqlParameter("@company_country", val.company_country),
                new SqlParameter("@company_provine", val.company_provine),
                new SqlParameter("@company_city", val.company_city),
                new SqlParameter("@company_adderss", val.company_address),
                new SqlParameter("@company_postcode", val.company_postcode),
                new SqlParameter("@vat_id", val.vat_id)
                );

            if (qry.status == "ac")
            {
                var con = db.Database.ExecuteSqlCommand("UPDATE [backup].[Reseller_Contract] SET contract_num = @contract_number,contract_period_from = @contract_period_from," +
                    "contract_period_to = @contract_period_to,contract_comment = @contract_comment,contract_discount = @contract_discount WHERE seller_id = @seller_id",
                    new SqlParameter("@seller_id", val.seller_id),
                    new SqlParameter("@contract_number", val.contract_number == null ? "" : val.contract_number),
                    new SqlParameter("@contract_period_from", val.contract_period_from == null ? DateTime.Now : val.contract_period_from),
                    new SqlParameter("@contract_period_to", val.contract_period_to == null ? DateTime.Now : val.contract_period_to),
                    new SqlParameter("@contract_comment", val.contract_comment == null ? "" : val.contract_comment),
                    new SqlParameter("@contract_discount", val.contract_discount)
                    );
                if (re > 0 && ad > 0 && com > 0 && con > 0) { return true; }
            }
            else if (qry.status == "nw")
            {
                if (re > 0 && ad > 0 && com > 0) { return true; }
            }

            return false;
        }

        public Reseller approve_Reseller(Reseller_Contract val)
        {
            var res = db.Resellers.FirstOrDefault(s => s.seller_id == val.seller_id);
            var pass = App_Hash.PasswordHash(res.password);

            var result = db.Database.SqlQuery<Reseller>("[backup].[s_ApproveReseller] @seller_id,@contract_num,@contract_period_from,@contract_period_to,@contract_comment,@contract_discount,@password",
               new SqlParameter("@seller_id", val.seller_id),
               new SqlParameter("@contract_num", val.contract_num),
               new SqlParameter("@contract_period_from", val.contract_period_from),
               new SqlParameter("@contract_period_to", val.contract_period_to),
               new SqlParameter("@contract_comment", val.contract_comment == null ? "": val.contract_comment),
               new SqlParameter("@contract_discount", val.contract_discount),
               new SqlParameter("@password", pass)

               ).Single();

            var pv = key.Encrypt(result.resller_id+"||"+result.password).Replace("+", "_").Replace("/", "-").Replace("=", "");
            var qry = db.Reseller_Key.FirstOrDefault(s => s.seller_id == result.seller_id);
            qry.private_key = pv;
            qry.public_key = pv;
            db.SaveChanges();

            return res;
        }
        public Reseller blockReseller(from_reseller_Block val)
        {
            var s = db.Database.SqlQuery<Reseller>("select * from [backup].[Reseller]AS r WHERE r.seller_id=@seller_id",
           new SqlParameter("@seller_id", val.seller_id)).Last();

            if (s.status == "ac")
            {
                var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Reseller] SET status = 'bo' WHERE seller_id = @seller_id", new SqlParameter("@seller_id", val.seller_id));
                var ss = db.Database.SqlQuery<Reseller>("select * from [backup].[Reseller]AS r WHERE r.seller_id=@seller_id",
                     new SqlParameter("@seller_id", val.seller_id)).Last();
                return (ss);
            }
            else
            {
                var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Reseller] SET status = 'ac' WHERE seller_id = @seller_id", new SqlParameter("@seller_id", val.seller_id));
                var sss = db.Database.SqlQuery<Reseller>("select * from [backup].[Reseller]AS r WHERE r.seller_id=@seller_id",
                        new SqlParameter("@seller_id", val.seller_id)).Last();
                return (sss);
            }


        }
        public v_Reseller_show Get_Reseller(int id)
        {
            var res = db.Database.SqlQuery<v_Reseller_show>("SELECT res.seller_id ,res.email AS reseller_email,res.resller_id,rea.first_name,rea.last_name,rea.reseller_phone,rea.country AS reseller_country," +
                "rea.provine AS reseller_provine,rea.city AS reseller_city,rea.adderss AS reseller_adderss,rea.postcode AS reseller_postcode,rea.[role] AS reseller_role,com.company_name,com.website," +
                "com.email AS company_email,com.company_phone,com.country AS company_country,com.provine AS company_provine,com.city AS company_city,com.adderss AS company_adderss," +
                "com.postcode AS company_postcode,com.vat_id,res.[password],res.[status],con.contract_num AS contract_number,CONVERT(VARCHAR, con.contract_period_from, 104) AS contract_period_from," +
                "CONVERT(VARCHAR, con.contract_period_to, 104) AS contract_period_to,con.contract_comment,con.contract_discount AS contract_discount,ke.private_key,ke.public_key," +
                "rea.job_title FROM[backup].Reseller AS res JOIN[backup].Reseller_Address AS rea ON rea.seller_id = res.seller_id LEFT JOIN [backup].Reseller_Company AS com ON com.seller_id = res.seller_id " +
                "LEFT JOIN [backup].[Reseller_Contract] AS con ON con.seller_id = res.seller_id LEFT JOIN [backup].[Reseller_Key] AS ke ON ke.seller_id = res.seller_id WHERE res.seller_id = @seller",
                new SqlParameter("@seller", id)).FirstOrDefault();

            return res;
        }

        public Reseller_Payment get_Payment(string id)
        {
            return db.Reseller_Payment.FirstOrDefault(i => i.payment_number.Equals(id));
        }

        public Reseller_Bills change_status(from_change_status val)
        {

            var qry = db.Database.ExecuteSqlCommand("UPDATE [backup].[Reseller_Bills] SET [status] = @status,comments = @comments WHERE bill_No = @bill_No",
                new SqlParameter("@status", val.status),
                new SqlParameter("@comments", val.comments),
                new SqlParameter("@bill_No", val.bill_no));

            //Payment
            var qry_bil = db.v_Reseller_Bill.Where(b => b.bill_No == val.bill_no).FirstOrDefault();

            var qry_pay = db.Database.ExecuteSqlCommand("INSERT INTO [backup].[Reseller_Payment] (payment_number, [date], amount, destination, comment, bill_no, [status])" 
                + " VALUES(@payment_number, @date, @amount, @destination, @comment, @bill_no, @status)",
                   new SqlParameter("@status", qry_bil.payment_status),
                   new SqlParameter("@comment", val.comments),
                   new SqlParameter("@bill_no", val.bill_no),
                   new SqlParameter("@amount", qry_bil.payment_amount),
                   new SqlParameter("@date", qry_bil.payment_date),
                   new SqlParameter("@destination", qry_bil.destination),
                   new SqlParameter("@payment_number", qry_bil.payment_number)
                );

            var pay = db.Reseller_Payment.Where(p => p.bill_no == val.bill_no).OrderByDescending(p => p.id).FirstOrDefault();
            add_noti_was_paid(val.bill_no, pay.id);
            //

            var q = db.Database.SqlQuery<v_ChangeStatusBill>("select * from [backup].[v_ChangeStatusBill] AS bil WHERE bil.bill_No = @bill_No",
                new SqlParameter("@bill_No", val.bill_no)).ToArray();

            foreach (var i in q)
            {
                var qr = db.Database.ExecuteSqlCommand("UPDATE [backup].[Reseller_sales] SET invo_status = @status WHERE invoice_no = @invoice_no",
                new SqlParameter("@status", val.status),
                 new SqlParameter("@invoice_no", i.invoice_no)
                );
            }

            var res = db.Database.SqlQuery<Reseller_Bills>("select * from [backup].[Reseller_Bills] AS bil WHERE bil.bill_No = @bill_No",
                new SqlParameter("@bill_No", val.bill_no)).FirstOrDefault();

            return (res);

        }
        public Guid setToken(string email, int id)
        {
            var res = db.Database.ExecuteSqlCommand("INSERT INTO [backup].[EmailAddress] ([cust_id],[email]) VALUES(@id,@email)",
                  new SqlParameter("@id", id),
                  new SqlParameter("@email", email)
                  );
            var qry = db.Database.SqlQuery<EmailAddress>("select * from [backup].[EmailAddress] where cust_id = @cust_id",
                new SqlParameter("@cust_id", id)).FirstOrDefault();
            return qry.token;
        }

        public async void SendBill(int bill_no, string name, string month, int? sales, decimal? amount, string email, int? discount)
        {
            var data = db.Database.SqlQuery<m_viewbill>("[backup].[s_Reseller_sendbill] @bill_no",
                new SqlParameter("@bill_no", bill_no));

            var data2 = db.Database.SqlQuery<m_viewbill>("[backup].[s_Reseller_sendbill] @bill_no",
                new SqlParameter("@bill_no", bill_no));

            var data3 = db.Database.SqlQuery<m_viewbill>("[backup].[s_Reseller_sendbill] @bill_no",
                new SqlParameter("@bill_no", bill_no));

            string formEmail = message.PartnersBillReminder(name, month, sales, amount, data3, bill_no, discount);
            string formAttach = message.viewbill(data, data2);
            await System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.MailAttachments(email, "Partners Bill#" + bill_no + " Reminder", formEmail, formAttach));
            //Console.WriteLine(DateTime.Now.ToString("o") + "Send Bill of " + bill.bill_No +" to " + res.seller_id);
        }

        public string send(int bill_no)
        {
            var bill = db.Reseller_Bills.Where(b => b.bill_No == bill_no).FirstOrDefault();
            var res = db.v_Reseller.Where(r => r.seller_id == bill.reseller_id).FirstOrDefault();
            try
            {
                if (res.seller_id == bill.reseller_id)
                {
                    SendBill(bill.bill_No, res.first_name + " " + res.last_name, bill.month, bill.sales, bill.amount, res.reseller_email, bill.discount);
                    return "success";
                }
                return "unsuccess";
            }
            catch (Exception e)
            {
                return "error : " + e;
            }
        }

 

        public async void Bill_was_paid_to_email(int bill_no)
        {
            var bill = db.Reseller_Bills.Where(b => b.bill_No == bill_no).FirstOrDefault();
            var res = db.v_Reseller.Where(r => r.seller_id == bill.reseller_id).FirstOrDefault();
            if (bill.status.Equals("pa"))
            {
                string formEmail = message.Bill_was_paid(res.first_name, res.last_name, bill.bill_No);
                await System.Threading.Tasks.Task.Factory.StartNew(() => SendMail.Mail(res.reseller_email, "Partners Bill#" + bill_no + " was paid", formEmail));
            }
        }

        public IEnumerable<StatusCode> GetStatusCode()
        {
            return db.StatusCodes; ;
        }

        public Reseller_Notification add_noti_was_paid(int bill_no, int payment_id)
        {
            try
            {
                var bill = db.v_Reseller_Bill.Where(b => b.bill_No == bill_no).FirstOrDefault();
                // inv = db.v_Reseller_Invoices_View_BO.FirstOrDefault(i => i.Invoice_ID == sale.invoice_no);
                //string typevm = inv.Alias;
                //var pay = db.Reseller_Payment.Where(p => p.bill_no == bill_no)
                db.Database.ExecuteSqlCommand("INSERT INTO [backup].[Reseller_Notification] (reseller_id, waspaid_id, title, [description])"
                                                        + "VALUES(@reseller_id, @waspaid_id, @title, @description)",
                                                new SqlParameter("@reseller_id", bill.seller_id),
                                                new SqlParameter("@waspaid_id", payment_id),
                                                new SqlParameter("@title", "WAS PAID"),
                                                new SqlParameter("@description", "Your payment response about bill#" + bill.bill_No)
                                                );

                var noti = db.Reseller_Notification.Where(n => n.waspaid_id == bill.bill_No && n.status.Equals("ac")).FirstOrDefault();
                return noti;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<m_viewbill> show_view_bill(int bill_no)
        {
            var data = db.Database.SqlQuery<m_viewbill>("[backup].[s_Reseller_sendbill] @bill_no",
                new SqlParameter("@bill_no", bill_no));
            return data;
        }
    }
}
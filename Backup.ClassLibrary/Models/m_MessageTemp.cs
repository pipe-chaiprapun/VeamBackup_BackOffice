using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Backup.ClassLibrary.Models;
using Backup.ClassLibrary.Entity;
using System.Globalization;

namespace Backup.ClassLibrary.Models
{
    class m_MessageTemp
    {
        public string visual_host = "https://www.9t.com";
        public string img = "/images/logo.png";

        private int invoices;
        private int invoice_id;
        private string firstname;
        private string issued;
        private string due;
        private string lastname;
        private string address;
        private string country;
        private string city;
        private string province;
        private string post_code;
        private string email;
        private string phone_num;
        private string company_name;
        private int? discount;
        private double total;

        public string viewbill(IEnumerable<m_viewbill> bill, IEnumerable<m_viewbill> bill2)
        {
            string form = "";
            int j = 0;
            total = 0;
            foreach (var i in bill) {
                company_name = i.company_name;
                invoices = i.bill_no;
                invoice_id = (int)i.invoice_no;
                if (j == 0)
                {
                    var pck_start_dt = (DateTime)i.pck_start_dt;
                    issued = pck_start_dt.Day + " " + pck_start_dt.ToString("MMMM") + " " + pck_start_dt.Year;
                    j++;
                }
                var pck_end_dt = (DateTime)i.pck_end_dt;
                due = pck_end_dt.Day + " " + pck_end_dt.ToString("MMMM") + " " + pck_end_dt.Year;

                firstname = i.first_name;
                lastname = i.last_name;
                address = i.reseller_adderss;
                city = i.reseller_city;
                province = i.reseller_provine;
                country = i.reseller_country;
                post_code = i.reseller_postcode;
                email = i.reseller_email;
                phone_num = i.reseller_phone;
                discount = i.discount;
            }
            {
                form += @"<meta>
<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
</meta>

<body>
<section class='printable'>
    <div class='media-form' style='margin-top: 20px;'>
        <div class='row row-width' style='width: 95%; margin: auto;'>
            <div class='col-sm-6 center-text'>
                <div class='form-group'>
                    <p class='text-24-5' style='font-size: 24px; font-weight: 500;'>Bill #<span>" + invoices + @"</span></p>
                </div>
            </div>
        </div>
        <div class='border-color-top' style='border-top: 1px solid #2C314F; padding-bottom: 20px; width: 95%; margin: auto;'></div>
        <div class='row' style='width: 95%; margin: auto;'>
            <div class='col-sm-6 text-left hidden-xs' style='text-align: left;'>
                <p class='text-20-4 ' style='font-size: 20px; font-weight: 400;'>9T co., ltd.</p>
                <p class='text-12-4 color-A' style='font-size: 12px; font-weight: 400; color: #AAAAAA;'>
                    Avesta Company, Addlink building 889 Moo 5
                    <br> Kamyai Sub-District, Ubon Ratchathani
                    <br> Thailand 34000
                    <br>
                    <span class='color-7A' style='color: #7ACDCF;'> support@9t.com
                    <br> +66(0)45-959612
                    <br> Phone +885(0)974919241(Mr.Jong) Cambodi
                     </span>
                </p>
            </div>
            <div class='col-sm-6 text-right pull-right' style='text-align: right;'>
                <div class=''>
                    <p class='text-20-4' style='font-size: 20px; font-weight: 400;'>"+ company_name + @"</p>
                    <p class='text-12-4 color-A' style='font-size: 12px; font-weight: 400; color: #AAAAAA;'>
                        " + firstname + " " + lastname + @"
                        <br>" + address + @"
                        <br>" + city + @"," + province + @"
                        <br>" + country + " " + post_code + @"
                        <span class='color-7A' style='color: #7ACDCF;'>
                        <br>
                        " + email + @"
                        <br>
                        " + phone_num + @"
                    </span>
                    </p>
                </div>
                <p class='text-12-4 color-A' style='font-size: 12px; font-weight: 400; color: #AAAAAA;'>Invoice: <span class='color-2C' style='color: #2C314F;'>" + invoices + @"</span></p>
                <p class='text-12-4 color-A' style='font-size: 12px; font-weight: 400; color: #AAAAAA;'>Issued: <span class='color-2C' style='color: #2C314F;'>" + issued + @"</span></p>
                <p class='text-12-4 color-A' style='font-size: 12px; font-weight: 400; color: #AAAAAA;'>Due: <span class='color-2C' style='color: #2C314F;'>" + due + @"</span></p>
            </div>
        </div>

        <table style = 'width: 95%; margin: auto;' >
            <tr class='tr-1 ' style='padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F;'>
                <td class='td-1' style='width: 10%;'>DESCRIPTION</td>
                <td class='td-1' style='width: 12%;'>INVOICE ID</td>
                <td class='td-2' style='width: 12%;'>TYPE</td>
                <td class='td-3' style='width: 12%;'>FROM</td>
                <td class='td-4' style='width: 12%;'>TO</td>
                <td class='td-5' style='width: 8%; text-align: right;'>PRICE(inc GST)</td>
            </tr>
            <tbody* ngFor = 'let item Of data' >";
            }

            foreach(var i in bill2)
            {
                var issued = (DateTime)i.pck_start_dt;
                var pck_start_dt = issued.Day + " " + issued.ToString("MMMM") + " " + issued.Year;

                var due = (DateTime)i.pck_end_dt;
                var pck_end_dt = due.Day + " " + due.ToString("MMMM") + " " + due.Year;

                form += @"<tr class='tr-2' style='padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5;'>
                    <td class='td-1' style='width: 10%; color: #7ACDCF;'>VCC_" + i.vcc_id + @"</td>
                    <td class='td-1' style='width: 12%;'>" + i.invoice_no + @"</td>
                    <td class='td-2' style='width: 12%;'>" + i.vem_name + @"</td>
                    <td class='td-3' style='width: 12%;'>" + pck_start_dt + @"</td>
                    <td class='td-4' style='width: 12%;'>" + pck_end_dt + @"</td>
                    <td class='td-5' style='width: 8%; text-align: right;'>$ " + Convert.ToDouble(i.pck_price).ToString("F") + @"</td>
                </tr>";
                total += Convert.ToDouble(i.pck_price);
            }

            form += @"
                <tr class='tr-2' style='padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #2C314F'>
                    <td class='td-1' style='width: 10%; color: #7ACDCF;'></td>
                    <td class='td-2' style='width: 12%;'></td>
                    <td class='td-2' style='width: 12%;'></td>
                    <td class='td-3' style='width: 12%;'></td>
                    <td class='td-4' style='width: 12%;'></td>
                    <td class='td-5' style='width: 8%;'></td>
                </tr>
            </tbody>
            <tbody>
                    <tr class='tr-2' style='padding: 20px 0px; height: 40px;'>
                    <td class='td-1' style='width: 10%; color: #7ACDCF;'></td>
                    <td class='td-2' style='width: 12%;'></td>
                    <td class='td-2' style='width: 12%;'></td>
                    <td class='td-3' style='width: 12%;'></td>
                    <td class='td-4' style='width: 12%;'></td>
                    <td class='td-5' style='width: 8%;'></td>
                </tr>
                <tr class='tr-2' style='padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5;'>
                    <td class='td-1' style='width: 10%;'></td>
                    <td class='td-2 hidden-xs' style='width: 12%;'></td>
                    <td class='td-2 hidden-xs' style='width: 12%;'></td>
                    <td class='td-3 hidden-xs' style='width: 12%;'></td>
                    <td class='td-4 hidden-xs' style='width: 12%;'>Including Discount</td>
                    <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3' style='width: 7%;'>Including Discount</td>
                    <td class='td-5 text-center' style='width: 8%; text-align: right;'>" + discount + @"%</td>
                </tr>
                <tr class='tr-2' style='padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5;'>
                    <td class='td-1' style='width: 10%;'></td>
                    <td class='td-2 hidden-xs' style='width: 12%;'></td>
                    <td class='td-2 hidden-xs' style='width: 12%;'></td>
                    <td class='td-3 hidden-xs' style='width: 12%;'></td>
                    <td class='td-4 hidden-xs' style='width: 12%;'>Total</td>
                    <td class='td-4 hidden-lg hidden-md hidden-sm' style='width: 7%;' colspan=3>Total</td>
                    <td class='td-5 text-center' style='width: 8%; text-align: right;'>$ " + total + @"</td>
                </tr>
                <tr class='tr-2' style='padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5;'>
                    <td class='td-1' style='width: 10%;'></td>
                    <td class='td-2 hidden-xs' style='width: 12%;'></td>
                    <td class='td-2 hidden-xs' style='width: 12%;'></td>
                    <td class='td-3 hidden-xs' style='width: 12%;'></td>
                    <td class='td-4 hidden-xs' style='width: 12%;'>Invoice Total</td>
                    <td class='td-4 hidden-lg hidden-md hidden-sm' style='width: 7%;' colspan='3'>Invoice Total</td>
                    <td class='td-5 text-center' style='width: 8%; text-align: right;'>$ " + total + @"</td>
                </tr>
            </tbody>
        </table>
    
    </div>
    </section>
</body>";
            return form;
        }

        public string PartnersBillReminder(string name, string month, int? sales, decimal? amount, IEnumerable<m_viewbill> bill, int bill_no, int? discount)
        {
            double total = 0;
            var sum = bill.Sum(b => b.pck_price);
            total = Convert.ToDouble(sum);

            return $@"<section>
    <div style='margin: auto;'>
        <div style='width: 1024px; margin: auto; margin-top: 52px;'>
            <div style='border: 2px solid #2C314F; padding-left: 40px; padding-top: 10px; padding-bottom: 10px; font-size: 25px; font-weight:800;'>
                <img src='" + this.visual_host + img + @"' style='width: 35px; height: 33.7px;'>
                <span style='position: relative; top: -6px; margin: 0px 10px;'>9T</span>
            </div>
            <div style='position: relative; bottom: 3px;'>
                <div style='border: 2px solid #2C314F; border-top: none; padding: 1px 0px; padding:40px'>
                    <div style='font-size: 25px; color: #2C314F;'>
                        Dear " + name + @"
                    </div>

                    <div style='color: #AAAAAA; font-size: 20px;margin-top: 30px;'>
                        We remind, that You have unpaid bill

                    </div>
                    <hr style='margin-top: 30px; margin-bottom: 10px;'>
                    <table>
                        <tr style='color: #AAAAAA; font-size: 16px; border-top:1px solid'>
                            <td style='width:150px; text-align: center;'> Bill </td>
                            <td style='width:190px; text-align: center;'> Month </td>
                            <td style='width:105px; text-align: center;'> Sales </td>
                            <td style='width:210px; text-align: center;'> Amount </td>
                            <td style='width:22%; text-align: center;'> Bill Amount </td>

                    </table>
                    <hr style='margin-top: 10px;'>
                    <table>
                        <thead>
                            <tr style='color: #AAAAAA; font-size: 16px;'>
                                <td style='width:150px; text-align: center;'>" + bill_no + @"</td>
                                <td style='width:190px; text-align: center;'>" + month + @"</td>
                                <td style='width:105px; text-align: center;'>" + sales + @"</td>
                                <td style='width:210px; text-align: center;'>$ " + /*Convert.ToDouble(amount).ToString("F")*/ total.ToString("F") + @"</td>
                                <td style='color: green; width: 210px; text-align: center;'> $ " + Convert.ToDouble(total) + @"</td>
                                <td style='text-align: center; color: #ffffff;'>
                                    <div style='background-color: #7ACDCF; padding: 5px 10px 5px 10px; border-radius: 40px; outline: none !important; cursor: pointer; transition: all 0.2s;'>
                                        <a href='http://r.9T.com/signin' style='color: #ffffff;text-decoration:none'>VIEW</a>
                                    </div>
                                </td>
                            </tr>
                        </thead>
                    </table>
                    <div style='color: #AAAAAA; font-size: 16px;margin-top:40px;'>
                        <p> You must pay for bill during termin, that was specified in contract.</p>
                        <p>Thank you for cooperation.</p>
                    </div>
                    <div style='color: #AAAAAA; font-size: 16px; margin-top:40px;  margin-left:10px;'>
                        Best regards,
                        <br>
                        <br>The 9T Team
                    </div>
                    <p style='color: #AAAAAA; margin-top:40px;'>" + DateTime.Now.ToString("dddd d MMMM yyy HH:mmtt('Time Zone Indicator': zzz)") + @"</p>
                    <hr>
                    <br>
                    <a href='http://9t.com/' style='color: #7ACDCF;text-decoration:none;'>
                          <span style = 'cursor: pointer; font-size: 12px;'> Website </span>
   
                       </a> |
   
                       <a href = 'http://9t.com/support/#footered' style = 'color: #7ACDCF;text-decoration:none'>
      
                              <span style = 'cursor: pointer; font-size: 12px;'> Email Sales </span>
          
                              </a> |
          
                              <a href = 'http://9t.com/support/#footered' style = 'color: #7ACDCF;text-decoration:none'>
             
                                     <span style = 'cursor: pointer; font-size: 12px;' > Email Support </span>
                 
                                     </a>
                 
                                     <div style = 'color: #AAAAAA;font-size: 12px; margin-bottom: 25px;'>
                  
                                          <p> Phone: +66(0)45 - 313 - 883 - Thailand </p>
                     
                                             <p> Addlink Co., ltd. is situated in Addlink Building 255 Moo 15 Kamyai Sub-District,</p>
                        
                                                <p> Ubon Ratchathani, Thailand 34000 </p>
                           
                                               </div>
                           
                                           </div>
                           
                                       </div>
                           
                                   </div>
                           
                               </div>
                           
                               </div>
                           </section> ";
        }

        public string Bill_was_paid(string fristname, string lastname, int bill_no)
        {
            return $@"<section>
    <div style='margin: auto;'>
        <div style='width: 500px;  margin: auto;'>
            <div style='border: 2px solid #2C314F; padding-left: 20px; padding-top: 10px; padding-bottom: 10px; font-size: 20px; font-weight: 900;'>
                <img src='" + this.visual_host + img + @"' style='width: 35px; height: 33.7px;'>
                <span style='position: relative; top: -6px; margin: 0px 10px;'>9T</span>
            </div>
            <div style='position:relative; bottom:3px;'>
                <div style='border: 2px solid #2C314F; border-top: none; padding: 1px 0px'>
                    <div style='text-align: center; margin: 30px; margin-bottom: 30px; font-size: 20px;'>BILLS
                            </div>
        

                            <div style = 'font-size: 20px; margin: 30px; margin-top:0px; word-wrap: break-word; font-weight: 500; color: #2C314F;' >
         
                                 <hr> Dear " + fristname + " " + lastname + @"

                        <div style = 'color: #AAAAAA; font-size: 16px;' >
 
                             <p style = 'margin-left:10px;margin-bottom:0px;' > We are glad to inform You, tht bill №" + bill_no + @" was successfuly </ p >
     
                                 <p style = 'margin-top:5px;' > paid.</p>
      

                                  <p style = 'margin-left:10px; margin-bottom:0px;' > Thank you for cooperation.</p>
           

                                   </div>
           
                                   <div style = 'color: #AAAAAA; font-size: 16px;'>
           
                                       <!--<a href = '" + this.visual_host + @"/bill/getBillbyId?billNo=" + bill_no + @"/" + "token" + @"' style = 'background-color: #7ACDCF;display:block;text-decoration: none; text-align: center; border: 1px solid #7ACDCF;color: #ffffff; width: 226px;height: 40px;line-height: 40px;border-radius: 40px;font-weight: 500;border-width: 2px;outline: none !important;transition: all 0.2s;cursor: pointer;margin-top: 30px;margin-bottom: 20px;margin-left: 20%; '>BILLS</a>-->
                                        <a href = 'http://r.9t.com/signin' style = 'background-color: #7ACDCF;display:block;text-decoration: none; text-align: center; border: 1px solid #7ACDCF;color: #ffffff; width: 226px;height: 40px;line-height: 40px;border-radius: 40px;font-weight: 500;border-width: 2px;outline: none !important;transition: all 0.2s;cursor: pointer;margin-top: 30px;margin-bottom: 20px;margin-left: 20%; '>BILLS</a>

<div style = 'font-size:14px;' >
     <p style = 'margin-bottom:0px; margin-top:10%;' > Best regards,</p>
          <P style = 'margin-top:10px;margin-bottom:8%;' > The 9T Backup team </P>
           </div>
           <p>" + DateTime.Now.ToString("dddd d MMMM yyy HH:mmtt('Time Zone Indicator': zzz)") + @" </p>
          </div>
          <div>
              <div>
                  <hr>
                  <div style = 'color: #AAAAAA; font-size: 16px;'>
                       <div>
                           <p style = 'color: #7ACDCF;'>
                                <a href = 'http://9t.com/' style = 'color: #7ACDCF;text-decoration:none'>
                                       <span style = 'cursor: pointer; font-size: 12px;' > Website </span>
                                    </a> |
                                    <a href = 'http://9t.com/support/#footered' style = 'color: #7ACDCF;text-decoration:none'>
                                           <span style = 'cursor: pointer; font-size: 12px;' > Email Sales </span>
                                           </a> |
                                           <a href = 'http://9t.com/support/#footered' style = 'color: #7ACDCF;text-decoration:none'>
                                                  <span style = 'cursor: pointer; font-size: 12px;' > Email Support </span>
                                                  </a>
                                              </p>
                                              <div style = 'color: #AAAAAA;font-size: 12px;'>
                                                   <p> Phone + 66(0)45-959612 Thailand </p>
                                                         <p style = 'margin-bottom:30px;' > Phone + 885(0)974919241(Mr.Jong) Cambodia </p>
                                                              <p style = 'margin-bottom:0px;' > Avesta Company , Addlink building 889 Moo 5 Kamyai Sub-Distric Muang Ubon Ratchathani
                                                                       Ubon Ratchathani 34000 </ p >
                                                                   <p style = 'margin-top:3px;' > Ubon Ratchathani, Thailand, 34000 </p>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                            </section> ";
        }
    }


}

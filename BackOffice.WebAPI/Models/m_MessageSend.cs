using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Backup.ClassLibrary.Models;
using Backup.ClassLibrary.Entity;

namespace BackOffice.WebAPI.Models
{
    public class m_MessageSend
    {
        public string visual_host = FilterConfig.IsDebugMode ? "http://localhost:4200" : "http://9t.com";


        public string VerifyPayanAccountTemp(string name, string UrlVerifiedEmail)
        {
            string HTML = @"<section>
                            <div style='margin: auto;'>
                              <div style='width: 500px; margin: auto;'>
                                <div style='border: 2px solid #2C314F; padding-left: 20px; padding-top: 10px; padding-bottom: 10px; font-size: 20px; font-weight: 900;'><img src='" + this.visual_host + "/images/logo.png" + @"' style='width: 35px; height: 33.7px;'><span style='position: relative; top: -6px; margin: 0px 10px;'>9T</span></div>
                                <div style='position: relative; bottom: 3px;'>
                                  <div style='border: 2px solid #2C314F; border-top: none; padding: 1px 0px'>
                                    <div style='font-size: 20px; margin: 3px 30px; word-wrap: break-word; font-weight: 500; color: #2C314F; padding-top: 20px;'>
                                      WELCOME
                                      <hr>
                                      <div style='color: #AAAAAA; font-size: 16px;'>
                                        <p>Name: <span style='color: #2C314F;'>" + name + @"</span> </p>
                                        <p>Company: <span style='color: #2C314F;'>Addlink co.,ltd.</span></p>
                                        <p>Tel: <span style='color: #2C314F;'>+66(0)45-959612</span></p>
                                      </div>
                                      <hr>
                                      <div style='color: #AAAAAA; font-size: 16px;'>
                                        Your account has now been created.please click the button to complete verification.
                                      </div>
                                      <br>
                                      <a href='" + this.visual_host + UrlVerifiedEmail + @"'><button style='background-color: #7ACDCF; border: 1px solid #7ACDCF ;color: #ffffff; width:226px; height: 40px; line-height: 25px; border-radius: 40px;font-weight: 500; border-width: 2px;outline: none !important; transition: all 0.2s; cursor: pointer;' type='submit'>VERIFY EMAIL</button></a>
                                      <br>
                                      <hr>
                                      <div>
                                       <div style='color: #7ACDCF;'>                                                 
                                <a href='http://9t.com' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Website</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Sales</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Support</span></a>                                              
                             </div>
                                        <div style='color: #AAAAAA;font-size: 12px; margin-bottom: 25px;'>
                                          <p>Phone +66(0)45-959612 Thailand</p>
                                          <p>Phone +885(0)974919241(Mr. Jong) Cambodia</p>
                                          <p>Avesta Company , Addlink building 889 Moo 5 Kamyai Sub-Distric Muang Ubon Ratchathani Ubon Ratchathani 34000</p>
                                          <p>Ubon Ratchathani, Thailand, 34000</p>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </section>";
            return HTML;
        }

        public string ResetPasswordCustomerLink(Guid token, string Email)
        {
            return $@"
                    <section>
                    <div style='margin: auto;'>
                        <div style=' width: 480px;
                                margin: auto;
                                margin-top: 52px;'>
                            <div style='border: 2px solid #2C314F; padding-left: 20px; padding-top: 10px; padding-bottom: 10px; font-size: 20px; font-weight: 900;'><img src='{this.visual_host}/images/logo.png' style='width: 35px; height: 33.7px;'><span style='position: relative; top: -6px; margin: 0px 10px;'>9T</span></div>
                            <div style='position: relative; bottom: 3px;'>
                                <div style='border: 2px solid #2C314F; border-top: none; padding: 1px 0px'>
                                    <div style=' font-size: 20px;
                                        margin: 3px 30px;
                                        word-wrap: break-word;
                                        font-weight: 500; color: #2C314F; padding-top: 20px;'>
                                        <div style='margin-bottom: 25px;'>
                                            SET PASSWORD
                                        </div>
                                        <hr>
                                        <div style='color: #AAAAAA; font-size: 16px; font-weight: 400;'>
                                            <p>Your account has been created. Please, set your own <br>password for access to your account.</p>
                                        </div>
                                        <h5>Login: {Email}</h5>
                                        <br>
                                        <a href='{this.visual_host}/restore-password/{token}' style='background-color: #7ACDCF; 
                                                        display:block;
                                                        text-decoration: none;
                                                        text-align:center;
                                                        border: 1px solid #7ACDCF ;
                                                        color: #ffffff; width:226px; 
                                                        height: 36px; 
                                                        line-height: 36px; 
                                                        border-radius: 40px;
                                                        font-weight: 500; 
                                                        border-width: 2px;
                                                        outline: none !important; 
                                                        transition: all 0.2s; 
                                                        cursor: pointer;'>SET PASSWORD</a>
                                        <br>
                                        <br>
                                        <p style=' color: #7ACDCF; font-size: 16px; font-weight: 400; margin-bottom: 25px;'>If it was not your action, please contact</p>
                                        <hr>
                                        <div>
                                           <div style='color: #7ACDCF;'>                                                 
                                <a href='http://9t.com' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Website</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Sales</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Support</span></a>                                              
                             </div>
                                            <div style=' color: #AAAAAA;font-size: 12px; margin-bottom: 25px;'>
                                                <p>Phone +66(0)45-959612 Thailand</p>
                                <p>Phone +885(0)974919241(Mr. Jong) Cambodia</p>
                                <p>Avesta Company , Addlink building 889 Moo 5 Kamyai Sub-Distric Muang Ubon Ratchathani Ubon Ratchathani 34000</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>";
        }

        public string InvoiceBodyTemplateEnterpirse(getInvoiceEmailBody values)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<section>
                        <div style='border: 2px solid #2C314F; padding: 15px 35px; border-bottom: none; width: 500px;'>
                            <a href='" + this.visual_host + @"' style='text-decoration:none;'>
                                <img style='width: 39px; height: 34px;' src='" + this.visual_host + @"/images/logo.png'>
                            </a>
                            <span style='font-size: 20px; font-weight: 900; position: relative; top: -7px;'>9T</span>
                        </div>
                        <div style='border: 2px solid #2C314F; padding: 15px 35px; width: 500px;'>
                            <h3 style='text-align: center;'>YOUR REQUEST HAS BEEN PROCESSED</h3>
                            <hr>
                            <div style='font-size: 16px; font-weight: 400; color: #AAAAAA;'>
                                <p>Dear, " + values.CustomerName + @" </p>
                                <p>Package for Offsite Backup was created.</p>
                                <p>In attachment you can find invoice and requisites for </p>
                                <p>payment</p>
                                <p style='margin: 22px 0px; color: #2C314F;'>Configuration:</p>
                                <p>VM License: <span style='margin-left: 20px; color:#2C314F;'>" + values.VMLicense + @"</span></p>
                                <p>Storage: <span style='margin-left: 48px; color:#2C314F;'>" + values.Storage + @"GB</span></p>
                                <br>
                                <p style='font-size: 13px; font-weight: 400; color: #2C314F;'>Login and password for cloud connect - <span style='color:#7ACDCF;'><a href='" + this.visual_host + @"/backup/" + values.vcc_id + @"'>link</a></span></p>
                                <br><br>
                                <p style='color:#2C314F;'>LINKS:</p>
                                <a href='" + this.visual_host + @"/support' style='text-decoration: none;color:#7ACDCF;'>Support page</a><br><br>
                                <a href='" + this.visual_host + @"/terms' style='text-decoration: none;color:#7ACDCF;'>Terms & Conditions</a><br><br>
                                <a href='" + this.visual_host + @"/refund-policy' style='text-decoration: none;color:#7ACDCF;'>Refund policy</a>
                            </div>
                            <hr>
                            <div style='color: #7ACDCF;'>                                                 
                                <a href='http://9t.com' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Website</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Sales</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Support</span></a>                                              
                             </div>
                            <br>
                            <div style='color: #AAAAAA; font-size: 12px; font-weight: 400;'>
                                <p>Phone +66(0)45-959612 Thailand</p>
                                <p>Phone +885(0)974919241(Mr. Jong) Cambodia</p>
                                <p>Avesta Company , Addlink building 889 Moo 5 Kamyai Sub-Distric Muang Ubon Ratchathani Ubon Ratchathani 34000</p>
                            </div>
                        </div>
                        </<section>");
            return sb.ToString();
        }
        public string InvoiceBodyTemplateEnterpirseReplication(getInvoiceEmailBodyReplication values)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<section>
                        <div style='border: 2px solid #2C314F; padding: 15px 35px; border-bottom: none; width: 500px;'>
                            <a href='" + this.visual_host + @"' style='text-decoration:none;'>
                                <img style='width: 39px; height: 34px;' src='https://9t.com/assets/images/9t%20logo.svg'>
                            </a>
                            <span style='font-size: 20px; font-weight: 900; position: relative; top: -7px;'>9T</span>
                        </div>
                        <div style='border: 2px solid #2C314F; padding: 15px 35px; width: 500px;'>
                            <h3 style='text-align: center;'>YOUR REQUEST HAS BEEN PROCESSED</h3>
                            <hr>
                            <div style='font-size: 16px; font-weight: 400; color: #AAAAAA;'>
                                <p>Dear, " + values.CustomerName + @" </p>
                                <p>Package for Offsite Backup was created.</p>
                                <p>In attachment you can find invoice and requisites for </p>
                                <p>payment</p>
                                <p style='margin: 22px 0px; color: #2C314F;'>Configuration:</p>
                                <p>VM License: <span style='margin-left: 20px; color:#2C314F;'>" + values.VMLicense + @" Vm</span></p>
                                <p>Storage: <span style='margin-left: 48px; color:#2C314F;'>" + values.Storage + @"GB</span></p>
                                <p>Processor: <span style='margin-left: 20px; color:#2C314F;'>" + values.processor + @" Vm</span></p>
                                <p>Ram: <span style='margin-left: 48px; color:#2C314F;'>" + values.ram + @"GB</span></p>
                                <p>Ip address: <span style='margin-left: 20px; color:#2C314F;'>" + values.ip_address + @" Vm</span></p>
                                <p>Networks: <span style='margin-left: 48px; color:#2C314F;'>" + values.networks + @"GB</span></p>
                                <p>Internet traffic: <span style='margin-left: 48px; color:#2C314F;'>" + values.traffic + @"GB</span></p>
                                <br>
                                <p style='font-size: 13px; font-weight: 400; color: #2C314F;'>Login and password for cloud connect - <span style='color:#7ACDCF;'><a href='" + this.visual_host + @"/backup/" + values.vcc_id + @"'>link</a></span></p>
                                <br><br>
                                <p style='color:#2C314F;'>LINKS:</p>
                                <a href='" + this.visual_host + @"/support' style='text-decoration: none;color:#7ACDCF;'>Support page</a><br><br>
                                <a href='" + this.visual_host + @"/terms' style='text-decoration: none;color:#7ACDCF;'>Terms & Conditions</a><br><br>
                                <a href='" + this.visual_host + @"/refund-policy' style='text-decoration: none;color:#7ACDCF;'>Refund policy</a>
                            </div>
                            <hr>
                            <div style='color: #7ACDCF;'>                                                 
                                <a href='http://9t.com' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Website</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Sales</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Support</span></a>                                              
                             </div>
                            <br>
                            <div style='color: #AAAAAA; font-size: 12px; font-weight: 400;'>
                                <p>Phone +66(0)45-959612 Thailand</p>
                                <p>Phone +885(0)974919241(Mr. Jong) Cambodia</p>
                                <p>Avesta Company , Addlink building 889 Moo 5 Kamyai Sub-Distric Muang Ubon Ratchathani Ubon Ratchathani 34000</p>
                            </div>
                        </div>
                        </<section>");
            return sb.ToString();
        }

        public string InvoiceAttachmentsTemplateEnterprise(vBOviewInvoiceTab req)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                    <style>
                        .hr { position: relative; top: -19px; margin-bottom: 0px; }
                        .hr-color { border-color: #2C314F; }
                        .col-sm-6 { padding: 0px; margin: 0px; }    
                        .col-sm-6 .btn { width: 149px;  height: 40px; }
                        .col-sm-6 .btn i { position: relative; left:-15px; }
                        .col-sm-6 .btn span { position: relative; top:-5px;}
                        .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                        .btn-primary { min-width: 100px; margin-top: 20px; }                         
                        .text-left { text-align:left; }    
                        .text-right{ text-align:right; }
                        .text-center { text-align: center; }    
                        .footer { margin-top: 173px; text-align: center;}    
                        .text-24-5 { font-size: 24px; font-weight: 500; }    
                        .text-20-5 { font-size: 20px; font-weight: 500; }    
                        .text-20-4 { font-size: 20px; font-weight: 400; }    
                        .text-12-4 { font-size: 12px; font-weight: 400; }    
                        .color-A { color: #AAAAAA; }
                        .color-7A { color: #7ACDCF; }    
                        .color-2C { color: #2C314F; }    
                        table, .row { width: 95%; margin: auto; }    
                        .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                        .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                        .tr-1 p > button span { position: relative; top: -3px; }    
                        .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span { padding-right: 4px; }    
                        .tr-1 td { font-size: 12px; font-weight: 500; }    
                        .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                        td { font-size: 16px; font-weight: 400; }    
                        .td-1 { width: 34%; }    
                        .td-2 { width: 12%; }    
                        .td-3 { width: 12%; }    
                        .td-4 { width: 7%;  }    
                        .td-5 { width: 12%; }    
                        .group-pck span { line-height: 0.428571; }
                        section { font-family: Roboto, Prompt, sans-serif; }    
                        @media print
                        {
                            tr * { font-size: 12px !important; }
                            .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                            .tr-1 td { font-size: 12px; font-weight: 500; }
                            .tr-1 td p > span{ padding-right: 4px; }
                            button { margin-left: 2px;  background-color: #2C314F; color: white; }
                            button span { position: relative;  top: -5px; }
                            .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                            .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                            .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                            #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                        }
    
                        @media screen and(max-width:768px)
                        {
                            .td-5 { text-align: right; }
                            .btn-primary { margin-right: 20px; }
                            .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                            .col-sm-6.btn-float i { left: -4px; }
                        }
                    </style>
                    <section class='printable'>
                        <div class='media-form'>
                            <div class='row row-width'>
                                <div class='col-sm-6 center-text'>
                                    <div class='form-group'>
                                        <p class='text-24-5'>INVOICES<span>#" + req.invoice_no + @"</span></p>
                                    </div>
                                </div>
                            </div>
                            <div class='border-color-top'></div>
                            <div class='row'>
                                <div class='col-sm-6 text-left pull-left'>
                                    <p class='text-20-4'>9T co., ltd.</p>
                                    <p class='text-12-4 color-A'>
                                        Avesta Company, Addlink building 889 Moo 5
                                        <br> Kamyai Sub-District, Ubon Ratchathani
                                        <br> Thailand 34000
                                        <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                    </p>
                                </div>
                                <div class='col-sm-6 text-right pull-right'>
                                    <div class=''>
                                        <p class='text-20-4'>" + req.company_name + @"</p>
                                        <p class='text-12-4 color-A'>
                                            " + req.firstname + ' ' + req.lastname + @"
                                            <br> " + req.address + @"
                                            <br> " + req.city + @", " + req.province + @"
                                            <br> " + req.country + @" " + req.post_code + @"
                                            <span class='color-7A'>
                                            <br>
                                            " + req.email + @"
                                            <br>
                                            " + req.phone_num + @"
                                        </span>
                                        </p>
                                    </div>
                                    <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.invoice_no + @"</span></p>
                                    <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + req.issued + @"</span></p>
                                    <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + req.due + @"</span></p>
                                </div>
                            </div>
                            <table>
                                <tr class='tr-1'>
                                    <td class='td-1'>DESCRIPTION</td>
                                    <td class='td-2'>COUNT QTY</td>
                                    <td class='td-3'>FROM</td>
                                    <td class='td-4'>TO</td>
                                    <td class='td-5'>PRICE(inc GST)</td>
                                </tr>
                                <tbody* ngFor='let item Of data'>
                                    <tr class='tr-1'>
                                        <td colspan='5'>
                                            <br >
                                            <p class='color-7A hidden-xs'>VEEAM(Cloud Connect Backup(" + req.username + @"))</p>
                                            <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>VEEAM(Cloud Connect Backup (" + req.username + @"))</p>
                                            <p class='group-pck'>
                                                <span class='text-12-4'>Alias: 
                                                     <button type='button' class='btn-1 btn btn-default'><span>" + req.name + @"</span></button>
                                                </span>
                                                <br/>
                                                <br>
                                                <span class='text-12-4'>VM licenses: 
                                                     <button type='button' class='btn-2 btn btn-default'><span>" + req.vm + @" licenses</span></button>
                                                </span>
                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.storage + @"GB</span></button>
                                                </span>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td colspan='2'> Cloud Connect</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>$0.00</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>Storage</td>
                                        <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.storage + @"GB</td>
                                        <td class='td-2 color-A hidden-xs'>" + req.storage + @" GB</td>
                                        <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + req.storage_total_price.Value.ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>VM licenses</td>
                                        <td class='td-2 color-A'>" + req.vm + @"</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + req.vm_total_price.Value.ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'>Sub-Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                        <td class='td-5 text-center'>" + (req.vm_total_price.Value + req.storage_total_price.Value).ToString("C2") + @"</td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Fees(7%)</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                        <td class='td-5 text-center'>" + req.fees.Value.ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                        <td class='td-5 text-center'>" + (req.vm_total_price.Value + req.storage_total_price.Value).ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Invoice Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                        <td class='td-5 text-center'>" + (req.storage_total_price.Value + req.vm_total_price.Value + req.fees.Value).ToString("C2") + @"</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </section>");

            return sb.ToString();
        }
        public string NewGennerateInvoiceAttachmentsTemplateEnterprise(getInvoicesDetail_NewInvoBO req)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                    <style>
                        .hr { position: relative; top: -19px; margin-bottom: 0px; }
                        .hr-color { border-color: #2C314F; }
                        .col-sm-6 { padding: 0px; margin: 0px; }    
                        .col-sm-6 .btn { width: 149px;  height: 40px; }
                        .col-sm-6 .btn i { position: relative; left:-15px; }
                        .col-sm-6 .btn span { position: relative; top:-5px;}
                        .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                        .btn-primary { min-width: 100px; margin-top: 20px; }                         
                        .text-left { text-align:left; }    
                        .text-right{ text-align:right; }
                        .text-center { text-align: center; }    
                        .footer { margin-top: 173px; text-align: center;}    
                        .text-24-5 { font-size: 24px; font-weight: 500; }    
                        .text-20-5 { font-size: 20px; font-weight: 500; }    
                        .text-20-4 { font-size: 20px; font-weight: 400; }    
                        .text-12-4 { font-size: 12px; font-weight: 400; }    
                        .color-A { color: #AAAAAA; }
                        .color-7A { color: #7ACDCF; }    
                        .color-2C { color: #2C314F; }    
                        table, .row { width: 95%; margin: auto; }    
                        .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                        .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                        .tr-1 p > button span { position: relative; top: -3px; }    
                        .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span { padding-right: 4px; }    
                        .tr-1 td { font-size: 12px; font-weight: 500; }    
                        .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                        td { font-size: 16px; font-weight: 400; }    
                        .td-1 { width: 34%; }    
                        .td-2 { width: 12%; }    
                        .td-3 { width: 12%; }    
                        .td-4 { width: 7%;  }    
                        .td-5 { width: 12%; }    
                        .group-pck span { line-height: 0.428571; }
                        section { font-family: Roboto, Prompt, sans-serif; }    
                        @media print
                        {
                            tr * { font-size: 12px !important; }
                            .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                            .tr-1 td { font-size: 12px; font-weight: 500; }
                            .tr-1 td p > span{ padding-right: 4px; }
                            button { margin-left: 2px;  background-color: #2C314F; color: white; }
                            button span { position: relative;  top: -5px; }
                            .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                            .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                            .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                            #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                        }
    
                        @media screen and(max-width:768px)
                        {
                            .td-5 { text-align: right; }
                            .btn-primary { margin-right: 20px; }
                            .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                            .col-sm-6.btn-float i { left: -4px; }
                        }
                    </style>
                    <section class='printable'>
                        <div class='media-form'>
                            <div class='row row-width'>
                                <div class='col-sm-6 center-text'>
                                    <div class='form-group'>
                                        <p class='text-24-5'>INVOICES<span>#" + req.invoice_no + @"</span></p>
                                    </div>
                                </div>
                            </div>
                            <div class='border-color-top'></div>
                            <div class='row'>
                                <div class='col-sm-6 text-left pull-left'>
                                    <p class='text-20-4'>9T co., ltd.</p>
                                    <p class='text-12-4 color-A'>
                                        Avesta Company, Addlink building 889 Moo 5
                                        <br> Kamyai Sub-District, Ubon Ratchathani
                                        <br> Thailand 34000
                                        <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                    </p>
                                </div>
                                <div class='col-sm-6 text-right pull-right'>
                                    <div class=''>
                                        <p class='text-20-4'>" + req.company_name + @"</p>
                                        <p class='text-12-4 color-A'>
                                            " + req.firstname + ' ' + req.lastname + @"
                                            <br> " + req.address + @"
                                            <br> " + req.city + @", " + req.province + @"
                                            <br> " + req.country + @" " + req.post_code + @"
                                            <span class='color-7A'>
                                            <br>
                                            " + req.email + @"
                                            <br>
                                            " + req.phone_num + @"
                                        </span>
                                        </p>
                                    </div>
                                    <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.invoice_no + @"</span></p>
                                    <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + req.issued + @"</span></p>
                                    <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + req.due + @"</span></p>
                                </div>
                            </div>
                            <table>
                                <tr class='tr-1'>
                                    <td class='td-1'>DESCRIPTION</td>
                                    <td class='td-2'>COUNT QTY</td>
                                    <td class='td-3'>FROM</td>
                                    <td class='td-4'>TO</td>
                                    <td class='td-5'>PRICE(inc GST)</td>
                                </tr>
                                <tbody* ngFor='let item Of data'>
                                    <tr class='tr-1'>
                                        <td colspan='5'>
                                            <br >
                                            <p class='color-7A hidden-xs'>VEEAM(Cloud Connect Backup(" + req.username + @"))</p>
                                            <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>VEEAM(Cloud Connect Backup (" + req.username + @"))</p>
                                            <p class='group-pck'>
                                                <span class='text-12-4'>Alias: 
                                                     <button type='button' class='btn-1 btn btn-default'><span>" + req.name + @"</span></button>
                                                </span>
                                                <br/>
                                                <br>
                                                <span class='text-12-4'>VM licenses: 
                                                     <button type='button' class='btn-2 btn btn-default'><span>" + req.vm + @" licenses</span></button>
                                                </span>
                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.storage + @"GB</span></button>
                                                </span>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td colspan='2'> Cloud Connect</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>$0.00</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>Storage</td>
                                        <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.storage + @"GB</td>
                                        <td class='td-2 color-A hidden-xs'>" + req.storage + @" GB</td>
                                        <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + req.storage_total_price.ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>VM licenses</td>
                                        <td class='td-2 color-A'>" + req.vm + @"</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + req.vm_total_price.ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'>Sub-Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                        <td class='td-5 text-center'>" + (req.vm_total_price + req.storage_total_price).ToString("C2") + @"</td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Fees(7%)</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                        <td class='td-5 text-center'>" + req.fees.ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Discount</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                        <td class='td-5 text-center'>" + req.discount.ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                        <td class='td-5 text-center'>" + (req.vm_total_price + req.storage_total_price).ToString("C2") + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Invoice Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                        <td class='td-5 text-center'>" + ((req.storage_total_price + req.vm_total_price + req.fees) - req.discount).ToString("C2") + @"</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </section>");

            return sb.ToString();
        }
        public string NewGennerateInvoiceAttachmentsTemplateEnterpriseVR(getInvoicesDetail_Rep_saveAndUpgrade req)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                    <style>
                        .hr { position: relative; top: -19px; margin-bottom: 0px; }
                        .hr-color { border-color: #2C314F; }
                        .col-sm-6 { padding: 0px; margin: 0px; }    
                        .col-sm-6 .btn { width: 149px;  height: 40px; }
                        .col-sm-6 .btn i { position: relative; left:-15px; }
                        .col-sm-6 .btn span { position: relative; top:-5px;}
                        .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                        .btn-primary { min-width: 100px; margin-top: 20px; }                         
                        .text-left { text-align:left; }    
                        .text-right{ text-align:right; }
                        .text-center { text-align: center; }    
                        .footer { margin-top: 173px; text-align: center;}    
                        .text-24-5 { font-size: 24px; font-weight: 500; }    
                        .text-20-5 { font-size: 20px; font-weight: 500; }    
                        .text-20-4 { font-size: 20px; font-weight: 400; }    
                        .text-12-4 { font-size: 12px; font-weight: 400; }    
                        .color-A { color: #AAAAAA; }
                        .color-7A { color: #7ACDCF; }    
                        .color-2C { color: #2C314F; }    
                        table, .row { width: 95%; margin: auto; }    
                        .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                        .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                        .tr-1 p > button span { position: relative; top: -3px; }    
                        .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                        .tr-1 p > span { padding-right: 4px; }    
                        .tr-1 td { font-size: 12px; font-weight: 500; }    
                        .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                        td { font-size: 16px; font-weight: 400; }    
                        .td-1 { width: 34%; }    
                        .td-2 { width: 12%; }    
                        .td-3 { width: 12%; }    
                        .td-4 { width: 7%;  }    
                        .td-5 { width: 12%; }    
                        .group-pck span { line-height: 0.428571; }
                        section { font-family: Roboto, Prompt, sans-serif; }    
                        @media print
                        {
                            tr * { font-size: 12px !important; }
                            .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                            .tr-1 td { font-size: 12px; font-weight: 500; }
                            .tr-1 td p > span{ padding-right: 4px; }
                            button { margin-left: 2px;  background-color: #2C314F; color: white; }
                            button span { position: relative;  top: -5px; }
                            .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                            .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                            .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                            #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                        }
    
                        @media screen and(max-width:768px)
                        {
                            .td-5 { text-align: right; }
                            .btn-primary { margin-right: 20px; }
                            .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                            .col-sm-6.btn-float i { left: -4px; }
                        }
                    </style>
                    <section class='printable'>
                        <div class='media-form'>
                            <div class='row row-width'>
                                <div class='col-sm-6 center-text'>
                                    <div class='form-group'>
                                        <p class='text-24-5'>INVOICES<span>#" + req.invoice_no + @"</span></p>
                                    </div>
                                </div>
                            </div>
                            <div class='border-color-top'></div>
                            <div class='row'>
                                <div class='col-sm-6 text-left pull-left'>
                                    <p class='text-20-4'>9T co., ltd.</p>
                                    <p class='text-12-4 color-A'>
                                        Avesta Company, Addlink building 889 Moo 5
                                        <br> Kamyai Sub-District, Ubon Ratchathani
                                        <br> Thailand 34000
                                        <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                    </p>
                                </div>
                                <div class='col-sm-6 text-right pull-right'>
                                    <div class=''>
                                        <p class='text-20-4'>" + req.company_name + @"</p>
                                        <p class='text-12-4 color-A'>
                                            " + req.firstname + ' ' + req.lastname + @"
                                            <br> " + req.address + @"
                                            <br> " + req.city + @", " + req.province + @"
                                            <br> " + req.country + @" " + req.post_code + @"
                                            <span class='color-7A'>
                                            <br>
                                            " + req.email + @"
                                            <br>
                                            " + req.phone_num + @"
                                        </span>
                                        </p>
                                    </div>
                                    <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.invoice_no + @"</span></p>
                                    <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + req.issued + @"</span></p>
                                    <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + req.due + @"</span></p>
                                </div>
                            </div>
                            <table>
                                <tr class='tr-1'>
                                    <td class='td-1'>DESCRIPTION</td>
                                    <td class='td-2'>COUNT QTY</td>
                                    <td class='td-3'>FROM</td>
                                    <td class='td-4'>TO</td>
                                    <td class='td-5'>PRICE(inc GST)</td>
                                </tr>
                                <tbody* ngFor='let item Of data'>
                                    <tr class='tr-1'>
                                        <td colspan='5'>
                                            <br >
                                            <p class='color-7A hidden-xs'>VEEAM(Cloud Connect Backup(" + req.username + @"))</p>
                                            <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>VEEAM(Cloud Connect Backup (" + req.username + @"))</p>
                                            <p class='group-pck'>
                                                <span class='text-12-4'>Alias: 
                                                     <button type='button' class='btn-1 btn btn-default'><span>" + req.name + @"</span></button>
                                                </span>
                                                <br/>
                                                <br>
                                                <span class='text-12-4'>VM licenses: 
                                                     <button type='button' class='btn-2 btn btn-default'><span>" + req.vm + @" licenses</span></button>
                                                </span>
                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.storage + @"GB</span></button>
                                                </span>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td colspan='2'> Cloud Connect</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>$0.00</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>Storage</td>
                                        <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.storage + @"GB</td>
                                        <td class='td-2 color-A hidden-xs'>" + req.storage + @" GB</td>
                                        <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.total_storage_price) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>VM licenses</td>
                                        <td class='td-2 color-A'>" + req.vm + @"</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.total_vm_price) + @"</td>
                                    </tr>
                                     <tr class='tr-2'>
                                        <td class='td-1'>Compute Processor</td>
                                        <td class='td-2 color-A'>" + req.processor + @" Ghz</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.total_processor_price) + @"</td>
                                    </tr>
                                     <tr class='tr-2'>
                                        <td class='td-1'>RAM</td>
                                        <td class='td-2 color-A'>" + req.ram + @" GB</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.total_ram_price) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>IP Addresses</td>
                                        <td class='td-2 color-A'>" + req.ip_address + @" Addresses</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.total_ip_address_price) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>Networks</td>
                                        <td class='td-2 color-A'>" + req.networks + @" Networks</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.total_networks_price) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'>Internet Traffic</td>
                                        <td class='td-2 color-A'>" + req.traffic + @" GB</td>
                                        <td class='td-3 color-A'><span class='hidden-xs'>" + req.pck_start_dt + @"</span></td>
                                        <td class='td-4 color-A'><span class='hidden-xs'>" + req.pck_end_dt + @"</span></td>
                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.total_traffic_price) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'>Sub-Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                        <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.total_ip_address_price +
                                                                   req.total_networks_price +
                                                                   req.total_processor_price +
                                                                   req.total_storage_price +
                                                                   req.total_traffic_price +
                                                                   req.total_vm_price +
                                                                   req.total_ram_price)) + @"</td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Discount</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                        <td class='td-5 text-center'>" + string.Format("{0:0.00}", req.discount) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Fees(7%)</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                        <td class='td-5 text-center'>" + string.Format("{0:0.00}", req.fees) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                        <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.total_ip_address_price +
                                                                   req.total_networks_price +
                                                                   req.total_processor_price +
                                                                   req.total_storage_price +
                                                                   req.total_traffic_price +
                                                                   req.total_vm_price +
                                                                   req.total_ram_price) + req.fees - req.discount) + @"</td>
                                    </tr>
                                    <tr class='tr-2'>
                                        <td class='td-1'></td>
                                        <td class='td-2 hidden-xs'></td>
                                        <td class='td-3 hidden-xs'></td>
                                        <td class='td-4 hidden-xs'>Invoice Total</td>
                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                        <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.total_ip_address_price +
                                                                   req.total_networks_price +
                                                                   req.total_processor_price +
                                                                   req.total_storage_price +
                                                                   req.total_traffic_price +
                                                                   req.total_vm_price +
                                                                   req.total_ram_price) + req.fees - req.discount) + @"</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </section>");

            return sb.ToString();
        }

        public string ResetPasswordReseller(int id, string password, Guid token)
        {
            return $@"
                    <section>
                    <div style='margin: auto;'>
                        <div style=' width: 480px;
                                margin: auto;
                                margin-top: 52px;'>
                            <div style='border: 2px solid #2C314F; padding-left: 20px; padding-top: 10px; padding-bottom: 10px; font-size: 20px; font-weight: 900;'><img src='{this.visual_host}/images/logo.png' style='width: 35px; height: 33.7px;'><span style='position: relative; top: -6px; margin: 0px 10px;'>9T</span></div>
                            <div style='position: relative; bottom: 3px;'>
                                <div style='border: 2px solid #2C314F; border-top: none; padding: 1px 0px'>
                                    <div style=' font-size: 20px;
                                        margin: 3px 30px;
                                        word-wrap: break-word;
                                        font-weight: 500; color: #2C314F; padding-top: 20px;'>
                                        <div style='margin-bottom: 25px;'>
                                            Welcome!
                                        </div>
                                        <hr>
                                        <div style='color: #AAAAAA; font-size: 16px; font-weight: 400;'>
                                            <p>Your account has been created. Please, set your own <br>password for access to your account.</p>
                                        </div>
                                        <p>Your ID:</p>
                                        <div style='color: #000000; font-size: 16px; font-weight: 400;'>
                                          <p>RES" + id + @"</p>
                                        </div>
                                        <p>Your Password:</p>
                                        <div style='color: #000000; font-size: 16px; font-weight: 400;'>
                                          <p>" + password + @"</p>
                                        </div>
                                        <br>
                                            <a href='http://r.9t.com/create-password/" + token + @"' style='background-color: #7ACDCF;margin-left: 150px;
                                            display:block;
                                            text-decoration: none;
                                            text-align:center;
                                            border: 1px solid #7ACDCF ;
                                            color: #ffffff; width:150px;
                                            height: 40px;
                                            line-height: 40px;
                                            border-radius: 40px;
                                            font-weight: 500;
                                            border-width: 2px;
                                            outline: none !important;
                                            transition: all 0.2s;
                                            cursor: pointer;'> Create Password</a>
                                        <br>
                                        <p style=' color: #7ACDCF; font-size: 16px; font-weight: 400; margin-bottom: 25px;'>If it was not your action, please contact</p>
                                        <hr>
                                        <div>
                                           <div style='color: #7ACDCF;'>                                                 
                                <a href='http://9t.com' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Website</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Sales</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Support</span></a>                                              
                             </div>
                                            <div style=' color: #AAAAAA;font-size: 12px; margin-bottom: 25px;'>
                                                <p>Phone +66(0)45-959612 Thailand</p>
                                <p>Phone +885(0)974919241(Mr. Jong) Cambodia</p>
                                <p>Avesta Company , Addlink building 889 Moo 5 Kamyai Sub-Distric Muang Ubon Ratchathani Ubon Ratchathani 34000</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>";
        }

        public string approve_Reseller(int id)
        {
            return $@"
                    <section>
                    <div style='margin: auto;'>
                        <div style=' width: 480px;
                                margin: auto;
                                margin-top: 52px;'>
                            <div style='border: 2px solid #2C314F; padding-left: 20px; padding-top: 10px; padding-bottom: 10px; font-size: 20px; font-weight: 900;'><img src='{this.visual_host}/images/logo.png' style='width: 35px; height: 33.7px;'><span style='position: relative; top: -6px; margin: 0px 10px;'>9T</span></div>
                            <div style='position: relative; bottom: 3px;'>
                                <div style='border: 2px solid #2C314F; border-top: none; padding: 1px 0px'>
                                    <div style=' font-size: 20px;
                                        margin: 3px 30px;
                                        word-wrap: break-word;
                                        font-weight: 500; color: #2C314F; padding-top: 20px;'>
                                        <div style='margin-bottom: 25px;'>
                                            Welcome!
                                        </div>
                                        <hr>
                                        <div style='color: #AAAAAA; font-size: 16px; font-weight: 400;'>
                                            <p>Your account has been created. Please, set your own <br>password for access to your account.</p>
                                        </div>
                                        <p>Your ID:</p>
                                        <div style='color: #000000; font-size: 16px; font-weight: 400;'>
                                          <p>RES" + id + @"</p>
                                        </div>
                                        <br>
                                            <a href='#' style='background-color: #7ACDCF;margin-left: 150px;
                                            display:block;
                                            text-decoration: none;
                                            text-align:center;
                                            border: 1px solid #7ACDCF ;
                                            color: #ffffff; width:150px;
                                            height: 40px;
                                            line-height: 40px;
                                            border-radius: 40px;
                                            font-weight: 500;
                                            border-width: 2px;
                                            outline: none !important;
                                            transition: all 0.2s;
                                            cursor: pointer;'>SETTING</a>
                                        <br>
                                        <p style=' color: #7ACDCF; font-size: 16px; font-weight: 400; margin-bottom: 25px;'>If it was not your action, please contact</p>
                                        <hr>
                                        <div>
                                           <div style='color: #7ACDCF;'>                                                 
                                <a href='http://9t.com' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Website</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Sales</span></a> |
                                <a href='http://9t.com/support/#footered' style='color:#7ACDCF; text-decoration:none'><span style='cursor: pointer;'>Email Support</span></a>                                              
                             </div>
                                            <div style=' color: #AAAAAA;font-size: 12px; margin-bottom: 25px;'>
                                                <p>Phone +66(0)45-959612 Thailand</p>
                                <p>Phone +885(0)974919241(Mr. Jong) Cambodia</p>
                                <p>Avesta Company , Addlink building 889 Moo 5 Kamyai Sub-Distric Muang Ubon Ratchathani Ubon Ratchathani 34000</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>";
        }
        #region invoice send email for upgrade
        #region for enterprise and normal user
        #region veeam backup
        public string InvoiceTemplateEnterpriseBackup(v_Get_InvoviceById_package_backup req,string sta)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                                    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                                    <style>
                                        .btn-4 { width: 50px; height: 20px; border-radius: 26px; }
                                        .hr { position: relative; top: -19px; margin-bottom: 0px; }
                                        .hr-color { border-color: #2C314F; }
                                        .col-sm-6 { padding: 0px; margin: 0px; }    
                                        .col-sm-6 .btn { width: 149px;  height: 40px; }
                                        .col-sm-6 .btn i { position: relative; left:-15px; }
                                        .col-sm-6 .btn span { position: relative; top:-5px;}
                                        .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                                        .btn-primary { min-width: 100px; margin-top: 20px; }                         
                                        .text-left { text-align:left; }    
                                        .text-right{ text-align:right; }
                                        .text-center { text-align: center; }    
                                        .footer { margin-top: 173px; text-align: center;}    
                                        .text-24-5 { font-size: 24px; font-weight: 500; }    
                                        .text-20-5 { font-size: 20px; font-weight: 500; }    
                                        .text-20-4 { font-size: 20px; font-weight: 400; }    
                                        .text-12-4 { font-size: 12px; font-weight: 400; }    
                                        .color-A { color: #AAAAAA; }
                                        .color-7A { color: #7ACDCF; }    
                                        .color-2C { color: #2C314F; }    
                                        table, .row { width: 95%; margin: auto; }    
                                        .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                                        .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                                        .tr-1 p > button span { position: relative; top: -3px; }    
                                        .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span { padding-right: 4px; }    
                                        .tr-1 td { font-size: 12px; font-weight: 500; }    
                                        .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                                        td { font-size: 16px; font-weight: 400; }    
                                        .td-1 { width: 34%; }    
                                        .td-2 { width: 12%; }    
                                        .td-3 { width: 12%; }    
                                        .td-4 { width: 7%;  }    
                                        .td-5 { width: 12%; }    
                                        .group-pck span { line-height: 0.428571; }
                                        section { font-family: Roboto, Prompt, sans-serif; }    
                                        @media print
                                        {
                                            tr * { font-size: 12px !important; }
                                            .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                                            .tr-1 td { font-size: 12px; font-weight: 500; }
                                            .tr-1 td p > span{ padding-right: 4px; }
                                            button { margin-left: 2px;  background-color: #2C314F; color: white; }
                                            button span { position: relative;  top: -5px; }
                                            .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                                            .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                                            .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                                            #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                                        }
    
                                        @media screen and(max-width:768px)
                                        {
                                            .td-5 { text-align: right; }
                                            .btn-primary { margin-right: 20px; }
                                            .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                                            .col-sm-6.btn-float i { left: -4px; }
                                        }
                                    </style>
                                    <section class='printable'>
                                        <div class='media-form'>
                                            <div class='row row-width'>
                                                <div class='col-sm-6 center-text'>
                                                    <div class='form-group' style='margin-top: 10px;'>
                                                        <p class='text-24-5'>INVOICES<span>#" + req.Invoice_no + @"</span> <button type='button' class='btn-4 btn btn-default'><span>" + sta + @"</span></button></p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='border-color-top'></div>
                                            <div class='row'>
                                                <div class='col-sm-6 text-left pull-left'>
                                                    <p class='text-20-4'>9T co., ltd.</p>
                                                    <p class='text-12-4 color-A'>
                                                        Avesta Company, Addlink building 889 Moo 5
                                                        <br> Kamyai Sub-District, Ubon Ratchathani
                                                        <br> Thailand 34000
                                                        <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                                    </p>
                                                </div>
                                                <div class='col-sm-6 text-right pull-right'>
                                                    <div class=''>
                                                        <p class='text-20-4'>" + req.Company + @"</p>
                                                        <p class='text-12-4 color-A'>
                                                            " + req.Firstname + ' ' + req.Lastname + @"
                                                            <br> " + req.Address + @"
                                                            <br> " + req.City + @", " + req.Province + @"
                                                            <br> " + req.Country + @" " + req.PostCode + @"
                                                            <span class='color-7A'>
                                                            <br>
                                                            " + req.Email + @"
                                                            <br>
                                                            " + req.PhoneNum + @"
                                                        </span>
                                                        </p>
                                                    </div>
                                                    <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.Invoice_no + @"</span></p>
                                                    <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + DateTime.Parse(req.Issued.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                    <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + DateTime.Parse(req.Due.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                </div>
                                            </div>
                                            <table>
                                                <tr class='tr-1' style='border-top: 1px solid #2c314f; border-bottom: 2px solid #2c314f;'>
                                                    <td class='td-1'>DESCRIPTION</td>
                                                    <td class='td-2'>COUNT QTY</td>
                                                    <td class='td-3'>FROM</td>
                                                    <td class='td-4'>TO</td>
                                                    <td class='td-5'>PRICE(inc GST)</td>
                                                </tr>
                                                <tbody* ngFor='let item Of data'>
                                                    <tr class='tr-1' style='border-bottom: 1px solid #2c314f;'>
                                                        <td colspan='5'>
                                                            <br >
                                                            <p class='color-7A hidden-xs'>VEEAM(Cloud Connect Backup(" + req.Username + @"))</p>
                                                            <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>VEEAM(Cloud Connect Backup (" + req.Username + @"))</p>
                                                            <p class='group-pck'>
                                                                <span class='text-12-4'>Alias: 
                                                                     <button type='button' class='btn-1 btn btn-default'><span>" + req.Alias + @"</span></button>
                                                                </span>
                                                                <br/>
                                                                <br>
                                                                <span class='text-12-4'>VM licenses: 
                                                                     <button type='button' class='btn-2 btn btn-default'><span>" + req.Vm + @" licenses</span></button>
                                                                </span>
                                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                                <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.Storage + @"GB</span></button>
                                                                </span>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td colspan='2'> Cloud Connect</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>$0.00</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>Storage</td>
                                                        <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.Storage + @"GB</td>
                                                        <td class='td-2 color-A hidden-xs'>" + req.Storage + @" GB</td>
                                                        <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + decimal.Parse(req.StoragePrice.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>VM licenses</td>
                                                        <td class='td-2 color-A'>" + req.Vm + @"</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + decimal.Parse(req.VmPrice.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'>Sub-Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse((req.SupTotal).ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                </tbody>
                                                <tbody>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Fees(7%)</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse(req.Fees.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Discount</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse(req.Discount.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Invoice Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </section>");

            return sb.ToString();
        }
        #endregion
        #region veeam replication
        public string InvoiceTemplateEnterpriseReplication(v_Get_InvoviceById_package_replication req,string sta)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                                    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                                    <style>
                                        .btn-4 { width: 50px; height: 20px; border-radius: 26px; }
                                        .hr { position: relative; top: -19px; margin-bottom: 0px; }
                                        .hr-color { border-color: #2C314F; }
                                        .col-sm-6 { padding: 0px; margin: 0px; }    
                                        .col-sm-6 .btn { width: 149px;  height: 40px; }
                                        .col-sm-6 .btn i { position: relative; left:-15px; }
                                        .col-sm-6 .btn span { position: relative; top:-5px;}
                                        .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                                        .btn-primary { min-width: 100px; margin-top: 20px; }                         
                                        .text-left { text-align:left; }    
                                        .text-right{ text-align:right; }
                                        .text-center { text-align: center; }    
                                        .footer { margin-top: 173px; text-align: center;}    
                                        .text-24-5 { font-size: 24px; font-weight: 500; }    
                                        .text-20-5 { font-size: 20px; font-weight: 500; }    
                                        .text-20-4 { font-size: 20px; font-weight: 400; }    
                                        .text-12-4 { font-size: 12px; font-weight: 400; }    
                                        .color-A { color: #AAAAAA; }
                                        .color-7A { color: #7ACDCF; }    
                                        .color-2C { color: #2C314F; }    
                                        table, .row { width: 95%; margin: auto; }    
                                        .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                                        .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                                        .tr-1 p > button span { position: relative; top: -3px; }    
                                        .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span { padding-right: 4px; }    
                                        .tr-1 td { font-size: 12px; font-weight: 500; }    
                                        .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                                        td { font-size: 16px; font-weight: 400; }    
                                        .td-1 { width: 34%; }    
                                        .td-2 { width: 12%; }    
                                        .td-3 { width: 12%; }    
                                        .td-4 { width: 7%;  }    
                                        .td-5 { width: 12%; }    
                                        .group-pck span { line-height: 0.428571; }
                                        section { font-family: Roboto, Prompt, sans-serif; }    
                                        @media print
                                        {
                                            tr * { font-size: 12px !important; }
                                            .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                                            .tr-1 td { font-size: 12px; font-weight: 500; }
                                            .tr-1 td p > span{ padding-right: 4px; }
                                            button { margin-left: 2px;  background-color: #2C314F; color: white; }
                                            button span { position: relative;  top: -5px; }
                                            .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                                            .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                                            .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                                            #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                                        }
    
                                        @media screen and(max-width:768px)
                                        {
                                            .td-5 { text-align: right; }
                                            .btn-primary { margin-right: 20px; }
                                            .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                                            .col-sm-6.btn-float i { left: -4px; }
                                        }
                                    </style>
                                    <section class='printable'>
                                        <div class='media-form'>
                                            <div class='row row-width'>
                                                <div class='col-sm-6 center-text'>
                                                    <div class='form-group' style='margin-top: 10px;'>
                                                        <p class='text-24-5'>INVOICES<span>#" + req.Invoice_no + @"</span> <button type='button' class='btn-4 btn btn-default'><span>" + sta + @"</span></button></p>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='border-color-top'></div>
                                            <div class='row'>
                                                <div class='col-sm-6 text-left pull-left'>
                                                    <p class='text-20-4'>9T co., ltd.</p>
                                                    <p class='text-12-4 color-A'>
                                                        Avesta Company, Addlink building 889 Moo 5
                                                        <br> Kamyai Sub-District, Ubon Ratchathani
                                                        <br> Thailand 34000
                                                        <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                                    </p>
                                                </div>
                                                <div class='col-sm-6 text-right pull-right'>
                                                    <div class=''>
                                                        <p class='text-20-4'>" + req.Company + @"</p>
                                                        <p class='text-12-4 color-A'>
                                                            " + req.Firstname + ' ' + req.Lastname + @"
                                                            <br> " + req.Address + @"
                                                            <br> " + req.Company + @", " + req.Province + @"
                                                            <br> " + req.Country + @" " + req.PostCode + @"
                                                            <span class='color-7A'>
                                                            <br>
                                                            " + req.Email + @"
                                                            <br>
                                                            " + req.PhoneNum + @"
                                                        </span>
                                                        </p>
                                                    </div>
                                                    <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.Invoice_no + @"</span></p>
                                                    <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + req.Issued.ToString("dd/MM/yyyy") + @"</span></p>
                                                    <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + DateTime.Parse(req.Due.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                </div>
                                            </div>
                                            <table>
                                                <tr class='tr-1' style='border-top: 1px solid #2c314f; border-bottom: 2px solid #2c314f;'>
                                                    <td class='td-1'>DESCRIPTION</td>
                                                    <td class='td-2'>COUNT QTY</td>
                                                    <td class='td-3'>FROM</td>
                                                    <td class='td-4'>TO</td>
                                                    <td class='td-5'>PRICE(inc GST)</td>
                                                </tr>
                                                <tbody* ngFor='let item Of data'>
                                                    <tr class='tr-1' style='border-bottom: 1px solid #2c314f;'>
                                                        <td colspan='5'>
                                                            <br >
                                                            <p class='color-7A hidden-xs'>VEEAM(Cloud Connect Backup(" + req.Username + @"))</p>
                                                            <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>VEEAM(Cloud Connect Backup (" + req.Username + @"))</p>
                                                            <p class='group-pck'>
                                                                <span class='text-12-4'>Alias: 
                                                                     <button type='button' class='btn-1 btn btn-default'><span>" + req.Alias + @"</span></button>
                                                                </span>
                                                                <br/>
                                                                <br>
                                                                <span class='text-12-4'>VM licenses: 
                                                                     <button type='button' class='btn-2 btn btn-default'><span>" + req.Vm + @" licenses</span></button>
                                                                </span>
                                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                                <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.Storage + @"GB</span></button>
                                                                </span>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td colspan='2'> Cloud Connect</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>$0.00</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>Storage</td>
                                                        <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.Storage + @"GB</td>
                                                        <td class='td-2 color-A hidden-xs'>" + req.Storage + @" GB</td>
                                                        <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.StoragePrice) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>VM licenses</td>
                                                        <td class='td-2 color-A'>" + req.Vm + @"</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.VmPrice) + @"</td>
                                                    </tr>
                                                     <tr class='tr-2'>
                                                        <td class='td-1'>Compute Processor</td>
                                                        <td class='td-2 color-A'>" + req.Processor + @" Ghz</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.ProcessorPrice) + @"</td>
                                                    </tr>
                                                     <tr class='tr-2'>
                                                        <td class='td-1'>RAM</td>
                                                        <td class='td-2 color-A'>" + req.Ram + @" GB</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.RamPrice) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>IP Addresses</td>
                                                        <td class='td-2 color-A'>" + req.IpAddress + @" Addresses</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.IpAddressPrice) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>Networks</td>
                                                        <td class='td-2 color-A'>" + req.Networks + @" Networks</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.NetworksPrice) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>Internet Traffic</td>
                                                        <td class='td-2 color-A'>" + req.Traffic + @" GB</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.TrafficPrice) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'>Sub-Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                                        <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.SupTotal)) + @"</td>
                                                    </tr>
                                                </tbody>
                                                <tbody>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Discount</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                                        <td class='td-5 text-center'>" + string.Format("{0:0.00}", req.Discount) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Fees(7%)</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                                        <td class='td-5 text-center'>" + string.Format("{0:0.00}", req.Fees) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                                        <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.Total)) + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Invoice Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                                        <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.Total)) + @"</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </section>");

            return sb.ToString();
        }
        #endregion
        #endregion
        #region for resaller
        #region veeam backup
        public string InvoiceTemplateResallerBackup(v_Get_InvoviceById_package_backup_resaller req,string sta)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                                            <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                                            <style>
                                                .btn-4 { width: 50px; height: 20px; border-radius: 26px; }
                                                .hr { position: relative; top: -19px; margin-bottom: 0px; }
                                                .hr-color { border-color: #2C314F; }
                                                .col-sm-6 { padding: 0px; margin: 0px; }    
                                                .col-sm-6 .btn { width: 149px;  height: 40px; }
                                                .col-sm-6 .btn i { position: relative; left:-15px; }
                                                .col-sm-6 .btn span { position: relative; top:-5px;}
                                                .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                                                .btn-primary { min-width: 100px; margin-top: 20px; }                         
                                                .text-left { text-align:left; }    
                                                .text-right{ text-align:right; }
                                                .text-center { text-align: center; }    
                                                .footer { margin-top: 173px; text-align: center;}    
                                                .text-24-5 { font-size: 24px; font-weight: 500; }    
                                                .text-20-5 { font-size: 20px; font-weight: 500; }    
                                                .text-20-4 { font-size: 20px; font-weight: 400; }    
                                                .text-12-4 { font-size: 12px; font-weight: 400; }    
                                                .color-A { color: #AAAAAA; }
                                                .color-7A { color: #7ACDCF; }    
                                                .color-2C { color: #2C314F; }    
                                                table, .row { width: 95%; margin: auto; }    
                                                .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                                                .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                                                .tr-1 p > button span { position: relative; top: -3px; }    
                                                .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span { padding-right: 4px; }    
                                                .tr-1 td { font-size: 12px; font-weight: 500; }    
                                                .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                                                td { font-size: 16px; font-weight: 400; }    
                                                .td-1 { width: 34%; }    
                                                .td-2 { width: 12%; }    
                                                .td-3 { width: 12%; }    
                                                .td-4 { width: 7%;  }    
                                                .td-5 { width: 12%; }    
                                                .group-pck span { line-height: 0.428571; }
                                                section { font-family: Roboto, Prompt, sans-serif; }    
                                                @media print
                                                {
                                                    tr * { font-size: 12px !important; }
                                                    .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                                                    .tr-1 td { font-size: 12px; font-weight: 500; }
                                                    .tr-1 td p > span{ padding-right: 4px; }
                                                    button { margin-left: 2px;  background-color: #2C314F; color: white; }
                                                    button span { position: relative;  top: -5px; }
                                                    .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                                                    .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                                                    .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                                                    #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                                                }
    
                                                @media screen and(max-width:768px)
                                                {
                                                    .td-5 { text-align: right; }
                                                    .btn-primary { margin-right: 20px; }
                                                    .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                                                    .col-sm-6.btn-float i { left: -4px; }
                                                }
                                            </style>
                                            <section class='printable'>
                                                <div class='media-form'>
                                                    <div class='row row-width'>
                                                        <div class='col-sm-6 center-text'>
                                                            <div class='form-group'>
                                                                <p class='text-24-5'>INVOICES<span>#" + req.Invoice_no + @"</span> <button type='button' class='btn-4 btn btn-default'><span>" + sta + @"</span></button></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class='border-color-top'></div>
                                                    <div class='row'>
                                                        <div class='col-sm-6 text-left pull-left'>
                                                            <p class='text-20-4'>9T co., ltd.</p>
                                                            <p class='text-12-4 color-A'>
                                                                Avesta Company, Addlink building 889 Moo 5
                                                                <br> Kamyai Sub-District, Ubon Ratchathani
                                                                <br> Thailand 34000
                                                                <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                                            </p>
                                                        </div>
                                                        <div class='col-sm-6 text-right pull-right'>
                                                            <div class=''>
                                                                <p class='text-20-4'>" + req.Company + @"</p>
                                                                <p class='text-12-4 color-A'>
                                                                    " + req.Firstname + ' ' + req.Lastname + @"
                                                                    <br> " + req.Address + @"
                                                                    <br> " + req.City + @", " + req.Province + @"
                                                                    <br> " + req.Country + @" " + req.PostCode + @"
                                                                    <span class='color-7A'>
                                                                    <br>
                                                                    " + req.Email + @"
                                                                    <br>
                                                                    " + req.PhoneNum + @"
                                                                </span>
                                                                </p>
                                                            </div>
                                                            <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.Invoice_no + @"</span></p>
                                                            <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + DateTime.Parse(req.Issued.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                            <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + DateTime.Parse(req.Due.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                        </div>
                                                    </div>
                                                    <table>
                                                        <tr class='tr-1'>
                                                            <td class='td-1'>DESCRIPTION</td>
                                                            <td class='td-2'>COUNT QTY</td>
                                                            <td class='td-3'>FROM</td>
                                                            <td class='td-4'>TO</td>
                                                            <td class='td-5'>PRICE(inc GST)</td>
                                                        </tr>
                                                        <tbody* ngFor='let item Of data'>
                                                            <tr class='tr-1'>
                                                                <td colspan='5'>
                                                                    <br >
                                                                    <p class='color-7A hidden-xs'>VEEAM(Cloud Connect Backup(" + req.Username + @"))</p>
                                                                    <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>VEEAM(Cloud Connect Backup (" + req.Username + @"))</p>
                                                                    <p class='group-pck'>
                                                                        <span class='text-12-4'>Alias: 
                                                                             <button type='button' class='btn-1 btn btn-default'><span>" + req.Alias + @"</span></button>
                                                                        </span>
                                                                        <br/>
                                                                        <br>
                                                                        <span class='text-12-4'>VM licenses: 
                                                                             <button type='button' class='btn-2 btn btn-default'><span>" + req.Vm + @" licenses</span></button>
                                                                        </span>
                                                                        <br class='hidden-lg hidden-md hidden-sm'>
                                                                        <br class='hidden-lg hidden-md hidden-sm'>
                                                                        <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.Storage + @"GB</span></button>
                                                                        </span>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td colspan='2'> Cloud Connect</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>$0.00</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>Storage</td>
                                                                <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.Storage + @"GB</td>
                                                                <td class='td-2 color-A hidden-xs'>" + req.Storage + @" GB</td>
                                                                <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + decimal.Parse(req.StoragePrice.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>VM licenses</td>
                                                                <td class='td-2 color-A'>" + req.Vm + @"</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + decimal.Parse(req.VmPrice.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'>Sub-Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse((req.SupTotal).ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Fees(7%)</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse(req.Fees.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Discount(Resaller)</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount(Resaller)</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse(req.DiscountResaller.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Discount</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse(req.Discount.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Invoice Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </section>");

            return sb.ToString();
        }
        #endregion
        #region veeam replication
        public string InvoiceTemplateResallerReplication(v_Get_InvoviceById_package_replication_resaller req,string sta)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                                            <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                                            <style>
                                                .btn-4 { width: 50px; height: 20px; border-radius: 26px; }
                                                .hr { position: relative; top: -19px; margin-bottom: 0px; }
                                                .hr-color { border-color: #2C314F; }
                                                .col-sm-6 { padding: 0px; margin: 0px; }    
                                                .col-sm-6 .btn { width: 149px;  height: 40px; }
                                                .col-sm-6 .btn i { position: relative; left:-15px; }
                                                .col-sm-6 .btn span { position: relative; top:-5px;}
                                                .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                                                .btn-primary { min-width: 100px; margin-top: 20px; }                         
                                                .text-left { text-align:left; }    
                                                .text-right{ text-align:right; }
                                                .text-center { text-align: center; }    
                                                .footer { margin-top: 173px; text-align: center;}    
                                                .text-24-5 { font-size: 24px; font-weight: 500; }    
                                                .text-20-5 { font-size: 20px; font-weight: 500; }    
                                                .text-20-4 { font-size: 20px; font-weight: 400; }    
                                                .text-12-4 { font-size: 12px; font-weight: 400; }    
                                                .color-A { color: #AAAAAA; }
                                                .color-7A { color: #7ACDCF; }    
                                                .color-2C { color: #2C314F; }    
                                                table, .row { width: 95%; margin: auto; }    
                                                .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                                                .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                                                .tr-1 p > button span { position: relative; top: -3px; }    
                                                .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span { padding-right: 4px; }    
                                                .tr-1 td { font-size: 12px; font-weight: 500; }    
                                                .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                                                td { font-size: 16px; font-weight: 400; }    
                                                .td-1 { width: 34%; }    
                                                .td-2 { width: 12%; }    
                                                .td-3 { width: 12%; }    
                                                .td-4 { width: 7%;  }    
                                                .td-5 { width: 12%; }    
                                                .group-pck span { line-height: 0.428571; }
                                                section { font-family: Roboto, Prompt, sans-serif; }    
                                                @media print
                                                {
                                                    tr * { font-size: 12px !important; }
                                                    .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                                                    .tr-1 td { font-size: 12px; font-weight: 500; }
                                                    .tr-1 td p > span{ padding-right: 4px; }
                                                    button { margin-left: 2px;  background-color: #2C314F; color: white; }
                                                    button span { position: relative;  top: -5px; }
                                                    .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                                                    .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                                                    .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                                                    #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                                                }
    
                                                @media screen and(max-width:768px)
                                                {
                                                    .td-5 { text-align: right; }
                                                    .btn-primary { margin-right: 20px; }
                                                    .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                                                    .col-sm-6.btn-float i { left: -4px; }
                                                }
                                            </style>
                                            <section class='printable'>
                                                <div class='media-form'>
                                                    <div class='row row-width'>
                                                        <div class='col-sm-6 center-text'>
                                                            <div class='form-group'>
                                                                <p class='text-24-5'>INVOICES<span>#" + req.Invoice_no + @"</span> <button type='button' class='btn-4 btn btn-default'><span>" + sta + @"</span></button></p> 
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class='border-color-top'></div>
                                                    <div class='row'>
                                                        <div class='col-sm-6 text-left pull-left'>
                                                            <p class='text-20-4'>9T co., ltd.</p>
                                                            <p class='text-12-4 color-A'>
                                                                Avesta Company, Addlink building 889 Moo 5
                                                                <br> Kamyai Sub-District, Ubon Ratchathani
                                                                <br> Thailand 34000
                                                                <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                                            </p>
                                                        </div>
                                                        <div class='col-sm-6 text-right pull-right'>
                                                            <div class=''>
                                                                <p class='text-20-4'>" + req.Company + @"</p>
                                                                <p class='text-12-4 color-A'>
                                                                    " + req.Firstname + ' ' + req.Lastname + @"
                                                                    <br> " + req.Address + @"
                                                                    <br> " + req.City + @", " + req.Province + @"
                                                                    <br> " + req.Country + @" " + req.PostCode + @"
                                                                    <span class='color-7A'>
                                                                    <br>
                                                                    " + req.Email + @"
                                                                    <br>
                                                                    " + req.PhoneNum + @"
                                                                </span>
                                                                </p>
                                                            </div>
                                                            <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.Invoice_no + @"</span></p>
                                                            <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + req.Issued.ToString("dd/MM/yyyy") + @"</span></p>
                                                            <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + DateTime.Parse(req.Due.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                        </div>
                                                    </div>
                                                    <table>
                                                        <tr class='tr-1'>
                                                            <td class='td-1'>DESCRIPTION</td>
                                                            <td class='td-2'>COUNT QTY</td>
                                                            <td class='td-3'>FROM</td>
                                                            <td class='td-4'>TO</td>
                                                            <td class='td-5'>PRICE(inc GST)</td>
                                                        </tr>
                                                        <tbody* ngFor='let item Of data'>
                                                            <tr class='tr-1'>
                                                                <td colspan='5'>
                                                                    <br >
                                                                    <p class='color-7A hidden-xs'>VEEAM(Cloud Connect Backup(" + req.Username + @"))</p>
                                                                    <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>VEEAM(Cloud Connect Backup (" + req.Username + @"))</p>
                                                                    <p class='group-pck'>
                                                                        <span class='text-12-4'>Alias: 
                                                                             <button type='button' class='btn-1 btn btn-default'><span>" + req.Alias + @"</span></button>
                                                                        </span>
                                                                        <br/>
                                                                        <br>
                                                                        <span class='text-12-4'>VM licenses: 
                                                                             <button type='button' class='btn-2 btn btn-default'><span>" + req.Vm + @" licenses</span></button>
                                                                        </span>
                                                                        <br class='hidden-lg hidden-md hidden-sm'>
                                                                        <br class='hidden-lg hidden-md hidden-sm'>
                                                                        <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.Storage + @"GB</span></button>
                                                                        </span>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td colspan='2'> Cloud Connect</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>$0.00</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>Storage</td>
                                                                <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.Storage + @"GB</td>
                                                                <td class='td-2 color-A hidden-xs'>" + req.Storage + @" GB</td>
                                                                <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.StoragePrice) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>VM licenses</td>
                                                                <td class='td-2 color-A'>" + req.Vm + @"</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.VmPrice) + @"</td>
                                                            </tr>
                                                             <tr class='tr-2'>
                                                                <td class='td-1'>Compute Processor</td>
                                                                <td class='td-2 color-A'>" + req.Processor + @" Ghz</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.ProcessorPrice) + @"</td>
                                                            </tr>
                                                             <tr class='tr-2'>
                                                                <td class='td-1'>RAM</td>
                                                                <td class='td-2 color-A'>" + req.Ram + @" GB</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.RamPrice) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>IP Addresses</td>
                                                                <td class='td-2 color-A'>" + req.IpAddress + @" Addresses</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.IpAddressPrice) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>Networks</td>
                                                                <td class='td-2 color-A'>" + req.NetworksPrice + @" Networks</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.NetworksPrice) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>Internet Traffic</td>
                                                                <td class='td-2 color-A'>" + req.Traffic + @" GB</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + string.Format("{0:0.00}", req.TrafficPrice) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'>Sub-Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                                                <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.SupTotal)) + @"</td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Discount(Resaller)</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount(Resaller)</td>
                                                                <td class='td-5 text-center'>" + string.Format("{0:0.00}", req.DiscountResaller) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Discount</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                                                <td class='td-5 text-center'>" + string.Format("{0:0.00}", req.Discount) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Fees(7%)</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                                                <td class='td-5 text-center'>" + string.Format("{0:0.00}", req.Fees) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                                                <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.Total)) + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Invoice Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                                                <td class='td-5 text-center'>" +
                                        string.Format("{0:0.00}", (req.Total)) + @"</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </section>");

            return sb.ToString();
        }
        #endregion
        #region for Nakivo 
        public string InvoiceTemplateEnterpriseNakivoBackup(v_Get_InvoviceById_package_backup_Nakivo req, string sta)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                                    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                                    <style>
                                        
                                        .btn-4 { width: 50px; height: 20px; border-radius: 26px; }
                                        .hr { position: relative; top: -19px; margin-bottom: 0px; }
                                        .hr-color { border-color: #2C314F; }
                                        .col-sm-6 { padding: 0px; margin: 0px; }    
                                        .col-sm-6 .btn { width: 149px;  height: 40px; }
                                        .col-sm-6 .btn i { position: relative; left:-15px; }
                                        .col-sm-6 .btn span { position: relative; top:-5px;}
                                        .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                                        .btn-primary { min-width: 100px; margin-top: 20px; }                         
                                        .text-left { text-align:left; }    
                                        .text-right{ text-align:right; }
                                        .text-center { text-align: center; }    
                                        .footer { margin-top: 173px; text-align: center;}    
                                        .text-24-5 { font-size: 24px; font-weight: 500; }    
                                        .text-20-5 { font-size: 20px; font-weight: 500; }    
                                        .text-20-4 { font-size: 20px; font-weight: 400; }    
                                        .text-12-4 { font-size: 12px; font-weight: 400; }    
                                        .color-A { color: #AAAAAA; }
                                        .color-7A { color: #7ACDCF; }    
                                        .color-2C { color: #2C314F; }    
                                        table, .row { width: 95%; margin: auto; }    
                                        .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                                        .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                                        .tr-1 p > button span { position: relative; top: -3px; }    
                                        .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                                        .tr-1 p > span { padding-right: 4px; }    
                                        .tr-1 td { font-size: 12px; font-weight: 500; }    
                                        .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                                        td { font-size: 16px; font-weight: 400; }    
                                        .td-1 { width: 34%; }    
                                        .td-2 { width: 12%; }    
                                        .td-3 { width: 12%; }    
                                        .td-4 { width: 7%;  }    
                                        .td-5 { width: 12%; }    
                                        .group-pck span { line-height: 0.428571; }
                                        section { font-family: Roboto, Prompt, sans-serif; }    
                                        @media print
                                        {
                                            tr * { font-size: 12px !important; }
                                            .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                                            .tr-1 td { font-size: 12px; font-weight: 500; }
                                            .tr-1 td p > span{ padding-right: 4px; }
                                            button { margin-left: 2px;  background-color: #2C314F; color: white; }
                                            button span { position: relative;  top: -5px; }
                                            .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                                            .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                                            .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                                            #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                                        }
    
                                        @media screen and(max-width:768px)
                                        {
                                            .td-5 { text-align: right; }
                                            .btn-primary { margin-right: 20px; }
                                            .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                                            .col-sm-6.btn-float i { left: -4px; }
                                        }
                                    </style>
                                    <section class='printable'>
                                        <div class='media-form'>
                                            <div class='row row-width'>
                                                <div class='col-sm-6 center-text'>
                                                    <div class='form-group' style='margin-top: 10px;'>
                                                        <p class='text-24-5'>INVOICES<span>#" + req.Invoice_no + @"</span> <button type='button' class='btn-4 btn btn-default'><span>" + sta + @"</span></button></p> 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class='border-color-top'></div>
                                            <div class='row'>
                                                <div class='col-sm-6 text-left pull-left'>
                                                    <p class='text-20-4'>9T co., ltd.</p>
                                                    <p class='text-12-4 color-A'>
                                                        Avesta Company, Addlink building 889 Moo 5
                                                        <br> Kamyai Sub-District, Ubon Ratchathani
                                                        <br> Thailand 34000
                                                        <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                                    </p>
                                                </div>
                                                <div class='col-sm-6 text-right pull-right'>
                                                    <div class=''>
                                                        <p class='text-20-4'>" + req.Company + @"</p>
                                                        <p class='text-12-4 color-A'>
                                                            " + req.Firstname + ' ' + req.Lastname + @"
                                                            <br> " + req.Address + @"
                                                            <br> " + req.City + @", " + req.Province + @"
                                                            <br> " + req.Country + @" " + req.PostCode + @"
                                                            <span class='color-7A'>
                                                            <br>
                                                            " + req.Email + @"
                                                            <br>
                                                            " + req.PhoneNum + @"
                                                        </span>
                                                        </p>
                                                    </div>
                                                    <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.Invoice_no + @"</span></p>
                                                    <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + DateTime.Parse(req.Issued.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                    <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + DateTime.Parse(req.Due.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                </div>
                                            </div>
                                            <table>
                                                <tr class='tr-1' style='border-top: 1px solid #2c314f; border-bottom: 2px solid #2c314f;'>
                                                    <td class='td-1'>DESCRIPTION</td>
                                                    <td class='td-2'>COUNT QTY</td>
                                                    <td class='td-3'>FROM</td>
                                                    <td class='td-4'>TO</td>
                                                    <td class='td-5'>PRICE(inc GST)</td>
                                                </tr>
                                                <tbody* ngFor='let item Of data'>
                                                    <tr class='tr-1' style='border-bottom: 1px solid #2c314f;'>
                                                        <td colspan='5'>
                                                            <br >
                                                            <p class='color-7A hidden-xs'>NAKIVO(Cloud Connect Nakivo(" + req.Username + @"))</p>
                                                            <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>NAKIVO(Cloud Connect Nakivo(" + req.Username + @"))</p>
                                                            <p class='group-pck'>
                                                                <span class='text-12-4'>Alias: 
                                                                     <button type='button' class='btn-1 btn btn-default'><span>" + req.Alias + @"</span></button>
                                                                </span>
                                                                <br/>
                                                                <br>
                                                                <span class='text-12-4'>VM licenses: 
                                                                     <button type='button' class='btn-2 btn btn-default'><span>" + req.Vm + @" licenses</span></button>
                                                                </span>
                                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                                <br class='hidden-lg hidden-md hidden-sm'>
                                                                <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.Storage + @"GB</span></button>
                                                                </span>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td colspan='2'> Cloud Connect</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>$0.00</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>Storage</td>
                                                        <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.Storage + @"GB</td>
                                                        <td class='td-2 color-A hidden-xs'>" + req.Storage + @" GB</td>
                                                        <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + decimal.Parse(req.StoragePrice.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'>VM licenses</td>
                                                        <td class='td-2 color-A'>" + req.Vm + @"</td>
                                                        <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                        <td class='td-5 text-center color-A'>" + decimal.Parse(req.VmPrice.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'>Sub-Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse((req.SupTotal).ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                </tbody>
                                                <tbody>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Fees(7%)</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse(req.Fees.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Discount</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse(req.Discount.ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                    <tr class='tr-2'>
                                                        <td class='td-1'></td>
                                                        <td class='td-2 hidden-xs'></td>
                                                        <td class='td-3 hidden-xs'></td>
                                                        <td class='td-4 hidden-xs'>Invoice Total</td>
                                                        <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                                        <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </section>");

            return sb.ToString();
        }
        #endregion
        #region for Nakivo Resaller
        public string InvoiceTemplateResallerNakivoBackup(v_Get_InvoviceById_package_backup_Nakivo_resaller req,string sta)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>
                                            <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i'>
                                            <style>
                                                .btn-4 { width: 50px; height: 20px; border-radius: 26px; }
                                                .hr { position: relative; top: -19px; margin-bottom: 0px; }
                                                .hr-color { border-color: #2C314F; }
                                                .col-sm-6 { padding: 0px; margin: 0px; }    
                                                .col-sm-6 .btn { width: 149px;  height: 40px; }
                                                .col-sm-6 .btn i { position: relative; left:-15px; }
                                                .col-sm-6 .btn span { position: relative; top:-5px;}
                                                .border-color-top { border-top: 1px solid #2C314F; padding-bottom:20px; width:95 %; margin: auto; }
                                                .btn-primary { min-width: 100px; margin-top: 20px; }                         
                                                .text-left { text-align:left; }    
                                                .text-right{ text-align:right; }
                                                .text-center { text-align: center; }    
                                                .footer { margin-top: 173px; text-align: center;}    
                                                .text-24-5 { font-size: 24px; font-weight: 500; }    
                                                .text-20-5 { font-size: 20px; font-weight: 500; }    
                                                .text-20-4 { font-size: 20px; font-weight: 400; }    
                                                .text-12-4 { font-size: 12px; font-weight: 400; }    
                                                .color-A { color: #AAAAAA; }
                                                .color-7A { color: #7ACDCF; }    
                                                .color-2C { color: #2C314F; }    
                                                table, .row { width: 95%; margin: auto; }    
                                                .row .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }    
                                                .tr-1 p > button { margin-left: 2px; background-color: #2C314F; color: white; }    
                                                .tr-1 p > button span { position: relative; top: -3px; }    
                                                .tr-1 p > span .btn-1 { width: 111px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span .btn-2 { width: 92px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span .btn-3 { width: 78px; height: 26px; border-radius: 26px; }    
                                                .tr-1 p > span { padding-right: 4px; }    
                                                .tr-1 td { font-size: 12px; font-weight: 500; }    
                                                .tr-2 { padding: 20px 0px; height: 40px; border-top: 1px solid #F3F5F5; border-bottom: 1px solid #F3F5F5; }    
                                                td { font-size: 16px; font-weight: 400; }    
                                                .td-1 { width: 34%; }    
                                                .td-2 { width: 12%; }    
                                                .td-3 { width: 12%; }    
                                                .td-4 { width: 7%;  }    
                                                .td-5 { width: 12%; }    
                                                .group-pck span { line-height: 0.428571; }
                                                section { font-family: Roboto, Prompt, sans-serif; }    
                                                @media print
                                                {
                                                    tr * { font-size: 12px !important; }
                                                    .tr-1 { padding: 20px 0px; height: 40px; border-top: 1px solid #2C314F; border-bottom: 1px solid #2C314F; }
                                                    .tr-1 td { font-size: 12px; font-weight: 500; }
                                                    .tr-1 td p > span{ padding-right: 4px; }
                                                    button { margin-left: 2px;  background-color: #2C314F; color: white; }
                                                    button span { position: relative;  top: -5px; }
                                                    .btn-1 { width: 111px; height: 26px; border-radius: 26px; }
                                                    .btn-2 { width: 92px; height: 26px; border-radius: 26px; }
                                                    .btn-3 { width: 78px; height: 26px; border-radius: 26px; }
                                                    #footter-print { font-size: 10px !important; display: block; visibility: visible; position: fixed; bottom: 0px; margin: 0 auto; text-align: center; width: 100%; }
                                                }
    
                                                @media screen and(max-width:768px)
                                                {
                                                    .td-5 { text-align: right; }
                                                    .btn-primary { margin-right: 20px; }
                                                    .col-sm-6.btn-float { float: right; width: 99px; margin: 5px 0px; }
                                                    .col-sm-6.btn-float i { left: -4px; }
                                                }
                                            </style>
                                            <section class='printable'>
                                                <div class='media-form'>
                                                    <div class='row row-width'>
                                                        <div class='col-sm-6 center-text'>
                                                            <div class='form-group'>
                                                                <p class='text-24-5'>INVOICES<span>#" + req.Invoice_no + @"</span> <button type='button' class='btn-4 btn btn-default'><span>" + sta + @"</span></button></p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class='border-color-top'></div>
                                                    <div class='row'>
                                                        <div class='col-sm-6 text-left pull-left'>
                                                            <p class='text-20-4'>9T co., ltd.</p>
                                                            <p class='text-12-4 color-A'>
                                                                Avesta Company, Addlink building 889 Moo 5
                                                                <br> Kamyai Sub-District, Ubon Ratchathani
                                                                <br> Thailand 34000
                                                                <br><span class='color-7A'> support@9t.com<br>Phone +66(0)45-959612 Thailand<br>Phone +885(0)974919241(Mr. Jong) Cambodia</span>
                                                            </p>
                                                        </div>
                                                        <div class='col-sm-6 text-right pull-right'>
                                                            <div class=''>
                                                                <p class='text-20-4'>" + req.Company + @"</p>
                                                                <p class='text-12-4 color-A'>
                                                                    " + req.Firstname + ' ' + req.Lastname + @"
                                                                    <br> " + req.Address + @"
                                                                    <br> " + req.City + @", " + req.Province + @"
                                                                    <br> " + req.Country + @" " + req.PostCode + @"
                                                                    <span class='color-7A'>
                                                                    <br>
                                                                    " + req.Email + @"
                                                                    <br>
                                                                    " + req.PhoneNum + @"
                                                                </span>
                                                                </p>
                                                            </div>
                                                            <p class='text-12-4 color-A'>Invoice: <span class='color-2C'>" + req.Invoice_no + @"</span></p>
                                                            <p class='text-12-4 color-A'>Issued: <span class='color-2C'>" + DateTime.Parse(req.Issued.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                            <p class='text-12-4 color-A'>Due: <span class='color-2C'>" + DateTime.Parse(req.Due.ToString()).ToString("dd/MM/yyyy") + @"</span></p>
                                                        </div>
                                                    </div>
                                                    <table>
                                                        <tr class='tr-1'>
                                                            <td class='td-1'>DESCRIPTION</td>
                                                            <td class='td-2'>COUNT QTY</td>
                                                            <td class='td-3'>FROM</td>
                                                            <td class='td-4'>TO</td>
                                                            <td class='td-5'>PRICE(inc GST)</td>
                                                        </tr>
                                                        <tbody* ngFor='let item Of data'>
                                                            <tr class='tr-1'>
                                                                <td colspan='5'>
                                                                    <br >
                                                                    <p class='color-7A hidden-xs'>NAKIVO(Cloud Connect Nakivo(" + req.Username + @"))</p>
                                                                    <p class='color-7A text-12-4 hidden-lg hidden-md hidden-sm'>NAKIVO(Cloud Connect Nakivo(" + req.Username + @"))</p>
                                                                    <p class='group-pck'>
                                                                        <span class='text-12-4'>Alias: 
                                                                             <button type='button' class='btn-1 btn btn-default'><span>" + req.Alias + @"</span></button>
                                                                        </span>
                                                                        <br/>
                                                                        <br>
                                                                        <span class='text-12-4'>VM licenses: 
                                                                             <button type='button' class='btn-2 btn btn-default'><span>" + req.Vm + @" licenses</span></button>
                                                                        </span>
                                                                        <br class='hidden-lg hidden-md hidden-sm'>
                                                                        <br class='hidden-lg hidden-md hidden-sm'>
                                                                        <span class='text-12-4'>Storage: <button type='button' class='btn-3 btn btn-default'><span>" + req.Storage + @"GB</span></button>
                                                                        </span>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td colspan='2'> Cloud Connect</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>$0.00</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>Storage</td>
                                                                <td class='td-2 color-A hidden-lg hidden-md hidden-sm' colspan='2'>" + req.Storage + @"GB</td>
                                                                <td class='td-2 color-A hidden-xs'>" + req.Storage + @" GB</td>
                                                                <td class='td-3 color-A hidden-xs'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + decimal.Parse(req.StoragePrice.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'>VM licenses</td>
                                                                <td class='td-2 color-A'>" + req.Vm + @"</td>
                                                                <td class='td-3 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.Start_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-4 color-A'><span class='hidden-xs'>" + DateTime.Parse(req.End_dt.ToString()).ToString("dd/MM/yyyy") + @"</span></td>
                                                                <td class='td-5 text-center color-A'>" + decimal.Parse(req.VmPrice.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'>Sub-Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Sub-Total</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse((req.SupTotal).ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                        </tbody>
                                                        <tbody>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Fees(7%)</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Fees(7%)</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse(req.Fees.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Discount(Resaller)</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount(Resaller)</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse(req.DiscountResaller.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Discount</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Discount</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse(req.Discount.ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Total</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                            <tr class='tr-2'>
                                                                <td class='td-1'></td>
                                                                <td class='td-2 hidden-xs'></td>
                                                                <td class='td-3 hidden-xs'></td>
                                                                <td class='td-4 hidden-xs'>Invoice Total</td>
                                                                <td class='td-4 hidden-lg hidden-md hidden-sm' colspan='3'>Invoice Total</td>
                                                                <td class='td-5 text-center'>" + decimal.Parse((req.Total).ToString()).ToString("C2") + @"</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </section>");

            return sb.ToString();
        }
        #endregion
        #endregion
        #endregion
    }
} 
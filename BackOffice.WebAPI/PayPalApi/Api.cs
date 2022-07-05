namespace BackOffice.WebAPI.PayPalApi
{
    using PayPal.Api;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;

    /*
    <configSections>
        <section name="paypal" type="PayPal.SDKConfigHandler, PayPal" />
    </configSections>

    <!-- PayPal SDK settings -->
    <paypal>
    <settings>
        <add name="mode" value="sandbox"/>
        <add name="clientId" value="AbwCduYBloBAKN0-DljIjoI57EiUfaHHJSA5_edtfr6C0FmNOAn4UwDg_UsPAxaGSrTRd2XhjvmQvnw4"/>
        <add name="clientSecret" value="EL7XWvLh0MCbG5B_-kiOrUk_AuuUyB6INhlmWAosa8HQZ4zbfhfVzs1ndNINhMiwkl3NvrafQMtTDjSh"/>
    </settings>
    </paypal>     
    */

    public class Api
    {
        public Dictionary<string, string> Config = ConfigManager.Instance.GetProperties();
        public APIContext ApiContext;



        public Api()
        {
            try
            {

                //var clientId = "AbwCduYBloBAKN0-DljIjoI57EiUfaHHJSA5_edtfr6C0FmNOAn4UwDg_UsPAxaGSrTRd2XhjvmQvnw4";
                //var secretToken = "EL7XWvLh0MCbG5B_-kiOrUk_AuuUyB6INhlmWAosa8HQZ4zbfhfVzs1ndNINhMiwkl3NvrafQMtTDjSh";
                //var config = new Dictionary<string, string> { { "mode", "sandbox" } };

                //var clientId = "AXCKzF4seN75kAGtwYZH5Am45nCHza7X1xpQsA0VCYM9i2MD1TurcCtJ_QX0WOUQyM-7d0ONSZ2wdmym";

                //var secretToken = "EEg20fzeY-I_ZVE9uxd3dUti6-XZHFxTIEbY84wmWPwaVUJj1z-SXoUAqapEfH-84mopAdXRLnQ4bi3U";
                //var config = new Dictionary<string, string> { { "mode", "live" } };

                //OAuthTokenCredential tokenCredential = new OAuthTokenCredential(clientId, secretToken, config);
                //string accessToken = tokenCredential.GetAccessToken();
                // ApiContext = new APIContext(accessToken);


                ApiContext = new APIContext(new OAuthTokenCredential(Config).GetAccessToken());
            }
            catch (PayPal.PayPalException ex)
            {

                Console.Write("Error Paypal Exception: " + ex.Message); 

            }
        }

        public GetPayments GetPayments(int count = 5)
        {
            var result = HttpRequest.GetStringAsync($"/v1/payments/payment?count={count}").Result;
            return System.Web.Helpers.Json.Decode<GetPayments>(result);
        }

        public GetPayment GetPayment(string paymentId)
        {
           
             var result = HttpRequest.GetStringAsync($"/v1/payments/payment/{paymentId}").Result;
             return System.Web.Helpers.Json.Decode<GetPayment>(result);
           
        }

        public GetSale GetSale(string saleId)
        {
            var result = HttpRequest.GetStringAsync($"/v1/payments/sale/{saleId}").Result;
            return System.Web.Helpers.Json.Decode<GetSale>(result);
        }

        public GetRefundResponse RefundSale(string saleId, Refund refund = null)
        {
            GetRefundResponse Response = new GetRefundResponse();
            HttpResponseMessage result = HttpRequest.PostAsJsonAsync($"/v1/payments/sale/{saleId}/refund", refund ?? new Refund()).Result;
            string responseString = result.Content.ReadAsStringAsync().Result;

            if (result.StatusCode >= System.Net.HttpStatusCode.BadRequest)
            {
                Response.Error = System.Web.Helpers.Json.Decode<GetError>(responseString);
                Response.Status = false;
            }
            else
            {
                Response.Refund = System.Web.Helpers.Json.Decode<GetRefund>(responseString);
                Response.Status = true;
            }
            return Response;
        }

        public HttpClient HttpRequest
        {
            get
            {
                var request = new HttpClient();
                string Address = Config["mode"].Equals("sandbox")
                    ? "https://api.sandbox.paypal.com" : "https://api.paypal.com";
                request.BaseAddress = new Uri(Address);
                request.DefaultRequestHeaders.Add("Authorization", ApiContext.AccessToken);
                return request;
            }
        }
    }
}
using Backup.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Backup.ClassLibrary.Concrete.VeeamCloudConnect
{
    public class VccGetStorage : VeeamCC
    {
        public QueryResult getGetStorageAll()
        {
            if (X_RestSvcSessionId == string.Empty || UriApi == string.Empty)
            {
                X_RestSvcSessionId = getX_RestSvcSessionId();
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            client.DefaultRequestHeaders.Add("X-RestSvcSessionId", X_RestSvcSessionId);
            string xmlDocumentText = client.GetStringAsync(UriApi + "/api/query?type=CloudTenant&format=entities&sortAsc=name").Result;

            var QueryRs = new QueryResult();

            XmlSerializer serializer = new XmlSerializer(typeof(QueryResult));
            using (StringReader reader = new StringReader(xmlDocumentText))
            {
                QueryRs = (QueryResult)(serializer.Deserialize(reader));
                
            }
            return QueryRs;
        }
    }
}

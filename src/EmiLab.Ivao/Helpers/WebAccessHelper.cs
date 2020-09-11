using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace EmiLab.Ivao.Helpers
{
    internal class WebAccessHelper
    {

        public static string Get()
        {
            //var wc = new HttpClient(new HttpClientHandler { Proxy = _proxy });
            //return wc.GetStringAsync(path);

            //todo l'indirizzo deve diventare una dipendenza
            var req = WebRequest.Create("http://api.ivao.aero/getdata/whazzup/whazzup.txt.gz");
            req.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            //try
            //{
            //    if (req.Proxy != null)
            //    {
            //        string proxyuri = req.Proxy.GetProxy(req.RequestUri).ToString();
            //        req.UseDefaultCredentials = true;
            //        req.Proxy = new WebProxy(proxyuri, false) { Credentials = CredentialCache.DefaultCredentials };
            //    }
            //}
            //catch (PlatformNotSupportedException) { }



            using (Stream toDecompress = req.GetResponse().GetResponseStream())
            using (MemoryStream decompressedStream = new MemoryStream())
            using (GZipStream decompressionStream = new GZipStream(toDecompress ?? throw new InvalidOperationException(), CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(decompressedStream);
                return Encoding.UTF8.GetString(decompressedStream.ToArray());
            }
        }
    }
}

using System.Net;
using System.Text;

namespace WebAppMVC.Models
{
    public class Request
    {
        public string Url { get; set; }
        public string ExceptionText { get; set; }
        public bool Exception { get; set; }

        public Request(string url)
        {
            Url = url;
            Exception = false;
        }

        public async Task<string> GetJson()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Timeout = 10000;
                Stream stream = request.GetResponse().GetResponseStream();

                string respons = string.Empty;
                using (stream)
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8)) 
                    {
                        respons = await reader.ReadToEndAsync();
                    }
                }
                stream.Close();
                return respons;
            }
            catch (Exception ex)
            {
                Exception = true;
                ExceptionText = ex.Message;
                return string.Empty;
            }
        }
    }
}

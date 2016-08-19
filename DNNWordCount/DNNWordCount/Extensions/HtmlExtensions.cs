using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace DNN.ModuleDNNWordCount.Extensions
{
    public class HtmlExtensions
    {
        public static string ExtractInnerTextFromHTMLBody(string rawHtml)
        {
            var html = new HtmlDocument();
            html.LoadHtml(rawHtml);

            var body = html.DocumentNode.SelectSingleNode("//body");

            int total = 0;
            foreach (var item in body.DescendantsAndSelf())
            {
                if (item.NodeType == HtmlNodeType.Text)
                {
                    if (item.InnerText.Length > 0)
                    {
                        total += item.InnerText.Split(' ').Count();
                    }
                }
            }

            return total.ToString();
        }

        public static string GetResponseString(string encodedUrl)
        {
            var decodedURL = HttpUtility.UrlDecode(encodedUrl);

            WebRequest request = WebRequest.Create(decodedURL);
            WebResponse wr = request.GetResponse();
            Stream receiveStream = wr.GetResponseStream();

            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();

            return content;
        }
    }
}
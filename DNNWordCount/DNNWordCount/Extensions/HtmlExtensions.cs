using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
                        var stringValue = RemoveSpecialCharacters(item.InnerText);
                        total += stringValue.Split(' ').Count();
                    }
                }
            }

            return total.ToString();
        }

        private static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
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
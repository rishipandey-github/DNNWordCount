using DNN.ModuleDNNWordCount.Extensions;
using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Xml;

namespace DNN.ModuleDNNWordCount.Services
{
    public class CalculationController : DnnApiController
    {
        [System.Web.Http.HttpGet()]
        public HttpResponseMessage Get(string url)
        {
            var content = HtmlExtensions.GetResponseString(url);
            var wordCount = HtmlExtensions.ExtractInnerTextFromHTMLBody(content);

            return Request.CreateResponse(HttpStatusCode.OK, wordCount);
        }

    }
}
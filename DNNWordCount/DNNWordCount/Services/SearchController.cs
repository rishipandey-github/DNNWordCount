using DNN.ModuleDNNWordCount.Models;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DNN.ModuleDNNWordCount.Services
{    
    public class SearchController : DnnApiController
    {
        private Repository.SearchRepository _searchRepository;

        public SearchController()
        {
            _searchRepository = new Repository.SearchRepository();
        }

        [System.Web.Http.HttpGet()]
        public HttpResponseMessage GetAll()
        {
            var results = _searchRepository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Authorize]
        [HttpPost()]        
        public HttpResponseMessage Add([FromBody]SearchHistory data)
        {
            try
            {               
                _searchRepository.Add(data);                
                return Request.CreateResponse(HttpStatusCode.OK, "Completed");
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
using DNN.ModuleDNNWordCount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DNN.ModuleDNNWordCount.Repository
{
    public interface ISearchRepository
    {
        void Add(SearchHistory history);

        IEnumerable<SearchHistory> GetAll();
    }
}
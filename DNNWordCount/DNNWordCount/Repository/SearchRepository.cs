using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DNN.ModuleDNNWordCount.Models;

namespace DNN.ModuleDNNWordCount.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly Search _searchContext;  

        public SearchRepository()
        {
            _searchContext = new Search();
        }

        public void Add(SearchHistory history)
        {
            _searchContext.SearchHistories.Add(history);
            _searchContext.SaveChanges();
        }

        public IEnumerable<SearchHistory> GetAll()
        {
            return _searchContext.SearchHistories;
        }
    }
}
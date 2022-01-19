using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRestUdemy.Hypermedia.Abstract;

namespace UdemyApi.Application.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportHypermedia
    {
        public PagedSearchVO()
        {
        }

        public PagedSearchVO(int currentPage, int pageSize, int sortFields, int sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, int pageSize, int sortFields, int sortDirections, 
            Dictionary<string, object> filters) : this(currentPage, pageSize, sortFields, sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, int sortFields, int sortDirections) 
            : this (currentPage, 10, sortFields, sortDirections) {}

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public int SortFields { get; set; }
        public int SortDirections { get; set; }
        public Dictionary<string, object> Filters { get; set; }
        public List<T> List { get; set; }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}

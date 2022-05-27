using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Models
{
    public class PageModel
    {
        public PageModel()
        {

        }

        public PageModel(int page, int perPage, string search)
        {
            Page = page;
            PerPage = perPage;
            Search = search;
        }

        public string Search { get; set; } = string.Empty;
        public int Page { get; set; }

        public int PerPage { get; set; } = 30;
    }
}

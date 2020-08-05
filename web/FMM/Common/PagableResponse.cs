
using System.Collections.Generic;

namespace FMM.Common
{
    public class PagableResponse<T> : PagingOptions
    {
        public List<T> Response { get; set; }
        public int AllItemsCount { get; set; }
        public int PagesCount { get; set; }
    }
}
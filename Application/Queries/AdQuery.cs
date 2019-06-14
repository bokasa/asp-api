using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class AdQuery
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int? Price { get; set; }
        public bool? IsShipping { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Ad : BaseEntity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Price { get; set; }
        public bool IsShipping { get; set; }


        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
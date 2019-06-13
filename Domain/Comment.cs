using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public int AdId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public Ad Ad { get; set; }

    }
}

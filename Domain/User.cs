using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Ad> Ads { get; set; }

    }
}

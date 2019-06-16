using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<CommentDTO> Comments { get; set; }
        public IEnumerable<AdDTO> Ads { get; set; }
   
    }
}

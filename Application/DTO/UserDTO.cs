using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<AdDTO> Ads { get; set; }
    }
}

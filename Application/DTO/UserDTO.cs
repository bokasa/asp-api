using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(4, ErrorMessage = "Username must have at least 4 characters.")]
        [MaxLength(20, ErrorMessage = "Username must have max 20 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters.")]
        [MaxLength(25, ErrorMessage = "Password must have max 25 characters.")]
        public string Password { get; set; }

        public IEnumerable<CommentDTO> Comments { get; set; }
        public IEnumerable<AdDTO> Ads { get; set; }
   
    }
}

using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class AdDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MinLength(2, ErrorMessage = "Title must have at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Title must have max 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body is required.")]
        [MinLength(5, ErrorMessage = "Body must have at least 5 characters.")]
        [MaxLength(350, ErrorMessage = "Body must have max 350 characters.")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public int Price { get; set; }

        [Required(ErrorMessage = "IsShipping is required.")]
        public bool IsShipping { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public CategoryDTO Category { get; set; }
        public UserDTO User { get; set; }

    }
}
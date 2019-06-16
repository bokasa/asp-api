using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [MinLength(2, ErrorMessage = "Category must have at least 2 characters.")]
        [MaxLength(40, ErrorMessage = "Category must have max 40 characters.")]
        
        public string Name { get; set; }
        public IEnumerable<AdDTO> Ads { get; set; }

    }
}

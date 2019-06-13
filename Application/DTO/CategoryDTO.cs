using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public ICollection<AdDTO> Categories { get; set; }

    }
}

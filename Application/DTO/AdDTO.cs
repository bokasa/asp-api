using Domain;

namespace Application.DTO
{
    public class AdDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Price { get; set; }
        public bool IsShipping { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public CategoryDTO Category { get; set; }
        public UserDTO User { get; set; }

    }
}
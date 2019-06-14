namespace Application.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public UserDTO UserDTO { get; set; }
        public AdDTO AdDTO{ get; set; }

    }
}
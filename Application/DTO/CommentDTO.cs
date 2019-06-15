namespace Application.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public UserDTO User { get; set; }
        public AdDTO Ad{ get; set; }

    }
}
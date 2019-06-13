using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ReviewDTO
    {
        public UserDTO WhoVoted { get; set; }
        public UserDTO VotedFor { get; set; }

    }
}

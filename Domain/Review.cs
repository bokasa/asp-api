using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Review : BaseEntity
    {
        public int WhoVotedId { get; set; }
        public int VotedForId { get; set; }
        public User WhoVoted { get; set; }
        public User VotedFor { get; set; }

    }
}

using BS.Entities.Abstract;
using BS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities.Concrete
{
    public class Comment : BaseEntity
    {
        public string? CommentTitle { get; set; }
        public string? CommentContent { get; set; }
        public Rating Rating { get; set; }
        public DateTime CommentDate { get; set; }



        //iliskiler

        public int UserId { get; set; }
        public User User { get; set; }


        public int BookId { get; set; }
        public Book Book { get; set; }



    }
}

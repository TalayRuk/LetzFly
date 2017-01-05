using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetzFly.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public virtual User User { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text_body { get; set; }       
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}

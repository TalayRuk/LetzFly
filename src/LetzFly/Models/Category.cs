using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LetzFly.Models
{
    
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        //nested table: one to many relationship Category has many products 
    }
    
}

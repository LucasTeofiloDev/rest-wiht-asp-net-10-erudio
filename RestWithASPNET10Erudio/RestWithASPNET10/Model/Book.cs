using RestWithASPNET10.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET10.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        
        [Required]
        [Column("title", TypeName = "varchar(max)")]
        public string Title { get; set; }
        [Required]
        [Column("author",TypeName = "varchar(max)")]
        public string Author { get; set; }
        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        [Column("launch_date", TypeName = "datetime")]
        public DateTime LaunchDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseOfStories.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        [Required]
        public string? Text { get; set; }

        public bool IsValid { get; set; } 

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}

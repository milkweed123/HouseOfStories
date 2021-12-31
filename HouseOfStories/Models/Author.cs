using System.ComponentModel.DataAnnotations;

namespace HouseOfStories.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}

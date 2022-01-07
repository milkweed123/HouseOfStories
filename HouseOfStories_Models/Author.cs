using System.ComponentModel.DataAnnotations;

namespace HouseOfStories_Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EveningWebAPIExample.Models
{
    public class Shirt
    {
        public Shirt() { }

        public int Id { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }

        [Shirts_EnsureCorrectSizeAttribute]
        public int Size { get; set; }
        [Required]
        public string? Gender { get; set; }
        public double? Price { get; set; }
    }
}

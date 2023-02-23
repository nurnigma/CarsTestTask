
using System.ComponentModel.DataAnnotations;

namespace CarsTestTask.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано название бренда")]
        public string? Name { get; set; }

        public bool Active { get; set; }
    }
}

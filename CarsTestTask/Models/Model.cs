using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsTestTask.Models
{
    public class Model
    {
        public int Id { get; set; }
        /// <summary>
        /// один ко многим 
        /// </summary>
        [ForeignKey("BrandId")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Не указано название модели")]
        public string Name { get; set; }
        public bool Active { get; set; }

    }
}

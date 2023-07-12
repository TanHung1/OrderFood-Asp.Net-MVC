using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên không dược quá 50 ký tự")]
        public string NameCategory { get; set; } = null;
        [Required(ErrorMessage = "Mô tả không được để trống.")]
        [StringLength(500, ErrorMessage = "Mô tả không được để trống.")]
        public string Description { get; set; } = null;

        public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
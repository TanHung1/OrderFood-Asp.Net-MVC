using System.ComponentModel.DataAnnotations;
namespace OrderFood.Models
{
    public class Dish
    {
        [Key]
        public Guid DishId { get; set; }

        [Required(ErrorMessage = "Tên món ăn không được để trống.")]
        public string NameDish { get; set; }

        public int CategoryId { get; set; }

        public string? Description { get; set; }
        [Required(ErrorMessage = "Giá không được để trống.")]
        public decimal Price { get; set; }

        public string? Image { get; set; }

    }
}

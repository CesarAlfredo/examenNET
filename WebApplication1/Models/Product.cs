using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; } = string.Empty;

    // Rango seguro para .NET 9 (evita el error de FormatException)
    [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Price { get; set; }
}
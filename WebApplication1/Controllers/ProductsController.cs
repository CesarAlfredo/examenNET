using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models; // <--- Importante: esto conecta con tu modelo
using System.Collections.Generic;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // La lista debe ser STATIC para que los datos no se borren en cada petición
    private static List<Product> _products = new List<Product>();

    // GET: api/products
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_products);
    }

    // POST: api/products
    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("El producto no puede ser nulo.");
        }

        // Asignación de ID manual (porque es una lista estática, no una DB)
        product.Id = _products.Count + 1;

        _products.Add(product);

        // Retornamos un 201 Created
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
}
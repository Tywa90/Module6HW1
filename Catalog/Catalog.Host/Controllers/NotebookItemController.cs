using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class NotebookItemController : ControllerBase
{
    private static readonly string[] Brands = new[]
    {
        "Acer", "ASUS", "HP", "Lenovo", "Apple", "DELL"
    };

    private static readonly string[] ProcessorsTypes = new[]
    {
        "Intel Core i3", "Intel Core i5", "Intel Core i7", "AMD Ryzen 3", "AMD Ryzen 5", "AMD Ryzen 7"
    };

    private static readonly string[] GraphicsCardType = new[]
    {
        "integrated", "GeForce RTX 3080", "GeForce RTX 3060", "GeForce GTX 1650", "GeForce GTX 1650", "GeForce 4060"
    };

    private readonly ILogger<NotebookItemController> _logger;

    public NotebookItemController(ILogger<NotebookItemController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<NotebookItem> Get()
    {
        return Enumerable.Range(1, 10).Select(index => new NotebookItem
        {
            BrandName = Brands[Random.Shared.Next(Brands.Length)],
            Processor = ProcessorsTypes[Random.Shared.Next(ProcessorsTypes.Length)],
            GraphicsCard = GraphicsCardType[Random.Shared.Next(GraphicsCardType.Length)],
            Price = Math.Round(Random.Shared.NextDouble() * 1000, 2),
            OrderDate = DateTime.Now.AddDays(Random.Shared.Next(-10, 11))
        })
            .ToArray();
    }
}
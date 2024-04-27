namespace Demo_TestContainers.Domain;

public record Product(
    string Sku,
    string Ean,
    string Name,
    string Description,
    decimal Price,
    int Stock);
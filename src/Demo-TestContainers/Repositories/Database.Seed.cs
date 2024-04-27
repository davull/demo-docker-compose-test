using System.Data;
using Dapper;
using Demo_TestContainers.Domain;

namespace Demo_TestContainers.Repositories;

public static partial class Database
{
    public static async Task Seed(IDbConnection con, string databaseName)
    {
        await EnsureDatabase(con, databaseName);
        con.ChangeDatabase(databaseName);

        await EnsureTableProducts(con);
    }

    private static async Task EnsureDatabase(IDbConnection con, string databaseName)
    {
        if (await DatabaseExists(con, databaseName))
        {
            return;
        }

        await CreateDatabase(con, databaseName);
    }

    private static async Task EnsureTableProducts(IDbConnection con)
    {
        if (await TableExists(con, "Products"))
        {
            return;
        }

        const string sql =
            """
            CREATE TABLE Products (
                `Sku` VARCHAR(50) NOT NULL PRIMARY KEY,
                `Ean` VARCHAR(50) NOT NULL,
                `Name` VARCHAR(255) NOT NULL,
                `Description` TEXT NOT NULL,
                `Price` DECIMAL(10, 2) NOT NULL,
                `Stock` INT NOT NULL
            )
            """;

        await con.ExecuteAsync(sql);
        await SeedProducts(con);
    }

    private static async Task SeedProducts(IDbConnection con)
    {
        var products = new Product[]
        {
            new("TD68253", "6491441394812", "Smartphone",
                "High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.",
                617.19m, 544),
            new("CZ53484", "6368963523559", "Laptop",
                "Lightweight and portable with 15.6-inch Full HD display, 8GB RAM, and 256GB SSD storage.", 356.65m,
                568),
            new("FB35922", "8881699627936", "Tablet",
                "10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.", 861.65m, 105),
            new("IS20644", "1534523183005", "Smartwatch",
                "Features heart rate monitor, GPS, and water resistance up to 50 meters. Compatible with iOS and Android.",
                789.44m, 954),
            new("LU95673", "6032995696139", "Headphones",
                "Noise-cancelling wireless headphones with up to 20 hours of battery life.", 94.11m, 567),
            new("XY85400", "2520200662887", "Graphics Card",
                "4GB GDDR6 memory, supports 4K gaming and multi-display setup.", 173.14m, 259),
            new("ZP61586", "2241328104430", "Monitor",
                "27-inch 4K UHD monitor with HDR10 support and minimal bezel design.", 901.65m, 436),
            new("TH53571", "0245988677671", "Keyboard",
                "Mechanical keyboard with customizable RGB lighting and ergonomic design.", 274.66m, 742),
            new("MY29339", "6404191439894", "Mouse",
                "Wireless gaming mouse with high precision sensor and 9 programmable buttons.", 64.76m, 975),
            new("XR26878", "0789770594260", "External Hard Drive",
                "2TB capacity, USB 3.0 connectivity, and durable enclosure for data protection.", 120.15m, 453),
            new("WW79090", "7490262975575", "Headphones",
                "Lightweight and portable with 15.6-inch Full HD display, 8GB RAM, and 256GB SSD storage.", 695.30m,
                637),
            new("VK54113", "8839104901621", "Headphones",
                "10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.", 743.17m, 172),
            new("XW41959", "7832516868866", "Laptop",
                "Wireless gaming mouse with high precision sensor and 9 programmable buttons.", 133.56m, 716),
            new("FA25407", "5391015198161", "Smartwatch",
                "Noise-cancelling wireless headphones with up to 20 hours of battery life.", 174.62m, 412),
            new("GR81300", "2665102017240", "Graphics Card",
                "27-inch 4K UHD monitor with HDR10 support and minimal bezel design.", 776.60m, 812),
            new("WP13912", "4916298427855", "Monitor",
                "27-inch 4K UHD monitor with HDR10 support and minimal bezel design.", 938.49m, 436),
            new("GS37661", "2277763130635", "Smartwatch",
                "10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.", 399.37m, 165),
            new("FE19152", "3259816034946", "Keyboard",
                "27-inch 4K UHD monitor with HDR10 support and minimal bezel design.", 682.67m, 788),
            new("DW66529", "9980828459581", "Laptop",
                "High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.",
                691.65m, 427),
            new("FA76633", "3947698047818", "Monitor",
                "27-inch 4K UHD monitor with HDR10 support and minimal bezel design.", 126.24m, 950),
            new("LW27571", "6093121217291", "Laptop",
                "High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.",
                469.92m, 355),
            new("AP99119", "0225349200458", "Smartphone",
                "27-inch 4K UHD monitor with HDR10 support and minimal bezel design.", 772.48m, 237),
            new("OL19077", "6796006499071", "Headphones",
                "Mechanical keyboard with customizable RGB lighting and ergonomic design.", 364.91m, 104),
            new("FC16317", "7719849237234", "External Hard Drive",
                "Wireless gaming mouse with high precision sensor and 9 programmable buttons.", 82.91m, 252),
            new("KX17761", "0150732977252", "External Hard Drive",
                "10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.", 916.94m, 445),
            new("ZX36683", "5683533063794", "Tablet",
                "High-performance device with a 6.5-inch OLED screen, 5G connectivity, and advanced camera system.",
                629.88m, 977),
            new("HP87474", "7997465591767", "Graphics Card",
                "Lightweight and portable with 15.6-inch Full HD display, 8GB RAM, and 256GB SSD storage.", 318.86m,
                556),
            new("AD58776", "2613592562313", "Monitor",
                "10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.", 474.85m, 487),
            new("NR75371", "4820045132278", "Laptop",
                "27-inch 4K UHD monitor with HDR10 support and minimal bezel design.", 399.64m, 887),
            new("UZ04525", "3719713163656", "External Hard Drive",
                "10-inch touch screen, compatible with stylus pen, perfect for drawing and note-taking.", 417.14m, 186)
        };

        const string sql =
            """
            INSERT INTO Products (
                Sku, Ean, Name, Description, Price, Stock
            ) VALUES (
                @Sku, @Ean, @Name, @Description, @Price, @Stock
            )
            """;
        await con.ExecuteAsync(sql, products);
    }
}
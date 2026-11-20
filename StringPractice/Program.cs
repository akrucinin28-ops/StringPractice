using System;
using System.Text;

Sale[] sales =
{
    new Sale("Ноутбук", 2, 50000),
    new Sale("Мышь", 3, 1500),
    new Sale("Клавиатура", 1, 3000)
};

ReportBuilder reportBuilder = new ReportBuilder();

string report = reportBuilder.BuildReport(sales);

Console.WriteLine(report);

class Sale
{
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Sale(string product, int quantity, decimal price)
    {
        Product = product;
        Quantity = quantity;
        Price = price;
    }
}

class ReportBuilder
{
    public string BuildReport(Sale[] sales)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("ОТЧЁТ О ПРОДАЖАХ");
        sb.AppendLine($"Дата: {DateTime.Now:dd.MM.yyyy}");
        sb.AppendLine();

        sb.AppendLine(
            "Товар".PadRight(20) +
            "Количество".PadRight(15) +
            "Цена".PadRight(15) +
            "Сумма"
        );

        decimal total = 0;

        foreach (Sale sale in sales)
        {
            decimal sum = sale.Quantity * sale.Price;
            total += sum;

            sb.AppendLine(
                sale.Product.PadRight(20) +
                sale.Quantity.ToString().PadRight(15) +
                sale.Price.ToString("F2").PadRight(15) +
                sum.ToString("F2")
            );
        }

        sb.AppendLine();
        sb.AppendLine($"Общий итог: {total:F2}");

        return sb.ToString();
    }
}

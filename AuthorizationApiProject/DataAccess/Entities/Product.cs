using System;

namespace AuthorizationApiProject.DataAccess.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

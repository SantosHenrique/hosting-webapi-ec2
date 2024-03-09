using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public static Product Create(string name, string description, decimal price)
    {
        return new Product()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price
        };
    }
}
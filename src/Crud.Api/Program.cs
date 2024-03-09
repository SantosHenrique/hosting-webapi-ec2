using Crud.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductDbContext>(c => c.UseNpgsql(connectionString));

var app = builder.Build();


using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
if (context.Database.GetPendingMigrations().Any())
{
    await context.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", async (ProductDbContext context) =>
{
    var products = await context.Products.ToListAsync();
    return Results.Ok(products);
})
.WithName("GetProducts")
.WithOpenApi();

app.Run();

record CreateProductRequest(string Name, string Description, decimal Price);
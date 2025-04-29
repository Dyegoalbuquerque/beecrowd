using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesApi.Infrastructure.Extensions;
using SalesApi.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SalesApi.Application.Sales.Commands.CreateSaleCommand).Assembly));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Logging.AddConsole();

builder.Services.AddApplicationServices();

builder.Services.AddDbContext<SalesDbContext>(options =>
     options.UseNpgsql(builder.Configuration.GetConnectionString("SalesApiDb"), b => b.MigrationsAssembly("SalesApi.Infrastructure"))
 );

builder.Services.AddHealthChecks();
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SalesDbContext>();

    var retries = 10;
    while (retries > 0)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch (Exception ex)
        {
            retries--;
            Console.WriteLine($"Error apply migrations, trying again... ({retries})");
            Thread.Sleep(2000);
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

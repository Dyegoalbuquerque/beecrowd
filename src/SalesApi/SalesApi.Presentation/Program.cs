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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SalesDbContext>();
    db.Database.Migrate();
}




app.UseAuthorization();

app.MapControllers();

app.Run();

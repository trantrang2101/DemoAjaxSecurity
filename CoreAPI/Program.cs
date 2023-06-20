using CoreAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DBContext.

var configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("Database");
builder.Services.AddDbContext<StoreContext>(options =>
        options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    context.Database.EnsureCreated();
    var initialize = new Initialize(context);
    initialize.InitializeData();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

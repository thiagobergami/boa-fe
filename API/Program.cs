using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptions => { });
});
builder.Services.AddCors();

builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<CondominiumsService>();
builder.Services.AddScoped<UnitsService>();
builder.Services.AddScoped<MaintenancesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//Configure the HTTP request pipeline
app.MapControllers();

/* app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: ""
);
 */
app.Run();

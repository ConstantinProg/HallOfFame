using Microsoft.EntityFrameworkCore;
using HallOfFame.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddDbContext<FameDbContext>(opts =>
{
    opts.UseSqlServer(
    builder.Configuration["ConnectionStrings:HallOfFameConnection"]);
});
builder.Services.AddScoped<IPersonRepository, EFPersonRepository>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
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
app.MapControllers();
SeedData.EnsurePopulated(app);
app.Run();

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NttDataTest.API.Automapper;
using NttDataTest.CONTEXT.Context;
using NttDataTest.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);
#region RegisterAddCors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*")
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
#endregion

// Add services to the container.
RegisterDependency.RegisterDependencies(builder.Services);
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Automapping());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddDbContext<NttDataTestContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

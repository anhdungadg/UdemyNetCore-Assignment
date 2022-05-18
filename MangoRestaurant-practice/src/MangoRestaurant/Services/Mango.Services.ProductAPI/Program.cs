using AutoMapper;
using Serilog;
using Mango.Services.ProductAPI;
using Mango.Services.ProductAPI.Infrastructures;
using Microsoft.EntityFrameworkCore;

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

var builder = WebApplication.CreateBuilder(args);

Log.Logger = CreateSerilogLogger(builder.Configuration);

Log.Information("Starting web host");


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// -----------------
Serilog.ILogger CreateSerilogLogger(IConfiguration cfg)
{
    return new LoggerConfiguration()
        .MinimumLevel.Debug()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();
}
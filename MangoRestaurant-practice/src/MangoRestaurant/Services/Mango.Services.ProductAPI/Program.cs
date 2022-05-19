/* 
 * 
 * 

<!-- Đức Phật nơi đây xin phù hộ code con chạy không Bug. Nam mô a di đà Phật.
                           _
                        _ooOoo_
                       o8888888o
                       88" . "88
                       (| -_- |)
                       O\  =  /O
                    ____/`---'\____
                  .'  \\|     |//  `.
                 /  \\|||  :  |||//  \
                /  _||||| -:- |||||_  \
                |   | \\\  -  /'| |   |
                | \_|  `\`---'//  |_/ |
                \  .-\__ `-. -'__/-.  /
              ___`. .'  /--.--\  `. .'___
           ."" '<  `.___\_<|>_/___.' _> \"".
          | | :  `- \`. ;`. _/; .'/ /  .' ; |
          \  \ `-.   \_\_`. _.'_/_/  -' _.' /
===========`-.`___`-.__\ \___  /__.-'_.'_.-'================
                        `=--=-'                    kimcang -->
Ở đời người ta gặp nhau không ngoài chuyên ân oán, có ân thì báo ân,
có oán thì báo oán. Vợ chồng cha mẹ anh em là duyên nợ, có duyên thì tụ, hết duyên thì tán...

 * 
 * 
 */



using AutoMapper;
using Serilog;
using Mango.Services.ProductAPI;
using Mango.Services.ProductAPI.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Mango.Services.ProductAPI.Repository;

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

var builder = WebApplication.CreateBuilder(args);

Log.Logger = CreateSerilogLogger(builder.Configuration);

Log.Information("Starting web host ({ApplicationContext})...", "Ahuhu");


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();
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
using Ocelot.DependencyInjection;
using Ocelot.Middleware;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



// Ocelot
new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json")
        .AddJsonFile("ocelot.json")
        .AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.AddOcelot();
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        logging.AddConsole();
    })
    .UseIISIntegration()
    .Configure(app =>
    {
        app.UseOcelot().Wait();
    })
    .Build()
    .Run();


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

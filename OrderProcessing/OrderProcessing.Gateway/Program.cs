using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using Serilog.Sinks.MongoDB;
using Serilog.Sinks.RollingFile;
using ILogger = Serilog.ILogger;
using WebApi.Helper;
using OrderProcessing.Gateway;


var configuration = GetConfiguration();
Log.Logger = CreateSerilogLogger(configuration);

var ocelotConfiguration = GetOcelotConfiguration();
//IConfiguration configOcelot = new ConfigurationBuilder()
//    .AddJsonFile("ocelot.json")
//    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(Log.Logger);

Log.Information("Configuring web host ({ApplicationContext})...", Program.AppName);

// START: Authentication
//var identityUrl = builder.Configuration.GetValue<string>("IdentityUrl");
//var authenticationProviderKey = "IdentityApiKey";
//builder.Services.AddAuthentication()
//                .AddJwtBearer(authenticationProviderKey, x =>
//                {
//                    x.Authority = identityUrl;
//                    x.RequireHttpsMetadata = false;
//                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
//                    {
//                        ValidAudiences = new[] { "orders", "basket", "locations", "marketing", "mobileshoppingagg", "webshoppingagg" }
//                    };
//                });
// END: Authentication


//builder.Configuration.AddOcelotWithSwaggerSupport(options =>
//{
//    options.PrimaryOcelotConfigFileName = "ocelot.json";
//    options.FileOfSwaggerEndPoints = "ocelot.SwaggerEndPoints.json";
//});

// Add services to the container.
builder.Services.AddControllers();



builder.Services.AddOcelot(ocelotConfiguration);
builder.Services.AddSwaggerForOcelot(ocelotConfiguration, (options) =>
{
    options.GenerateDocsForGatewayItSelf = true;
});

//var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
//    .AddOcelot(routes, builder.Environment)
//    .AddEnvironmentVariables();

//ILogger logger = new LoggerConfiguration()
//    .Enrich.WithExceptionDetails()
//    .WriteTo.Sink(new RollingFileSink(
//        @"D:\WorkingCopy\UdemyNetCore-Assignment\OrderProcessing\OrderProcessing.Gateway\logsJson",
//        new JsonFormatter(renderMessage: true), 99, 99, System.Text.Encoding.UTF8, true))
//    .CreateLogger();

//logger.Debug("Logger created");


// Đã có hàm CreateSerilogLogger
//string seqServerUrl = configuration["Serilog:SeqServerUrl"];
//builder.Host.UseSerilog((ctx, lc) => lc

//    .MinimumLevel.Information()
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
//    //.WriteTo.MongoDB("mongodb://localhost:27017/serilog", "OrderProcessing")
//    .WriteTo.Seq(seqServerUrl)
//    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(options =>
//    {
//        options.DocumentTitle = "NonOcelot";
//        options.InjectStylesheet("/Assests/css/theme-newspaper.css");   // Thanks https://ostranme.github.io/swagger-ui-themes/ for free beautiful theme
//    });
//}





//app.UseOcelot().Wait();
//app.UseOcelot();
app.UseStaticFiles();

app.UseSwaggerForOcelotUI(options =>
{
    //options.PathToSwaggerGenerator = "/swagger/docs";
    options.DocumentTitle = "ISC OSU2 - Tài liệu kỹ thuật API";
    options.InjectStylesheet("/Assests/css/theme-newspaper.css");   // Thanks https://ostranme.github.io/swagger-ui-themes/ for free beautiful theme

}).UseMiddleware<RequestResponseLoggingMiddleware>().UseOcelot().Wait();



//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello World!");
//    });
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Global exception handler
//app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseSerilogRequestLogging();

app.Run();






// -----

Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
{
    var seqServerUrl = configuration["Serilog:SeqServerUrl"];
    //var logstashUrl = configuration["Serilog:LogstashgUrl"];
    return new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationContext", Program.AppName)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
        //.WriteTo.Http(string.IsNullOrWhiteSpace(logstashUrl) ? "http://logstash:8080" : logstashUrl)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    var config = builder.Build();

    //if (config.GetValue<bool>("UseVault", false))
    //{
    //TokenCredential credential = new ClientSecretCredential(
    //    config["Vault:TenantId"],
    //    config["Vault:ClientId"],
    //    config["Vault:ClientSecret"]);
    ////builder.AddAzureKeyVault(new Uri($"https://{config["Vault:Name"]}.vault.azure.net/"), credential);        
    //}

    return builder.Build();
}

IConfiguration GetOcelotConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    var config = builder.Build();

    //if (config.GetValue<bool>("UseVault", false))
    //{
    //TokenCredential credential = new ClientSecretCredential(
    //    config["Vault:TenantId"],
    //    config["Vault:ClientId"],
    //    config["Vault:ClientSecret"]);
    ////builder.AddAzureKeyVault(new Uri($"https://{config["Vault:Name"]}.vault.azure.net/"), credential);        
    //}

    return builder.Build();
}

public partial class Program
{
    public static string Namespace = typeof(RequestResponseLoggingMiddleware).Namespace;    // Lấy tạm RequestResponseLoggingMiddleware để get namespace
    public static string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
}
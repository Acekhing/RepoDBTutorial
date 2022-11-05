using RepoDb;
using RepoDBTutorial;
using RepoDBTutorial.Repositories;

var builder = WebApplication.CreateBuilder(args);

GlobalConfiguration.Setup().UseSqlServer();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

builder.Services.Configure<AppSetting>(configuration.GetSection("AppSetting"));

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
    });
}

app.Run();

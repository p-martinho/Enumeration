using System.Reflection;
using Microsoft.OpenApi.Models;
using PMart.Enumeration.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sample API",
        Description = "An ASP.NET Core Web API",
        TermsOfService = new Uri("https://sample.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Sample Contact",
            Url = new Uri("https://sample.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Sample License",
            Url = new Uri("https://sample.com/license")
        }
    });
    
    options.SchemaFilter<EnumerationSchemaFilter>();

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
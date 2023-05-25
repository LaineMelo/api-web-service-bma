using api_web_service_bma.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { Title = "Banco de Alimentos", 
      Version = "v1",
      Description = "Esse � um Sistema de cadastro baseado nas especifica��es OpenAPI 3.0. O Banco de Alimentos � um sistema com o objetivo de facilitar e agilizar o processo de cadastro de entrega de cestas b�sicas para fam�lias que encontram-se em situa��o de vulnerabilidade social. Projeto criado e desenvolvido pelas alunas: Amanda Paloma e Elaine Souza para o 4� per�odo do curso de Sistemas para Internet, ministrado na Puc Minas EAD.",
       License = new OpenApiLicense
       {
           Name = "Apache 2.0",
           Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
       }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.CustomOperationIds(apiDesc =>
    {
        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
    });

    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI((c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banco de Alimentos API v1");
}));

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using exemploAPIValidarXML;
using exemploAPIValidarXML.Services.XmlValidation.Services;
using exemploAPIValidarXML.Services.XmlValidation.ServicesInterfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);

// 1. Defina a política de liberação de segurança
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson() 
    .AddXmlSerializerFormatters()
    .AddXmlDataContractSerializerFormatters();


// 2. Injeção de Dependência do seu validador
builder.Services.AddScoped<IXMLValidationService, XMLValidationService>();

builder.Services.AddOpenApi(options =>
{
    options.AddSchemaTransformer((schema, context, cancellationToken) =>
    {
        // Valida se é o parâmetro de rota/query OU se é uma propriedade de uma classe/DTO
        if (context.ParameterDescription?.Name == "strDocumento" ||
            context.JsonTypeInfo.Properties.Any(p => p.Name == "strDocumento"))
            {
                schema.Format = "textarea";
            }
        return Task.CompletedTask;
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// 1. ATIVE O CORS IMEDIATAMENTE (Corrige o erro de "Failed to fetch")
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAI Agent API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Application.Interfaces;
using Application.Services;
using Domain.Factories;
using Infrastructure.Providers.AWS;
using Infrastructure.Providers.Azure;
using Infrastructure.Providers.GCP;
using Infrastructure.Providers.OnPremise;

var builder = WebApplication.CreateBuilder(args);

// --- Servicios básicos ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Registro de fábricas (Abstract Factory) ---
var factories = new Dictionary<string, ICloudResourceFactory>(StringComparer.OrdinalIgnoreCase)
{
    { "aws", new AwsResourceFactory() },
    { "azure", new AzureResourceFactory() },
    { "gcp", new GcpResourceFactory() },
    { "onpremise", new OnPremResourceFactory() }
};

// --- Registro del servicio de aprovisionamiento ---
builder.Services.AddSingleton<IProvisioningService>(sp =>
    new ProvisioningService(factories)
);

var app = builder.Build();

// --- Middlewares ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

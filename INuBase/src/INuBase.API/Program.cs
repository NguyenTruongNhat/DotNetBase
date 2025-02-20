using Carter;
using INuBase.API.DependencyInjection.Extensions;
using INuBase.API.Middleware;
using INuBase.Application.DependencyInjection.Extensions;
using INuBase.Infrastructure.Dapper.DependencyInjection.Extensions;
using INuBase.Persistence.DependencyInjection.Extensions;
using INuBase.Persistence.DependencyInjection.Options;
using INuBase.Presentation.APIs.Products;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging
    .ClearProviders()
    .AddSerilog();

builder.Host.UseSerilog();

builder.Services.AddConfigureMediatR();


builder.Services.AddControllers()
                .AddApplicationPart(INuBase.Presentation.AssemblyReference.Assembly);

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Configure Options and SQL
builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
builder.Services.AddSqlConfiguration();
builder.Services.AddRepositoryBaseConfiguration();
//builder.Services.AddConfigureAutoMapper();

builder.Services.AddCarter();

// Configure Dapper
builder.Services.AddInfrastructureDapper();

builder.Services
        .AddSwaggerGenNewtonsoftSupport()
        .AddFluentValidationRulesToSwagger()
        .AddEndpointsApiExplorer()
        .AddSwagger();

builder.Services
    .AddApiVersioning(options => options.ReportApiVersions = true)
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Add API Endpoint
app.NewVersionedApi("products-minimal-show-on-swagger").MapProductApiV1().MapProductApiV2();

//// Add API Endpoint with carter module
app.MapCarter();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

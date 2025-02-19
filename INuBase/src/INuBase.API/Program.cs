using INuBase.API.DependencyInjection.Extensions;
using INuBase.Application.DependencyInjection.Extensions;
using INuBase.Persistence.DependencyInjection.Extensions;
using INuBase.Persistence.DependencyInjection.Options;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(INuBase.Application.AssemblyReference.Assembly));
builder.Services.AddConfigureMediatR();

builder.Services.AddControllers()
                .AddApplicationPart(INuBase.Presentation.AssemblyReference.Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure Options and SQL
builder.Services.ConfigureSqlServerRetryOptions(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
builder.Services.AddSqlConfiguration();
builder.Services.AddRepositoryBaseConfiguration();



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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

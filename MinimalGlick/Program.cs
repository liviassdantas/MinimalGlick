using Swashbuckle;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinimalGlick.Models;
using MinimalGlick.Services;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GlycemiaDatabaseSettings>(
 builder.Configuration.GetSection("GlycemiaDatabase"));

builder.Services.AddSingleton<GlycemiaServices>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Glick Minimal API",
        Description = "An API to record and show glycemia's measures."
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

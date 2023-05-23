using Swashbuckle;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinimalGlick.Models;
using MinimalGlick.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GlycemiaDatabaseSettings>(
    builder.Configuration.GetSection("GlycemiaDatabase"));

builder.Services.AddSingleton<GlycemiaServices>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme);


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

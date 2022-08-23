using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WkCommerce.Infrastucture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(WkCommerce.Application.ReferenceClass).Assembly);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// DbContext 
builder.Services.AddDbContextPool<AppDbContext>(options => 
    options.UseInMemoryDatabase(AppDomain.CurrentDomain.FriendlyName));  

// Dependencies
builder.Services.Scan(s =>
{
    s.FromAssemblyOf<WkCommerce.Application.ReferenceClass>()
        .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
        .AsImplementedInterfaces()
        .WithTransientLifetime();
    s.FromAssemblyOf<WkCommerce.Infrastucture.ReferenceClass>()
        .AddClasses()
        .AsSelfWithInterfaces()
        .WithTransientLifetime();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
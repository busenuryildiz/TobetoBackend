using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business;
using Business.DependencyResolvers.Autofac;
using Castle.Core.Configuration;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using DataAccess;
using DataAccess.Context;
using DataAccess.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;




var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices(builder.Configuration);
var config = builder.Configuration;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddDbContext<TobetoContext>(options => options.UseSqlServer(config.GetConnectionString("Tobeto")));

//builder.Host
//.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//.ConfigureContainer<ContainerBuilder>(builder =>
//{
//    builder.RegisterInstance(config).As<Microsoft.Extensions.Configuration.IConfiguration>();
//    builder.Register<DbContextOptions<TobetoContext>>(c =>
//    {
//        var dbContextOptionsBuilder = new DbContextOptionsBuilder<TobetoContext>();
//        dbContextOptionsBuilder.UseSqlServer(c.Resolve<Microsoft.Extensions.Configuration.IConfiguration>().GetConnectionString("Tobeto"));
//        return dbContextOptionsBuilder.Options;
//    }).InstancePerLifetimeScope();


//    builder.RegisterModule(new AutofacDataAccessModule(config));
//    builder.RegisterModule(new AutofacBusinessModule(config));

//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();


app.UseAuthorization();

app.MapControllers();

app.Run();

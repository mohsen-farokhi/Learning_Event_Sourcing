using AuctionManagement.Config;
using AuctionManagement.Gateways.RestApi;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using ServiceHost.ModelConventions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new CqrsModelConvention());
}).PartManager.ApplicationParts.Add(new AssemblyPart(typeof(AuctionsController).Assembly));

builder.Host.ConfigureContainer<ContainerBuilder>
    (builder => builder.RegisterModule(new AuctionModule()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

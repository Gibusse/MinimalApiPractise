using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApiPractise.Application.Abstractions;
using MinimalApiPractise.Application.Commands;
using MinimalApiPractise.DataAccess.ApiDbContext;
using MinimalApiPractise.DataAccess.Repositories;
using MinimalApiPractise.MinimalApi.Abstractions;

namespace MinimalApiPractise.MinimalApi.Extensions;

public static class MinimalApiExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(cs));
        builder.Services.AddScoped<IRepoNote, RepoNote>();
        builder.Services.AddMediatR(typeof(CreateNote));
    }

    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly
                                                        .GetTypes()
                                                        .Where(t => t.IsAssignableTo(typeof(IEndPointDefinition))
                                                            && !t.IsAbstract && !t.IsInterface)
                                                        .Select(Activator.CreateInstance)
                                                        .Cast<IEndPointDefinition>();
                            
        foreach(var endpointDef in endpointDefinitions)
        {
            endpointDef.RegisterEndpoints(app);
        }
    }
}
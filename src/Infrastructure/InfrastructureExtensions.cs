using Business.Gateways.Clients.Interfaces;
using Infrastructure.Clients;
using Infrastructure.Clients.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.MongoDb.Connections;
using Infrastructure.MongoDb.Connections.Interfaces;
using Infrastructure.MongoDb.Factories;
using Infrastructure.MongoDb.Options;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System.Net.Http.Headers;

namespace Infrastructure;

public static class InfrastructureExtensions
{
    const string MONGO_CONNECTION_STRING_VARIABLE_KEY = "MongoConnectionString";
    const string APP_NAME_VARIABLE_KEY = "AppName";
    const string DEFAULT_CLUSTER_NAME = "default";

    public static IServiceCollection InjectInfrastructureDependencies(this IServiceCollection services)
    {
        services
            .RegisterMongoDbRepositories()
            .RegisterConnections()
            .RegisterClients();

        MongoGlobalOptions.Init();

        return services;
    }

    public static IServiceCollection RegisterMongoDbRepositories(this IServiceCollection services)
    {
        services
            .AddSingleton<IOrderMongoDbRepository, OrderMongoDbRepository>()
            .AddSingleton<IMenuItemMongoDbRepository, MenuItemMongoDbRepository>();

        return services;
    }

    private static IServiceCollection RegisterConnections(this IServiceCollection services)
    {
        var mongoConnectionString = Environment.GetEnvironmentVariable(MONGO_CONNECTION_STRING_VARIABLE_KEY);

        EnvironmentVariableNotFoundException.ThrowIfIsNullOrWhiteSpace(mongoConnectionString, MONGO_CONNECTION_STRING_VARIABLE_KEY);

        var appName = Environment.GetEnvironmentVariable(APP_NAME_VARIABLE_KEY);

        EnvironmentVariableNotFoundException.ThrowIfIsNullOrWhiteSpace(appName, APP_NAME_VARIABLE_KEY);

        var connection = new MongoConnection(DEFAULT_CLUSTER_NAME, mongoConnectionString!, appName);

        services
            .AddSingleton<IMongoConnection>(connection)
            .AddSingleton(MongoDataContextFactory.Create);

        return services;
    }

    public static IServiceCollection RegisterClients(this IServiceCollection services)
    {
        const string CUSTOME_API_URL = "CUSTOMER_API_URL";
        const int RETRY_COUNT = 3;

        var customerApiUrl = Environment.GetEnvironmentVariable(CUSTOME_API_URL);
        EnvironmentVariableNotFoundException.ThrowIfIsNullOrWhiteSpace(customerApiUrl, CUSTOME_API_URL);


        services.AddHttpClient<IHttpCustomerClient, HttpCustomerClient>(client =>
        {
            client.BaseAddress = new Uri(customerApiUrl!);
        })
        .AddTransientHttpErrorPolicy(policyBuilder =>
        {
            return policyBuilder.WaitAndRetryAsync(
                RETRY_COUNT,
                attempt => TimeSpan.FromSeconds(0.4 * Math.Pow(2, attempt)));
        });

        return services;
    }
}

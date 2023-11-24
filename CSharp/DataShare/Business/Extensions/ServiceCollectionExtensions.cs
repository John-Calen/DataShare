using Business.Abstractions;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors
                .AddDataService()
                .AddFileStorage()
                .AddUserService()
                .AddTextDataService()
                .AddFileDataService()
                .AddElementService();
        }

        public static IServiceCollection AddDataService(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors.AddDbContext<DataContext>((options) => options.UseSqlite("Data Source=data.db"));
        }

        public static IServiceCollection AddFileStorage(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors.AddScoped<IFileStorage>((provider) => new FileStorage("storage"));
        }

        public static IServiceCollection AddUserService(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors.AddTransient<IUserService, UserService>();
        }

        public static IServiceCollection AddTextDataService(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors.AddTransient<ITextDataService, TextDataService>();
        }

        public static IServiceCollection AddFileDataService(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors.AddTransient<IFileDataService, FileDataService>();
        }

        public static IServiceCollection AddElementService(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors.AddTransient<IDataService, DataService>();
        }
    }
}

using InveTime.Database.DbRepositories.Base;
using InveTime.DataEntities.Entities;
using InveTime.Interfaces.Base.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InveTime.Database.DbRepositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddDbRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Category>, DbRepository<Category>>()
            .AddTransient<IRepository<CategorySearchWord>, DbRepository<CategorySearchWord>>()
            .AddTransient<IRepository<Employee>, DbRepository<Employee>>()
            .AddTransient<IRepository<Inventory>, DbRepository<Inventory>>()
            .AddTransient<IRepository<Market>, DbRepository<Market>>()
            .AddTransient<IRepository<Position>, DbRepository<Position>>()
            .AddTransient<IRepository<Product>, DbRepository<Product>>()
            .AddTransient<IRepository<ProductInvented>, DbRepository<ProductInvented>>()
            ;
    }
}

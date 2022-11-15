﻿namespace CourseWork.ComputingAPI.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Конфигурация сервисов API.
    /// </summary>
    public static class ConfigureApiServices
    {
        /// <summary>
        /// Метод расширения для IServiceCollection для добавления API сервисов.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <returns>Добавленные сервисы.</returns>
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
            return services;
        }
    }
}

using System;
using System.Threading.Tasks;
using HelloHttpClient.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HelloHttpClient.Tests
{
    public class HelloHttpClientTests
    {
        [Fact]
        public async Task Get_All_Todos()
        {
            var serviceProvider = Bootstrapper.GetServiceProvider();
            var service = serviceProvider.GetRequiredService<ITodoService>();

            var tasks = await service.GetAllAsync();
            
            Assert.NotEmpty(tasks);
        }

        [Fact]
        public async Task Get_Existing_Todo()
        {
            var serviceProvider = Bootstrapper.GetServiceProvider();
            var service = serviceProvider.GetRequiredService<ITodoService>();

            var task = await service.GetTodoAsync(1);

            Assert.NotNull(task);
        }

        [Fact]
        public async Task Create_Todo()
        {
            var serviceProvider = Bootstrapper.GetServiceProvider();
            var service = serviceProvider.GetRequiredService<ITodoService>();

            var createdTask = await service.CreateTodoAsync(new Todo
            {
                Title = "something"
            });

            Assert.Equal(201, createdTask.Id);
        }

        [Fact]
        public async Task Update_Todo()
        {
            var serviceProvider = Bootstrapper.GetServiceProvider();
            var service = serviceProvider.GetRequiredService<ITodoService>();

            var updatedTask = await service.UpdateTodoAsync(new Todo
            {
                Id = 1,
                UserId = 1,
                Title = "something",
                IsCompleted = true
            });

            Assert.True(updatedTask.IsCompleted);
        }

        [Fact]
        public async Task Delete_Todo()
        {   
            var serviceProvider = Bootstrapper.GetServiceProvider();
            var service = serviceProvider.GetRequiredService<ITodoService>();

            await service.DeleteTodoAsync(1);
        }
    }
}

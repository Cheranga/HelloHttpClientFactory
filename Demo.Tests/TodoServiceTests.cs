using System.Threading.Tasks;
using Demo.Services;
using Demo.Services.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Demo.Tests
{
    public class TodoServiceTests
    {
        [Fact]
        public async Task Create_Todo()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<ITodoService>();

            var createdTask = await service.CreateTodoAsync(new Todo
            {
                Title = "something"
            });

            Assert.Equal(201, createdTask.Id);
        }

        [Fact]
        public async Task Delete_Todo()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<ITodoService>();

            await service.DeleteTodoAsync(1);
        }

        [Fact]
        public async Task Get_All_Todos()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<ITodoService>();

            var tasks = await service.GetAllAsync();

            Assert.NotEmpty(tasks);
        }

        [Fact]
        public async Task Get_Existing_Todo()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<ITodoService>();

            var task = await service.GetTodoAsync(1);

            Assert.NotNull(task);
        }

        [Fact]
        public async Task Update_Todo()
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

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
    }
}
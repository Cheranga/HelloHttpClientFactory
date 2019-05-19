using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Services.Models;

namespace Demo.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetTodoAsync(int id);
        Task<Todo> CreateTodoAsync(Todo task);
        Task<Todo> UpdateTodoAsync(Todo task);
        Task DeleteTodoAsync(int id);
    }
}
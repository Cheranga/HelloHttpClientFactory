using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHttpClient.Models;

namespace HelloHttpClient
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
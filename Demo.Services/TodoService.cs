using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Demo.Services.Models;
using Newtonsoft.Json;

namespace Demo.Services
{
    public class TodoService : ITodoService
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/todos/";
        private readonly HttpClient _client;

        public TodoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Todo>>(content);

            return tasks;
        }

        public async Task<Todo> GetTodoAsync(int id)
        {
            var httpResponse = await _client.GetAsync($"{BaseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var todoItem = JsonConvert.DeserializeObject<Todo>(content);

            return todoItem;
        }

        public async Task<Todo> CreateTodoAsync(Todo task)
        {
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PostAsync(BaseUrl, new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot add a todo task");
            }

            var createdTask = JsonConvert.DeserializeObject<Todo>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task<Todo> UpdateTodoAsync(Todo task)
        {
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PutAsync($"{BaseUrl}{task.Id}", new StringContent(content, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update todo task");
            }

            var createdTask = JsonConvert.DeserializeObject<Todo>(await httpResponse.Content.ReadAsStringAsync());
            return createdTask;
        }

        public async Task DeleteTodoAsync(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{BaseUrl}{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete the todo item");
            }
        }
    }
}
using Microsoft.JSInterop;
using System.Text.Json;

namespace TodoList.Services
{
    public class TodoService
    {
        private readonly IJSRuntime _jsRuntime;

        public TodoService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddOrUpdateTaskAsync(string title, TodoItem todoToAdd)
        {
            var jsonTodo = JsonSerializer.Serialize(todoToAdd);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", title, jsonTodo);
        }

        public async Task DeleteTaskAsync(string title)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", title);
        }

        public async Task<TodoItem?> GetTaskAsync(string title)
        {
            var jsonTodo = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", title);
            if (jsonTodo == null)
            {
                return null;
            }
            return JsonSerializer.Deserialize<TodoItem>(jsonTodo);
        }
        public async Task<List<string>> GetAllTaskKeys()
        {
            var keysJson = await _jsRuntime.InvokeAsync<string>("localStorage.getAllKeys");
            return JsonSerializer.Deserialize<List<string>>(keysJson);
        }
    }
}

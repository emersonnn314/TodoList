using Microsoft.JSInterop;
using System.Text.Json;

namespace TodoList.Services
{
    public class TodoItemLocalStorageService
    {
        private const string StorageKey = "TodoItems";

        private readonly IJSRuntime _jsRuntime;

        public TodoItemLocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", StorageKey);
            return string.IsNullOrEmpty(json)
                ? new List<TodoItem>()
                : JsonSerializer.Deserialize<List<TodoItem>>(json);
        }

        public async Task SaveTodoItemsAsync(List<TodoItem> todoItems)
        {
            var json = JsonSerializer.Serialize(todoItems);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
        }
    }
}

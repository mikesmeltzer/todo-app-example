using CS04_Coding_Assignment.Interfaces;
using CS04_Coding_Assignment.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CS04_Coding_Assignment.Services
{
    public class TodoService : ITodo
    {

        private readonly IMemoryCache _memoryCache;

        public TodoService(IMemoryCache memoryCache)
        {

            _memoryCache = memoryCache;

        }

        public Todo CreateTodo(Todo todo)
        {

            todo.SetCreatedDate();
            todo.SetUpdatedDate();

            todo.Id = GetNextId();

            _memoryCache.Set(todo.Id.ToString(), todo);

            return todo;

        }

        public void DeleteTodo(string id)
        {

            _memoryCache.Remove(id);

        }

        public Todo SaveTodo(Todo todo)
        {

            var updatedTodo = this.GetTodo(todo.Id.GetValueOrDefault().ToString());

            updatedTodo.Title = todo.Title;
            updatedTodo.Description = todo.Description;
            updatedTodo.CreatedOnDate = todo.CreatedOnDate;
            updatedTodo.IsComplete = todo.IsComplete;
            updatedTodo.SetUpdatedDate();

            _memoryCache.Set(todo.Id.ToString(), updatedTodo);

            return todo;

        }

        public Todo GetTodo(string id)
        {
            return (Todo)_memoryCache.Get(id);
        }

        public List<Todo> GetTodos()
        {
            List<Todo> todos = new();

            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition?.GetValue(_memoryCache) as dynamic;

            if (cacheEntriesCollection != null)
            {
                foreach (var cacheItem in cacheEntriesCollection)
                {
                    var cacheKey = cacheItem.GetType().GetProperty("Key").GetValue(cacheItem).ToString();

                    todos.Add(GetTodo(cacheKey));

                }
            }

            return todos.OrderBy(i => i.CreatedOnDate).ToList();

        }

        public void MarkTodoComplete(string id)
        {

            var todo = GetTodo(id);

            todo.IsComplete = true;

            todo.SetUpdatedDate();

            SaveTodo(todo);

        }

        private Guid GetNextId()
        {

            return Guid.NewGuid();

        }

    }

}

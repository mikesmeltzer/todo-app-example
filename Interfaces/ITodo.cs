using CS04_Coding_Assignment.Models;

namespace CS04_Coding_Assignment.Interfaces
{
    public interface ITodo
    {

        public Todo GetTodo(string id);

        public List<Todo> GetTodos();

        public Todo CreateTodo(Todo todo);

        public Todo SaveTodo(Todo todo);

        public void DeleteTodo(string id);

        public void MarkTodoComplete(string id);

    }

}

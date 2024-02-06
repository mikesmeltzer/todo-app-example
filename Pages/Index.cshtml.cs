using CS04_Coding_Assignment.Interfaces;
using CS04_Coding_Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS04_Coding_Assignment.Pages
{
    public class IndexModel : PageModel
    {
        public List<Todo> SavedTodos { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly ITodo _todoService;

        public IndexModel(ILogger<IndexModel> logger, ITodo todoService)
        {

            _logger = logger;
            _todoService = todoService;

        }

        public void OnGet()
        {

            SavedTodos = _todoService.GetTodos();

        }
    

        public IActionResult OnPost([FromBody] Todo todo)
        {

            if (todo.Id != null)
            {

                _todoService.SaveTodo(todo);

                return new OkResult();

            }
            else
            {

                Todo newTodo = _todoService.CreateTodo(todo);

                return new JsonResult(newTodo);

            }

        }
    
        public IActionResult OnDelete([FromBody] string id)
        {

            _todoService.DeleteTodo(id);

            return new OkResult();

        }

    }
}

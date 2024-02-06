using CS04_Coding_Assignment.Interfaces;
using CS04_Coding_Assignment.Models;
using CS04_Coding_Assignment.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace CS04_Coding_Assignment.UnitTests
{
    public class TodoServiceTests
    {
        private readonly TodoService TodoService;

        public TodoServiceTests()
        {

            var mockMemoryService = new Mock<IMemoryCache>();
            /*
            mockMemoryService
           .Setup(mc => mc.TryGetValue(It.IsAny<object>(), out whatever))
           .Callback(new OutDelegate<object, object>((object k, out object v) =>
               v = new object())) // mocked value here (and/or breakpoint)
           .Returns(true);

            TodoService = new(mockMemoryService.Object);

            */
        }

        [Fact]
        public void AddTodo()
        {

            var todo = CreateTodo();

            if (todo != null && todo.Id != null)
            {

                Assert.True(true);

            }
            else
            {

                Assert.Fail();

            }

        }

        private Todo CreateTodo()
        {

            Todo todo = new()
            {

                Title = "test title",
                Description = "This is a test.",
                IsComplete = false

            };

            var newTodo = TodoService.CreateTodo(todo);

            return newTodo;
        }


        [Fact]
        public void DeleteTodo()
        {

            var todo = CreateTodo();

            string todoId = todo.Id.GetValueOrDefault().ToString();

            TodoService.DeleteTodo(todoId);

            var deletedTodo = TodoService.GetTodo(todoId);

            if (deletedTodo == null)
            {

                Assert.True(true);

            }
            else
            {

                Assert.Fail();

            }

        }

        [Fact]
        public void EditTodo()
        {

            var todo = CreateTodo();

            if (todo != null)
            {

                string newTitle = "New Title";

                todo.Title = newTitle;

                var newTodo = TodoService.SaveTodo(todo);

                if (newTodo != null && newTodo.Title.Equals(newTitle))
                {

                    Assert.True(true);

                }
                else
                {

                    Assert.Fail();

                }

            }

        }

    }

}
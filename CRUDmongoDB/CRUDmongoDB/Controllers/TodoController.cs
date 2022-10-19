using CRUDmongoDB.models;
using CRUDmongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDmongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodosController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        //[Route("[action]")]
        //[Route("api/todos/GetTodos")]
        //public IEnumerable<Todo> GetEmployee()
        //{
        //    return _todoService.Get();
        //}
        public ActionResult<List<Todo>> Get() =>
            _todoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTodo")]
        public ActionResult<Todo> Get(string id)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Todo todo)
        {
            await _todoService.CreateAsync(todo);

            return CreatedAtAction(nameof(Get), new { id = todo.Id.ToString() }, todo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Todo todoIn)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Update(id, todoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Remove(id);

            return NoContent();
        }
    }
}
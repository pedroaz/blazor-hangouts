using BackendServer.Database;
using BackendServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly DatabaseService _databaseService;

        public TodoController(ILogger<TodoController> logger, DatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        [HttpGet("todo-items")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            try {
                return Ok(await _databaseService.RetrieveTodoItems());
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return BadRequest("Unable to retrieve the todo items");
            }
        }

        [HttpPost("todo-items")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Post([FromBody] IEnumerable<TodoItem> items)
        {
            try {
                await _databaseService.AddTodoItems(items);
                return Ok("Items added successfully");
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return BadRequest("Unable to add the todo items");
            }
        }

        [HttpPost("todo-items-mocked")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> AddMockedData()
        {
            try {
                await _databaseService.RemoveItems();
                await _databaseService.AddMockedItems();
                return Ok("Add mocked items successfully");
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return BadRequest("Unable to add mocked items");
            }
        }

        [HttpDelete("todo-items")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Delete([FromBody] IEnumerable<int> ids)
        {
            try {
                await _databaseService.RemoveItems(ids);
                return Ok("Items removed successfully");
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return BadRequest("Unable to remove the todo items");
            }
        }

        [HttpDelete("todo-items-all")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> DeleteAll()
        {
            try {
                await _databaseService.RemoveItems();
                return Ok("All items removed successfully");
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
                return BadRequest("Unable to remove all items");
            }
        }

        
    }
}

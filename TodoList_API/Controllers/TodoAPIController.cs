using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TodoAPI.Models;
using TodoListModels;

namespace TodoList_API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemsController : ControllerBase
{
        private readonly Databasecon _context;

        public TodoItemsController(Databasecon context)
        {
            _context = context;
        }

        [HttpGet("NoCompletedDate")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItemsWithNoCompletedDate()
        {
            var todoItems = await _context.TodoItems
                .Where(item => item.Completed_Date == null)
                .ToListAsync();

            if (todoItems == null || !todoItems.Any())
            {
                return NotFound();
            }

            return todoItems;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }   

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        [HttpPost("Complete/{id}")]
        public async Task<IActionResult> CompleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Completed_Date = DateTime.Now;
            await _context.SaveChangesAsync();

            return NoContent();
        }

}
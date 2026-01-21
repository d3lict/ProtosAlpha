using Microsoft.AspNetCore.Mvc;
using TestLinkBackend.Models;
using TestLinkBackend.Services;

namespace TestLinkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExecutionsController : ControllerBase
    {
        private readonly IExecutionService _executionService;

        public ExecutionsController(IExecutionService executionService)
        {
            _executionService = executionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var executions = await _executionService.GetAllAsync();
            return Ok(executions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var execution = await _executionService.GetByIdAsync(id);
            if (execution == null)
                return NotFound();
            return Ok(execution);
        }

        [HttpGet("testplan/{testPlanId}")]
        public async Task<IActionResult> GetByTestPlan(int testPlanId)
        {
            var executions = await _executionService.GetByTestPlanAsync(testPlanId);
            return Ok(executions);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Execution execution)
        {
            var created = await _executionService.CreateAsync(execution);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Execution execution)
        {
            var updated = await _executionService.UpdateAsync(id, execution);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _executionService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/addbug")]
        public async Task<IActionResult> AddBug(int id, [FromBody] string bugDescription)
        {
            await _executionService.AddBugAsync(id, bugDescription);
            return Ok();
        }

        [HttpPost("{id}/setresult")]
        public async Task<IActionResult> SetResult(int id, [FromBody] bool status)
        {
            await _executionService.SetResultAsync(id, status);
            return Ok();
        }
    }
}

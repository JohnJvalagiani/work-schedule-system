using Application.Services.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Controller for managing schedules.
/// </summary>
[ApiController]
[Route("api/schedules")]
public class SchedulesController : ControllerBase
{
    private readonly ISchedulerRepo _scheduleRepo;

    /// <summary>
    /// Initializes a new instance of the <see cref="SchedulesController"/> class.
    /// </summary>
    /// <param name="scheduleRepo">The schedule repository.</param>
    public SchedulesController(ISchedulerRepo scheduleRepo)
    {
        _scheduleRepo = scheduleRepo;
    }

    /// <summary>
    /// Gets the schedules for the current week.
    /// </summary>
    /// <returns>The schedules for the current week.</returns>
    [HttpGet("GetCurrentWeekSchedules")]
    [Authorize(Roles = "worker,Admin")]
    public async Task<ActionResult<IEnumerable<Schedule>>> GetCurrentWeekSchedules()
    {
        var currentWeekSchedules = await _scheduleRepo.GetCurrentWeekSchedulesAsync();

        return Ok(currentWeekSchedules);
    }

    /// <summary>
    /// Gets all schedules.
    /// </summary>
    /// <returns>All schedules.</returns>
    [HttpGet("GetAllSchedules")]
    [Authorize(Roles = "worker,Admin")]
    public async Task<ActionResult<IEnumerable<Schedule>>> GetAllSchedules()
    {
        var schedules = await _scheduleRepo.GetAllSchedulesAsync();

        return Ok(schedules);
    }

    /// <summary>
    /// Gets a schedule by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the schedule.</param>
    /// <returns>The schedule with the specified identifier.</returns>
    [HttpGet("GetSchedule/{id}")]
    [Authorize(Roles = "worker,Admin")]
    public async Task<ActionResult<Schedule>> GetSchedule(int id)
    {
        var schedule = await _scheduleRepo.GetScheduleByIdAsync(id);

        if (schedule == null)
        {
            return NotFound();
        }

        return Ok(schedule);
    }

    /// <summary>
    /// Creates a new schedule.
    /// </summary>
    /// <param name="schedule">The schedule to be created.</param>
    /// <returns>The newly created schedule's identifier.</returns>
    [HttpPost("PostSchedule")]
    [Authorize(Roles = "worker,Admin")]
    public async Task<ActionResult<int>> PostSchedule([FromBody]Schedule schedule)
    {
        var newScheduleId = await _scheduleRepo.AddScheduleAsync(schedule);

        return CreatedAtAction(nameof(GetSchedule), new { id = newScheduleId }, newScheduleId);
    }

    /// <summary>
    /// Approves a schedule by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the schedule to be approved.</param>
    /// <returns>A no content response.</returns>
    [HttpPut("ApproveSchedule/{id}")]
    [Authorize(Roles = "worker,Admin")]
    public async Task<IActionResult> ApproveSchedule(int id)
    {
        await _scheduleRepo.ApproveScheduleAsync(id);

        return NoContent();
    }

    /// <summary>
    /// Declines a schedule by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the schedule to be declined.</param>
    /// <returns>A no content response.</returns>
    [HttpPut("DeclineSchedule/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeclineSchedule(int id)
    {
        await _scheduleRepo.DeclineScheduleAsync(id);

        return NoContent();
    }

    /// <summary>
    /// Updates a schedule by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the schedule to be updated.</param>
    /// <param name="schedule">The updated schedule.</param>
    /// <returns>A no content response.</returns>
    [HttpPut("PutSchedule/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
    {
        await _scheduleRepo.UpdateScheduleAsync(id, schedule);
        
        return NoContent();
    }

    /// <summary>
    /// Deletes a schedule by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the schedule to be deleted.</param>
    /// <returns>A no content response.</returns>
    [HttpDelete("DeleteSchedule/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteSchedule(int id)
    {
        await _scheduleRepo.DeleteScheduleAsync(id);

        return NoContent();
    }
}

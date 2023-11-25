using Application.Services.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

[ApiController]
[Route("api/schedules")]
public class SchedulesController : ControllerBase
{
    private readonly ISchedulerRepo _scheduleRepo;

    public SchedulesController(ISchedulerRepo scheduleRepo)
    {
        _scheduleRepo = scheduleRepo;
    }
    
    [HttpGet("current-week")]
    [Authorize(Roles = "worker,admin")]
    public async Task<ActionResult<IEnumerable<Schedule>>> GetCurrentWeekSchedules()
    {
        var currentWeekSchedules = await _scheduleRepo.GetCurrentWeekSchedulesAsync();
        return Ok(currentWeekSchedules);
    }

    [HttpGet]
    [Authorize(Roles = "worker,admin")]
    public async Task<ActionResult<IEnumerable<Schedule>>> GetAllSchedules()
    {
        var schedules = await _scheduleRepo.GetAllSchedulesAsync();
        return Ok(schedules);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "worker,admin")]
    public async Task<ActionResult<Schedule>> GetSchedule(int id)
    {
        var schedule = await _scheduleRepo.GetScheduleByIdAsync(id);

        if (schedule == null)
        {
            return NotFound();
        }

        return Ok(schedule);
    }

    [HttpPost]
    [Authorize(Roles = "worker,admin")]
    public async Task<ActionResult<int>> PostSchedule(Schedule schedule)
    {
            var newScheduleId = await _scheduleRepo.AddScheduleAsync(schedule);
            return CreatedAtAction(nameof(GetSchedule), new { id = newScheduleId }, newScheduleId);
    }

    [HttpPut("{id}/approve")]
    [Authorize(Roles = "worker,admin")]
    public async Task<IActionResult> ApproveSchedule(int id)
    {
       
            await _scheduleRepo.ApproveScheduleAsync(id);
            return NoContent();
    }

    [HttpPut("{id}/decline")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeclineSchedule(int id)
    {
      
            await _scheduleRepo.DeclineScheduleAsync(id);
            return NoContent();
        
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
    {
            await _scheduleRepo.UpdateScheduleAsync(id, schedule);
            return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteSchedule(int id)
    {
            await _scheduleRepo.DeleteScheduleAsync(id);
            return NoContent();
    }

   
}

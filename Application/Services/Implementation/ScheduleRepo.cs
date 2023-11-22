﻿using Application.Services.Abstraction;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SchedulerRepo : ISchedulerRepo
{
    private readonly ApplicationDbContext _context;

    public SchedulerRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Schedule>> GetSchedulesAsync()
    {
        return await _context.Schedules.ToListAsync();
    }

    public async Task<Schedule> GetScheduleByIdAsync(int id)
    {
        return await _context.Schedules.FindAsync(id);
    }

    public async Task<int> AddScheduleAsync(Schedule schedule)
    {
        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync();
        return schedule.ScheduleId;
    }

    public async Task UpdateScheduleAsync(int id, Schedule schedule)
    {
        if (id != schedule.ScheduleId)
        {
            throw new ArgumentException("Invalid schedule ID");
        }

        _context.Entry(schedule).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteScheduleAsync(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);
        if (schedule != null)
        {
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }
    }
    public async Task ApproveScheduleAsync(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);

        if (schedule != null && schedule.Status == "Pending")
        {
            schedule.Status = "Approved";
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeclineScheduleAsync(int id)
    {
        var schedule = await _context.Schedules.FindAsync(id);

        if (schedule != null && schedule.Status == "Pending")
        {
            schedule.Status = "Declined";
            await _context.SaveChangesAsync();
        }
    }
}
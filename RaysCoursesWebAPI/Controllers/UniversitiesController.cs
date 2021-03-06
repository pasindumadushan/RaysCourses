﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaysCoursesWebAPI.Models;

namespace RaysCoursesWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly RaysCoursesContext _context;

        public UniversitiesController(RaysCoursesContext context)
        {
            _context = context;
        }

        // GET: api/Universities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversity()
        {
            return await _context.University.ToListAsync();
        }

        // GET: api/Universities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversity(int id)
        {
            var university = await _context.University.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            return university;
        }

        // PUT: api/Universities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(int id, University university)
        {
            if (id != university.UniId)
            {
                return BadRequest();
            }

            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Universities
        [HttpPost]
        public async Task<ActionResult<University>> PostUniversity(University university)
        {
            _context.University.Add(university);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversity", new { id = university.UniId }, university);
        }

        [HttpGet("University/{uniName}")]
        public async Task<University> University(string uniName)
        {
            var Resultuniversity = _context.University.Where(x => x.UniName.ToUpper() == uniName.ToUpper()).FirstOrDefault();

            return Resultuniversity;
        }

        // DELETE: api/Universities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<University>> DeleteUniversity(int id)
        {
            var university = await _context.University.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            _context.University.Remove(university);
            await _context.SaveChangesAsync();

            return university;
        }

        private bool UniversityExists(int id)
        {
            return _context.University.Any(e => e.UniId == id);
        }
    }
}

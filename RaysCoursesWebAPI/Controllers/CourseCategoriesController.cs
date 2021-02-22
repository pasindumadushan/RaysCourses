using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaysCoursesWebAPI.Models;

namespace RaysCoursesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController : ControllerBase
    {
        private readonly RaysCoursesContext _context;

        public CourseCategoriesController(RaysCoursesContext context)
        {
            _context = context;
        }

        // GET: api/CourseCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseCategory>>> GetCourseCategory()
        {
            return await _context.CourseCategory.ToListAsync();
        }

        // GET: api/CourseCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseCategory>> GetCourseCategory(int id)
        {
            var courseCategory = await _context.CourseCategory.FindAsync(id);

            if (courseCategory == null)
            {
                return NotFound();
            }

            return courseCategory;
        }

        // PUT: api/CourseCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseCategory(int id, CourseCategory courseCategory)
        {
            if (id != courseCategory.CatId)
            {
                return BadRequest();
            }

            _context.Entry(courseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseCategoryExists(id))
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

        // POST: api/CourseCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CourseCategory>> PostCourseCategory(CourseCategory courseCategory)
        {
            _context.CourseCategory.Add(courseCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseCategory", new { id = courseCategory.CatId }, courseCategory);
        }

        // DELETE: api/CourseCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseCategory>> DeleteCourseCategory(int id)
        {
            var courseCategory = await _context.CourseCategory.FindAsync(id);
            if (courseCategory == null)
            {
                return NotFound();
            }

            _context.CourseCategory.Remove(courseCategory);
            await _context.SaveChangesAsync();

            return courseCategory;
        }

        private bool CourseCategoryExists(int id)
        {
            return _context.CourseCategory.Any(e => e.CatId == id);
        }
    }
}

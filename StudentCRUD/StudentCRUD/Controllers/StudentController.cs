using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Helper;
using StudentCRUD.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _dbContext;

        private readonly IMapper _mapper;

        public StudentController(StudentDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetStudents()
        {
            var students =  await _dbContext.Student.ToListAsync();
            var result= _mapper.Map< List<Student> ,List <StudentViewModel>>(students);
            return Ok(result);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentViewModel>> GetStudent(int id)
        {
            var student = await _dbContext.Student.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<Student,StudentViewModel>(student);
            return result;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] StudentViewModel value)
        {
            var result = _mapper.Map<StudentViewModel,Student>(value);

            if (!StudentExists(result.Id))
            {
                _dbContext.Student.Add(result);
                _dbContext.SaveChanges();
            }

        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentViewModel value)
        {
            var result = _mapper.Map<StudentViewModel, Student>(value);
            var student = _dbContext.Student.FirstOrDefault(s => s.Id == id);
            if(student != null)
            {
                _dbContext.Entry<Student>(student).CurrentValues.SetValues(result);
                _dbContext.SaveChanges();
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _dbContext.Student.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _dbContext.Student.Remove(student);
                _dbContext.SaveChanges();
            }
        }

        [NonAction]
        private bool StudentExists(int id)
        {
            return _dbContext.Student.Any(e => e.Id == id);
        }

        [NonAction]
        private int StudentCountPerClass()
        {
            return _dbContext.Student.Count();
        }
    }
}

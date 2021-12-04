using AutoMapper;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("MyPolicy")]
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

        [EnableCors("MyPolicy")]
        [HttpGet("Studentperclass")]
        public IDictionary<string,int> GetCountOfStudentsPerClass()
        {
            var studentPerClass = new Dictionary<string, int>();

            var result =
                from s in _dbContext.Student
                join c in _dbContext.ClassEntities on s.ClassId equals c.Id
                select new { s, c };
            var result1 = from r in result
                          group r by r.c.ClassName into group1
                          select new
                          {
                              className = group1.Key,
                              spc = group1.Count()
                          };
               foreach(var item in result1)
            {
                studentPerClass.Add(item.className, item.spc);
            }
            return studentPerClass;
        }

        [HttpGet("studentpercountry")]
        public IDictionary<string, int> GetCountOfStudentsPerCountry()
        {
            var studentPerCountry = new Dictionary<string, int>();

            var result =
                from s in _dbContext.Student
                join c in _dbContext.Country on s.CountryId equals c.Id
                select new { s, c };
            var result1 = from r in result
                          group r by r.c.Name into group1
                          select new
                          {
                              countryName = group1.Key,
                              studentpercoutry = group1.Count()
                          };
            foreach (var item in result1)
            {
                studentPerCountry.Add(item.countryName, item.studentpercoutry);
            }
            return studentPerCountry;
        }
        [EnableCors("MyPolicy")]
        [HttpGet("GetAverageAgePerStudent")]
        public float GetAverageAgePerStudent()
        {
            var currentYear = System.DateTime.Now.Year;
            var result = _dbContext.Student.Select(x => (currentYear - x.DateOfBirth.Year)).Average();

            float Convertedvalue = (float)result;
            return Convertedvalue;
        }

        // GET: api/<StudentController>
        [HttpGet("getstudent")]
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

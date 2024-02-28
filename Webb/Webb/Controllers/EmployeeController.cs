using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Webb.Database;
using Webb.Models;

namespace Webb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DatabaseDbContext dbcontext;

        public EmployeeController(DatabaseDbContext dbcontext) 
        {
            this.dbcontext = dbcontext;
        }
        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Employee>> create([FromBody] Employee employee)
        {
            dbcontext.Employees.Add(employee);
            dbcontext.SaveChanges();
            return Ok();
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> getAll()
        {
            var get = dbcontext.Employees.ToList();
            return Ok(get);
        }

        [HttpGet("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> getAction(int id)
        {
            var _empl = dbcontext.Employees.Find(id);
            if (id != 0)
            {
                if (_empl != null)
                {
                    return Ok(_empl);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> update(int id, [FromBody] Employee _empl)
        {
            var employee = dbcontext.Employees.Find(id);
            if (id != 0)
            {
                if (_empl != null)
                {
                    //_empl.EmpName= employee.EmpName;
                    //_empl.EmpJoin= employee.EmpJoin;
                    //_empl.EmpAddress= employee.EmpAddress;
                    //_empl.EmpGender= employee.EmpGender;
                    //_empl.EmpMobile= employee.EmpMobile;
                    //_empl.EmpMail= employee.EmpMail;
                    employee.EmpName = _empl.EmpName;
                    employee.EmpJoin= _empl.EmpJoin;
                    employee.EmpAddress= _empl.EmpAddress;
                    employee.EmpGender= _empl.EmpGender;
                    employee.EmpMobile= _empl.EmpMobile;
                    employee.EmpMail= _empl.EmpMail;
                    dbcontext.Employees.Add(_empl);
                    dbcontext.SaveChanges();
                    return Ok(_empl);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult delete(int id)
        {
            var deleteempl = dbcontext.Employees.Find(id);
            if (id != 0)
            {
                if (deleteempl != null)
                {
                    dbcontext.Remove(deleteempl);
                    dbcontext.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }


}

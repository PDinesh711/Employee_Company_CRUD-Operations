using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webb.Database;
using Webb.Models;

namespace Webb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public readonly DatabaseDbContext dbcontext;
        public CompanyController(DatabaseDbContext dbcontext)
        {
            this.dbcontext = dbcontext;   
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Company>> create([FromBody] Company company)
        {
            dbcontext.Companys.Add(company);
            dbcontext.SaveChanges();
            return Ok("Added Successfully !.. ");
        }

        [HttpGet("getAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Company> getAll()
        {
            var get = dbcontext.Companys.ToList();
            return Ok(get);
        }

        [HttpGet("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Company> getAction(int id)
        {
            var _com = dbcontext.Companys.Find(id);
            if (id != 0)
            {
                if (_com != null)
                {
                    return Ok(_com);
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
        public ActionResult<Company> update(int id, [FromBody] Company _comp)
        {
            var comp = dbcontext.Companys.Find(id);
            if (id != 0)
            {
                if (_comp != null)
                {
                    comp.Name = _comp.Name;
                    comp.role = _comp.role;
                    comp.fromDate = _comp.fromDate;
                    comp.toDate = _comp.toDate;
                    comp.experiences= _comp.experiences;
                    _comp.country = _comp.country;   
                    comp.state= _comp.state;
                    comp.city= _comp.city;
                    dbcontext.Companys.Add(_comp);
                    dbcontext.SaveChanges();
                    return Ok(_comp);
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
            var deletecomp = dbcontext.Companys.Find(id);
            if (id != 0)
            {
                if (deletecomp != null)
                {
                    dbcontext.Remove(deletecomp);
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

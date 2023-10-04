using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeWebPortal.Data;
using EmployeeWebPortal.Model;

namespace EmployeeWebPortal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly APIContext _context;

        public EmployeeController(APIContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public JsonResult AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel.EmployeeId == 0)
                {
                    _context.Employees.Add(employeeModel);
                }
                else
                {
                    var existingEmployee = _context.Employees.Find(employeeModel.EmployeeId);
                    if (existingEmployee != null)
                    {
                        existingEmployee.Name = employeeModel.Name;
                        existingEmployee.DepartmentId = employeeModel.DepartmentId;
                    }
                    else
                    {
                        return new JsonResult(NotFound());
                    }
                }
                _context.SaveChanges();
                return new JsonResult(Ok(employeeModel));
            }
            catch (Exception ex)
            {
                return new JsonResult(BadRequest("Error Occurred: " + ex.ToString()));
            }
        }

        [HttpGet]
        public JsonResult GetEmployee(int employeeId)
        {
            var result=_context.Employees.Find(employeeId);

            if(result != null)
            {
                return new JsonResult(Ok(result));
            }

            return new JsonResult(NotFound());
        }

        [HttpDelete]
        public JsonResult DeleteEmployee(int employeeId)
        {
            var result=_context.Employees.Find(employeeId);

            if( result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Employees.Remove(result);
            _context.SaveChanges();
            
            return new JsonResult(NoContent());
        }

        [HttpGet]
        public JsonResult GetAllEmployees()
        {
            var result=_context.Employees.ToList();

            return new JsonResult(Ok(result));
        }

    }

}

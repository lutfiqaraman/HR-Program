using HRAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Department : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> CreateDepartment(CreateDepartmentDto department)
        {
            return NotFound();
        }
    }
}

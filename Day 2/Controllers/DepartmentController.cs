using Day2.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentManager _DepartmentManager;

        public DepartmentController(IDepartmentManager DepartmentManager)
        {
            _DepartmentManager = DepartmentManager;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DepartmentDetailReadDbo> getDetails(int id) 
        {
            DepartmentDetailReadDbo? departmentWithDetails =_DepartmentManager.GetDetail(id);
            if(departmentWithDetails == null) { return NotFound(); }
            return departmentWithDetails;
        }
    }
}

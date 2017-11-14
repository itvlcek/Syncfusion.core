using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.core.Services;
using System.Threading.Tasks;
using Syncfusion.core.Models;

namespace Syncfusion.core.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Data")]
    public class DataController : Controller
    {
        private EmployeeService _employeeService { get; set; }

        public DataController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var queryString = Request.Query;

            int skip = Convert.ToInt32(queryString["$skip"]);
            int take = Convert.ToInt32(queryString["$top"]);
            string sort = queryString["$orderby"];
            string filter = queryString["$filter"];

            //TODO: Filter request
            var result = await _employeeService.GetAll();

            return Json(new { result = result, count = result.Count() });
        }

        [HttpPut]
        public async Task<JsonResult> Update([FromBody]Employee value)
        {
            await _employeeService.Modify(value);
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> Insert([FromBody]Employee value)
        {            
            return Json(await _employeeService.Save(value));
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> Remove(string id)
        {
            var currentItem = await _employeeService.GetPostById(id); //change this if using EF
            await _employeeService.Delete(currentItem);
            return Json(id);
        }
    }
}
using ConsumeCourseApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsumeCourseApi.Controllers
{
    public class CourseAcessController : Controller
    {
        private readonly IApiService apiService;

        public CourseAcessController(IApiService apiService)
        {
            this.apiService = apiService;
        }
     
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await apiService.GetCourseAsync());

        }
    }
}
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsumeCourseApi.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration configuration;

        public ApiService(IHttpClientFactory httpClient , IConfiguration configuration)
        {
            //_httpClient = httpClient;
            _httpClient = httpClient.CreateClient("ApiClient");
            this.configuration = configuration;
        }

        public async Task<List<Course>> GetCourseAsync()
        {

            IList<Course> courseList = new List<Course>();

            //using (var client = new HttpClient())
            {
                //string uristring = configuration["ApiBaseUrl"];
               // client.BaseAddress = new Uri(uristring);
               
                //var response = await client.GetAsync("Course");
                var response = await _httpClient.GetAsync("Course");


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    courseList =  JsonConvert.DeserializeObject<IList<Course>>(content);

                }
                return courseList as List<Course>;
                
            }

        }
    }
}

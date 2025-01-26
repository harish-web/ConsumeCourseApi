namespace ConsumeCourseApi.Services
{
    public interface IApiService
    {
        public Task<List<Course>> GetCourseAsync();
    }
}

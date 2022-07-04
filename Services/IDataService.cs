using Asteroids.Models;

namespace Asteroids.Services
{
    public interface IDataService
    {
        public Neo GetData();
        public Task<Neo>? GetDataInRange(DateTime startDate, DateTime endDate);
        public Task<Apod> GetImageOfTheDay(string date);
    }
}
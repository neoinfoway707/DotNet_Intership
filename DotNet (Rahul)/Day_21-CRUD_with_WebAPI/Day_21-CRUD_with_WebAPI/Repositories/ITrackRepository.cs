using Day_21_CRUD_with_WebAPI.Dtos;
using Day_21_CRUD_with_WebAPI.Models;

namespace Day_21_CRUD_with_WebAPI.Repositories
{
    public interface ITrackRepository
    {
        Task<List<Track>> GetAllTracks();
        Task<Track?> GetTrackById(int id);
        Task<Track> CreateTrackAsync(TrackDto trackDto);
        Task<Track?> UpdateTrackAsync(int id, TrackDto trackDto);
        Task<bool> DeleteTrackAsync(int id);
    }
}

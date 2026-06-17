using Day23_NET_Core_and_Repository_Pattern.Dtos;
using Day23_NET_Core_and_Repository_Pattern.Models;

namespace Day23_NET_Core_and_Repository_Pattern.Repositories
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

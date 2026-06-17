using Day_24_Understanding_Repository_Pattern.Data;
using Day_24_Understanding_Repository_Pattern.Dtos;
using Day_24_Understanding_Repository_Pattern.Models;
using Microsoft.EntityFrameworkCore;
namespace Day_24_Understanding_Repository_Pattern.Repositories
{
    public class TrackRepository(AppDbContext _context, ILogger<TrackRepository> _logger) : ITrackRepository
    {
        public async Task<List<Track>> GetAllTracks()
        {
            _logger.LogInformation("Querying database for all active data.");
            return await _context.Tracks.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync();
        }

        public async Task<Track?> GetTrackById(int id)
        {
            _logger.LogInformation("Querying database for active Track Id {Id}", id);

            var find = await _context.Tracks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (find == null)
            {
                _logger.LogWarning("Track Id {Id} not found in database.", id);
                return null;
            }
            return find;
        }

        public async Task<Track> CreateTrackAsync(TrackDto trackDto)
        {
            var track = new Track
            {
                Title = trackDto.Title,
                Artist = trackDto.Artist,
                Genre = trackDto.Genre,
                DurationSeconds = trackDto.DurationSeconds,
                ReleaseYear = trackDto.ReleaseYear
            };
            _logger.LogInformation("Saving New Track {Title} to database", track.Title);
            try
            {
                using var trans = await _context.Database.BeginTransactionAsync();
                await _context.Tracks.AddAsync(track);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                _logger.LogInformation("Track {Title} saving with Id {Id}", track.Title, track.Id);
                return track;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create track {Title}", track.Title);
                throw;
            }
        }

        public async Task<Track?> UpdateTrackAsync(int id, TrackDto trackDto)
        {
            _logger.LogInformation("Querying database to update Track with id {Id}", id);

            var findTrack = await _context.Tracks.FirstOrDefaultAsync(x => x.Id == id);
            if (findTrack == null)
            {
                _logger.LogWarning("Track Id {Id} not found in database.", id);
                return null;
            }
            try
            {
                using var trans = await _context.Database.BeginTransactionAsync();
                findTrack.Title = trackDto.Title;
                findTrack.Artist = trackDto.Artist;
                findTrack.Genre = trackDto.Genre;
                findTrack.DurationSeconds = trackDto.DurationSeconds;
                findTrack.ReleaseYear = trackDto.ReleaseYear;

                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                _logger.LogInformation("Track Id {Id} updated Successfully.", id);
                return findTrack;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update track {Title}", findTrack.Title);
                throw;
            }
        }

        public async Task<bool> DeleteTrackAsync(int id)
        {
            _logger.LogInformation("Querying database to soft delete Track Id {Id}", id);
            var findTrack = await _context.Tracks.FirstOrDefaultAsync(x => x.Id == id);
            if (findTrack == null)
            {
                _logger.LogWarning("Track Id {Id} not found in database.", id);
                return false;
            }
            try
            {
                using var trans = await _context.Database.BeginTransactionAsync();
                findTrack.IsDeleted = true;

                await _context.SaveChangesAsync();
                await trans.CommitAsync();

                _logger.LogInformation("Track Id {Id} mark as deleted in database.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete track {Title}", findTrack.Title);
                throw;
            }
        }
    }
}

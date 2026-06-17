using Day_24_Understanding_Repository_Pattern.Const.Const;
using Day_24_Understanding_Repository_Pattern.Dtos;
using Day_24_Understanding_Repository_Pattern.Models;
using Day_24_Understanding_Repository_Pattern.Repositories;
using Day_24_Understanding_Repository_Pattern.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace Day_24_Understanding_Repository_Pattern.Controllers
{
    [ApiController]
    public class TrackController(ITrackRepository _repo, ILogger<TrackController> _logger) : ControllerBase
    {
        [HttpGet(TrackRoute.Track.GetAllTracks)]
        public async Task<IActionResult> GetAllTracks()
        {
            var listOfTracks = await _repo.GetAllTracks();
            _logger.LogInformation("Fetching all active Track Records");
            return Ok(new TrackResponse<List<Track>>(listOfTracks, "All Track Data retrieved Successfully"));
        }

        [HttpGet(TrackRoute.Track.GetTrackById)]
        public async Task<IActionResult> GetTrackById(int id)
        {
            var getTrack = await _repo.GetTrackById(id);
            if (getTrack == null)
            {
                _logger.LogWarning("Track with Id {Id} Not Found.", id);
                return NotFound(new TrackResponse<Track>($"Track with Id {id} Not Found."));
            }
            _logger.LogInformation("Fetching Track with Id {Id}", id);
            return Ok(new TrackResponse<Track>(getTrack, "Track Data retrieved Successfully"));
        }

        [HttpPost(TrackRoute.Track.CreateTrack)]
        public async Task<IActionResult> CreateTrack(TrackDto trackDto)
        {
            var addTrack = await _repo.CreateTrackAsync(trackDto);
            var wrapperResponse = new TrackResponse<Track>(addTrack, "New Track Data Created Successfully.");
            _logger.LogInformation("Track {Title} Created with Id {Id}", addTrack.Title, addTrack.Id);
            return CreatedAtAction(nameof(GetTrackById), new { Id = addTrack.Id }, wrapperResponse);
        }

        [HttpPut(TrackRoute.Track.UpdateTrack)]
        public async Task<IActionResult> UpdateTrack(int id, TrackDto trackDto)
        {
            var updateTrack = await _repo.UpdateTrackAsync(id, trackDto);
            if (updateTrack == null)
            {
                _logger.LogWarning("Track with Id {Id} Not Found.", id);
                return NotFound(new TrackResponse<Track>($"Track with Id {id} Not Found."));
            }
            _logger.LogInformation("Track {Title} Updated with Id {Id}", updateTrack.Title, updateTrack.Id);
            return Ok(new TrackResponse<Track>(updateTrack, "Track Data Updated Successfully"));
        }

        [HttpDelete(TrackRoute.Track.DeleteTrack)]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var deleteTrack = await _repo.DeleteTrackAsync(id);
            if (!deleteTrack)
            {
                _logger.LogWarning("Track with Id {Id} Not Found.", id);
                return NotFound(new TrackResponse<Track>($"Track with Id {id} Not Found."));
            }
            _logger.LogInformation("Track with Id {Id} is marked as Deleted at Database side.", id);
            return NoContent();
        }
    }
}
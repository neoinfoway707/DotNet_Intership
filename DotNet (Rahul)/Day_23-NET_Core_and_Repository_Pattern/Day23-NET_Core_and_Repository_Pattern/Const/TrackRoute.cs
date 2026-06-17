namespace Day23_NET_Core_and_Repository_Pattern.Const
{
    public class TrackRoute
    {
        public const string basic = "api";
        public class Track
        {
            public const string GetAllTracks = basic + "/Tracks";
            public const string GetTrackById = basic + "/Tracks/{id:int:min(1)}";
            public const string CreateTrack = basic + "/Tracks";
            public const string UpdateTrack = basic + "/Tracks/{id:int:min(1)}";
            public const string DeleteTrack = basic + "/Tracks/{id:int:min(1)}";
        }
    }
}
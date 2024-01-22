namespace Altimetrik_election__com.Models
{
    public class VotingsystemModel
    {
        public int Votingsystemid { get; set; }
        public int stateid { get; set; }
        public string  stateName { get; set; }
        public int partyid { get; set; }
        public int voiterid { get; set; }
        public DateTime voterdate { get; set; }
        public int cityid { get; set; }
        public string CityName { get; set; }
    }
}

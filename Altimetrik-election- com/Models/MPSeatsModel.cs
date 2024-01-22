namespace Altimetrik_election__com.Models
{
    public class MPSeatsModel
    {
        public int MpSeatsid { get; set; }
        public int Stateid { get; set; }
        public string StateName { get; set; }
        public string seats { get; set; }
        public string status { get; set; }
        public List<SateModel> statelist { get; set; }
        public int Cityid { get; set; }
        public string CityName { get; set; }
    }
    public class SateModel
    {
     
        public int Stateid { get; set; }
        public string StateName { get; set; }
      
    }
}

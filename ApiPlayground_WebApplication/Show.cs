using System;

namespace ApiPlayground_WebApplication
{
    public class Show
    {
        public Venue Venue { get; set; }
        public int ShowID { get; set; }
        public int VenueID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Payment { get; set; }
        public string Notes { get; set; }
        public object PrivateNotes { get; set; }
    }
}
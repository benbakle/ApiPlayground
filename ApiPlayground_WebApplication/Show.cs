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
        public decimal? Payment { get; set; }
        public string Notes { get; set; }
        public string PrivateNotes { get; set; }
    }
}
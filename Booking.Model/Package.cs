namespace Booking.Model {
    public class Package {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int Credit { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

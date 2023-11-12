using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Model {
    public class Schedule {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public ScheduleType ScheduleType { get; set; }
        public virtual Package Package { get; set; }
        public DateTime StartTime { get; set; }
    }
}

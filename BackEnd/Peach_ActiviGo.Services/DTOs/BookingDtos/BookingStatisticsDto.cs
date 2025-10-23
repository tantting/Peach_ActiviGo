namespace Peach_ActiviGo.Services.DTOs.BookingDtos
{
    public class BookingStatisticsDto
    {
        // Per-activity counts
        public Dictionary<string, int> TotalBookingsPerActivity { get; set; } = new();

        // Counts for current month/week
        public int TotalBookingsThisMonth { get; set; }
        public int TotalBookingsThisWeek { get; set; }

        public string MostPopularActivity { get; set; }
        public string TopCustomer { get; set; }
        public int CanceledBookings { get; set; }
        public int ActiveBookings { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}

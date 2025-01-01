using System;

namespace winform_app.Models
{
    public class OnlineBooking
    {
        public int BookingID { get; set; }
        public string CustomerID { get; set; }
        public string BranchID { get; set; }
        public int GuestCount { get; set; }
        public DateTime BookingDate { get; set; }
        public string Notes { get; set; }
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
        public string DeliveryType { get; set; }
        public string DeliveryAddress { get; set; }
        public float DeliveryFee { get; set; }
        public string Status { get; set; }

    }
}

using System;

namespace MyRentals.Api.Domain.Entities
{
    public class Rent : Expense
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public DateTime StartDate { get => _startDate.Date; set => _startDate = value; }

        public long StartHour { get; set; }

        public DateTime EndDate { get => _endDate.Date; set => _endDate = value; }

        public long EndHour { get; set; }

        public bool Paid { get; set; }

        public string RenterName { get; set; }
    }
}

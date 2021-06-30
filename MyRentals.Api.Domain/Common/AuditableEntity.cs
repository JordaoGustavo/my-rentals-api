using System;

namespace MyRentals.Api.Domain.Common
{
    public abstract class AuditableEntity
    {
        private DateTime _date;

        public DateTime Date { get => _date.Date; set => _date = value; }

        public TimeSpan InsertHour { get; set; }
    }
}

namespace MyRentals.Api.Domain.Entities
{
    public class Charge : Expense
    {
        public string CostType { get; set; }

        public bool Active { get; set; }

        public bool Fixed { get; set; }
    }
}

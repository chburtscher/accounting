using System;

namespace accounting.Model
{
    public class Entries
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? BookingDate { get; set; }
        public int BankAccount { get; set; }
        public int? CostType { get; set; }
        public decimal NetValue { get; set; }
        public decimal TaxValue { get; set; }
        public decimal GrossValue { get; set; }
    }
}
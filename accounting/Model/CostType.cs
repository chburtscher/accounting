namespace accounting.Model
{
    public class CostType
    {
        public int Id {get;set;}
        public int Number {get;set;}
        public string Name { get; set; }
        public TaxRate TaxRate  { get; set; }
        public bool Active { get; set; }
    }
}
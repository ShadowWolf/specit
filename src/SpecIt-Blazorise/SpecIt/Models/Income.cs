namespace SpecIt.Models
{
    public class Income
    {
        private const decimal TaxRate = 0.40m;
        
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool IsTaxable { get; set; }
        public int Order { get; set; }
        public decimal CalculatedValue => IsTaxable ? Value * TaxRate : Value;
    }
}
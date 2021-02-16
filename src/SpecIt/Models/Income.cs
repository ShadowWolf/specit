namespace SpecIt.Models
{
    public class Income
    {
        private const decimal TaxRate = 0.40m;
        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public bool IsTaxable { get; set; }

        public bool IsEnabled { get; set; } = true;
        
        public decimal CalculatedValue => IsEnabled ? (IsTaxable ? Value.GetValueOrDefault(0m) * (1 - TaxRate) : Value.GetValueOrDefault(0m)) : 0m;
    }
}
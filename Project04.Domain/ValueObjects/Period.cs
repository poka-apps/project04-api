namespace Project04.Domain.ValueObjects
{
    public record Period
    {
        public DateTime From { get; private set; }
        public DateTime? To { get; private set; }

        private Period()
        {
            From = DateTime.MinValue;
            To = null;
        }

        public Period(DateTime from, DateTime? to = null)
            : this()
        {
            if (to.HasValue)
            {
                to.Value.ValidateGreaterThan(from);
            }

            From = from;
            To = to;
        }   

        public override string ToString()
        {
            var result = $"From: {this.From:yyyy-MM-dd}";

            if (this.To.HasValue)
            {
                result += $", To: {this.To.Value:yyyy-MM-dd}";
            }

            return result;
        }
    }
}

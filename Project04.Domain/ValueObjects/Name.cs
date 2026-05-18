using Humanizer;

namespace Project04.Domain.ValueObjects
{
    public record Name
    {
        public string Value { get; private set; }

        private Name()
        {
            Value = null!;
        }

        public Name(string value)
        {
            value.ValidateHasValue();

            Value = value.Trim();
        }

        public override string ToString() => this.Value;

        public Name Humanize()
        {
            Value = this.Value.Humanize(LetterCasing.Sentence);

            return this;
        }
    }
}

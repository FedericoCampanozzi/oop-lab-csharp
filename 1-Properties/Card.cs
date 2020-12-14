namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        public string Name { get; private set; }
        public string Seed { get; private set; }
        public int Ordinal { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            this.Name = name;
            this.Ordinal = ordinal;
            this.Seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple)
            : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={this.Name}, Seed={this.Seed}, Ordinal={this.Ordinal})";
        }

        public override bool Equals(object obj)
        {
            return obj is Card card &&
                   Name == card.Name &&
                   Seed == card.Seed &&
                   Ordinal == card.Ordinal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Seed, Ordinal);
        }
    }
}

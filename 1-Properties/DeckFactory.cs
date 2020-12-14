namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        public string[] Seeds { get; set; }
        public string[] Names { get; set; }

        public int DeckSize
        {
            get
            {
                return this.Names.Length * this.Seeds.Length;
            }
        }

        public ISet<Card> Deck
        {
            get
            {
                if (this.Names == null || this.Seeds == null)
                {
                    throw new InvalidOperationException();
                }

                return new HashSet<Card>(Enumerable
                    .Range(0, this.Names.Length)
                    .SelectMany(i => Enumerable
                        .Repeat(i, this.Seeds.Length)
                        .Zip(
                            Enumerable.Range(0, this.Seeds.Length),
                            (n, s) => Tuple.Create(this.Names[n], this.Seeds[s], n)))
                    .Select(tuple => new Card(tuple))
                    .ToList());
            }
        }
    }
}

namespace Iterators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {
            const int len = 50;
            int?[] numbers = new int?[len];
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                if (rand.NextDouble() > 0.2)
                {
                    numbers[i] = rand.Next(len);
                }
            }

            Console.WriteLine("\nUsing C# methods\n");

            IDictionary<int, int> occurrences = numbers
                .Select(optN => {
                    Console.Write(optN.ToString() + ",");
                    return optN;
                })
                .Skip(1)
                .Take(len - 2)
                .Where(optN => optN.HasValue)
                .Select(optN => optN.Value)
                .Aggregate(new Dictionary<int, int>(), (d, n) => {
                    if (!d.ContainsKey(n))
                    {
                        d[n] = 1;
                    }
                    else
                    {
                        d[n]++;
                    }

                    return d;
                });

            Console.WriteLine();

            foreach (KeyValuePair<int, int> kv in occurrences)
            {
                Console.WriteLine(kv);
            }

            Console.WriteLine("\nUsing methods from Java8StreamOperations\n");

            IDictionary<int, int> occurrences2 = numbers
                .Map(optN =>
                {
                    Console.Write(optN.ToString() + ",");
                    return optN;
                })
                .SkipSome(1)
                .TakeSome(len - 2)
                .Filter(optN => optN.HasValue)
                .Map(optN => optN.Value)
                .Reduce(new Dictionary<int, int>(), (d, n) =>
                {
                    if (!d.ContainsKey(n))
                    {
                        d[n] = 1;
                    }
                    else
                    {
                        d[n]++;
                    }

                    return d;
                });

            Console.WriteLine();

            foreach (KeyValuePair<int, int> kv in occurrences2)
            {
                Console.WriteLine(kv);
            }

            Console.WriteLine("\nUsing methods from Java8StreamOperations v2\n");

            numbers.Map(optN =>
            {
                Console.Write(optN.ToString() + ",");
                return optN;
            })
                .SkipSome(1)
                .TakeSome(len - 2)
                .Filter(optN => { return optN.HasValue; })
                .Map(optN => optN.Value)
                .Reduce(new Dictionary<int, int>(), (d, n) =>
                {
                    if (!d.ContainsKey(n))
                    {
                        d[n] = 1;
                    }
                    else
                    {
                        d[n]++;
                    }

                    return d;
                })
                .ForEach(itm => Console.WriteLine(itm));
        }
    }
}

using System;
using System.Collections.Generic;

namespace PileOfBeans.Haystack
{
    public class Haystack
    {
        private const int PILE_SIZE_MIN = 2000000;
        private const int PILE_SIZE_MAX = 3000000;
        private const int COLOR_MIN = 0;
        private const int COLOR_MAX = 256;
        private const int LENGTH_MIN = 50;
        private const int LENGTH_MAX = 200;

        private readonly IList<Straw> _pile;
                
        public IList<Straw> Pile => _pile;

        public Haystack()
        {
            var generator = new Random(DateTime.Now.Millisecond);
            var size = generator.Next(PILE_SIZE_MIN, PILE_SIZE_MAX);

            _pile = new List<Straw>();

            // Build the pile...
            for (int i = 0; i < size; i++)
            {
                _pile.Add(
                    new Straw(
                        generator.Next(LENGTH_MIN, LENGTH_MAX) / (decimal)10,
                        generator.Next(COLOR_MIN, COLOR_MAX),
                        generator.Next(COLOR_MIN, COLOR_MAX),
                        generator.Next(COLOR_MIN, COLOR_MAX)
                    ));
            }
        }
    }
}

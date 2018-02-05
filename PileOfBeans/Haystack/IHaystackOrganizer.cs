
using System;

namespace PileOfBeans.Haystack
{
    public interface IHaystackOrganizer
    {
        /// <summary>
        /// Sorts the haystack pile into color groups.
        /// </summary>
        /// <param name="haystack">The haystack instance containing the pile to be sorted.</param>
        /// <returns>Result containing the sorted, ordered lists of unique straws from the haystack.</returns>
        SortByColorResult SortByColor(Haystack haystack);
        /// <summary>
        /// Return the time in which the Haystack was sorted.
        /// </summary>
        /// <returns>Result containing the time elapsed.</returns>
        TimeSpan GetExecutionTime();
    }

    public class IHaystackImplementor : IHaystackOrganizer
    {
        public TimeSpan GetExecutionTime()
        {
           return SortByColorResult.executionTime;
        }

        public SortByColorResult SortByColor(Haystack haystack)
        {
            return (new SortByColorResult(haystack));
        }
    }
}

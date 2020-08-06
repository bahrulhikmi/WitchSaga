using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace WitchSagaCore
{
    /// <summary>
    /// Killed Records for each year
    /// </summary>
    internal class KilledYearRecords
    {        
        private static ConcurrentDictionary<int, int> killedRecordCache = new ConcurrentDictionary<int, int>();

        /// <summary>
        /// Get number of villager killed based on the specified year
        /// </summary>        
        public static int Get(int year)
        {
            if (year < 0) return -1;
            if (year < 2) return year;

          return killedRecordCache.GetOrAdd(year, YearValueGenerator);
        }

        /// <summary>
        /// Calculate the Killed villager on the specified year based on the specified rule:
        /// On the 2nd year she kills 1 + 1 = 2 villagers
        /// On the 3rd year she kills 1 + 1 + 2 = 4 villagers
        /// On the 4th year she kills 1 + 1 + 2 + 3 = 7 villagers
        /// On the 5th year she kills 1 + 1 + 2 + 3 + 5 = 12 villagers
        /// </summary>
        private static int YearValueGenerator(int year)
        {
            return Get(year - 1) + Get(year - 2) + 1;
        }
    }
}

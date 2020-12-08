using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day3
    {
        public string[] PrepareData(string input)
        {
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
        }
        public long CountTreesByPattern(IList<string> lines, IEnumerable<int[]> patterns)
        {
            var results = patterns.Select(p => CountTrees(lines, p[0], p[1]));

            return results.Aggregate<int, long>(1, (current, n) => current * n);
        }
        public int CountTrees(IList<string> lines, int patternRight, int patternDown)
        {
            var lineId = 0;
            var columnId = 0;

            var nbTrees = 0;

            
            var line = lines[0].ToCharArray();

            while (lineId < lines.Count)
            {
                for (var i = 0; i < patternRight; i++)
                {
                    columnId++;
                        
                    if (columnId >= line.Length) columnId = 0;
                }

                for(var r = 0; r < patternDown; r++)
                {
                    lineId++;

                    if (lineId >= lines.Count) break;

                    line = lines[lineId].ToCharArray();
                }

                if (lineId >= lines.Count) break;
                
                if (line[columnId] == '#') nbTrees++;
            }

            return nbTrees;
        }
    }
}

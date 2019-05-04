using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnixCommands
{
    public class Cmp
    {
        private readonly string version = "1.0";

        private struct DifferenceInfo
        {
            public int line;
            public int sequence;
            public byte first;
            public byte second;
        }

        private List<DifferenceInfo> Compare(out int output, bool stopIfFound, 
            string pathToFile1, string pathToFile2, int skip1, int skip2, int limit=-1)
        {
            
            List<DifferenceInfo> result = new List<DifferenceInfo>();
            output = -1;
            byte[] file1, file2;
            int lineCounter = 1;

            try
            {
                file1 = File.ReadAllBytes(pathToFile1);
                file2 = File.ReadAllBytes(pathToFile2);

                int n;

                if (limit < 0) n = file1.Length;
                else n = limit;

                for (int i = skip1; i < n; i++)
                {
                    if (file1[i] == 10) lineCounter++;

                    if (file1[i] != file2[i - skip1 + skip2])
                    {
                        result.Add(new DifferenceInfo {
                            line = lineCounter, sequence = i, first = file1[i], second = file2[i - skip1 + skip2] });

                        if (stopIfFound) break;
                    }
                }
            }
            catch (Exception) 
            {
                result.Add(new DifferenceInfo());
                output = 2;
            }

            if (result.Count == 0 && output != 2)
            {
                result.Add(new DifferenceInfo());
                output = 0;
            }
            else if (result.Count > 0 && output != 2) output = 1;

            return result;
        }

        //-b, --print-bytes      	print differing bytes
        public int PrintBytes(string pathToFile1, string pathToFile2)
        {
            /*
            DifferenceInfo diff = Compare(out int output, true, pathToFile1, pathToFile2, 0, 0, -1)[0];

            if (output == 1)
            {
                Console.WriteLine(string.Format(
                    "{0} {1} differ: byte {2}, line {3} is {4} {5}",
                    pathToFile1, pathToFile2, diff.sequence, diff.line, diff.second, Convert.ToChar(diff.second)
                    ));
            }
            return output;
            */

            return BytesLimit(pathToFile1, pathToFile2, -1);
        }

        //-i, --ignore-initial=SKIP skip first SKIP bytes of both inputs
        //-i, --ignore-initial=SKIP1:SKIP2 skip first SKIP1 bytes of FILE1 and first SKIP2 bytes of FILE2
        public int IgnoreInitialBytes(string pathToFile1, string pathToFile2, int skip1, int skip2)
        {
            DifferenceInfo diff = Compare(out int output, true, pathToFile1, pathToFile2, skip1, skip2, -1)[0];

            if (output == 1)
            {
                Console.WriteLine(string.Format(
                    "{0} {1} differ: byte {2}, line {3} is {4} {5}",
                    pathToFile1, pathToFile2, diff.sequence, diff.line, diff.second, Convert.ToChar(diff.second)
                    ));
            }
            return output;
        }

        //-l, --verbose output byte numbers and differing byte values
        public int Verbose(string pathToFile1, string pathToFile2)
        {
            List<DifferenceInfo> diffs = Compare(out int output, false, pathToFile1, pathToFile2, 0, 0, -1);

            if (output == 1)
            {
                foreach (DifferenceInfo diff in diffs)
                {
                    Console.WriteLine(string.Format(
                        "{0}  {1}  {2}",
                        diff.sequence, diff.first, diff.second
                        ));
                }
            }

            return output;
        }

        //-n, --bytes=LIMIT compare at most LIMIT bytes
        public int BytesLimit(string pathToFile1, string pathToFile2, int limit)
        {
            DifferenceInfo diff = Compare(out int output, true, pathToFile1, pathToFile2, 0, 0, limit)[0];

            if (output == 1)
            {
                Console.WriteLine(string.Format(
                    "{0} {1} differ: byte {2}, line {3} is {4} {5}",
                    pathToFile1, pathToFile2, diff.sequence, diff.line, diff.second, Convert.ToChar(diff.second)
                    ));
            }
            return output;
        }

        //-s, --quiet, --silent suppress all normal output
        public int Silent(string pathToFile1, string pathToFile2)
        {
            Compare(out int output, true, pathToFile1, pathToFile2, 0, 0, -1);

            return output;
        }

        //-v, --version output version information and exit
        public string Version()
        {
            return version;
        }

        //--help display help and exit
        public string Help()
        {
            return File.ReadAllText(@"..\..\Help.txt");
        }
    }
}

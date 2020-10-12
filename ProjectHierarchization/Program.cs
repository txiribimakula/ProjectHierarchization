using System;
using System.IO;

namespace ProjectHierarchization
{
    class Program
    {
        static void Main(string[] args) {
            string solutionFilePath = args[0];

            string[] solutionFileLines = File.ReadAllLines(solutionFilePath);

            foreach (var line in solutionFileLines) {
                Console.WriteLine(line);
            }
        }
    }
}

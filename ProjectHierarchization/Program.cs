using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectHierarchization
{
    class Program
    {
        static void Main(string[] args) {
            string solutionFilePath = args[0];

            string[] solutionFileLines = File.ReadAllLines(solutionFilePath);

            Regex regularExpression = new Regex("Project\\(\"\\{(?<guid>.*)\\}\"\\)");

            foreach (var line in solutionFileLines) {
                Match match = regularExpression.Match(line);
                if(match.Success) {
                    Console.WriteLine("PROJECT");
                    Console.WriteLine(match.Groups["guid"].Value);
                }
            }
        }
    }
}

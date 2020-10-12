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
            string solutionFileText = File.ReadAllText(solutionFilePath);

            Regex regularExpression = new Regex("Project\\(\"\\{(.*)\\}\"\\)");

            foreach (var line in solutionFileLines) {
                Match match = regularExpression.Match(line);
                if(match.Success) {
                    Console.WriteLine("PROJECT");
                    Console.WriteLine(match.Groups[0].Value);
                }
            }
        }
    }
}

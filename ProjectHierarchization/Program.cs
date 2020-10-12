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

            Regex projectInfoRegEx = new Regex("Project\\(\"\\{.*\\}\"\\) = \"(?<name>.*)\", \"(?<path>.*)\", \".*\\}\"");

            foreach (var line in solutionFileLines) {
                Match projectMatch = projectInfoRegEx.Match(line);
                if(projectMatch.Success) {
                    Console.WriteLine("PROJECT");
                    Console.WriteLine(projectMatch.Groups["name"].Value);
                    Console.WriteLine(projectMatch.Groups["path"].Value);
                }
            }
        }
    }
}

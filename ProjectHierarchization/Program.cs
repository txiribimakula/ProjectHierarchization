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
                if(regularExpression.Match(line).Success) {
                    Console.WriteLine("PROJECT");
                    Console.WriteLine(line);
                }
            }
        }
    }
}

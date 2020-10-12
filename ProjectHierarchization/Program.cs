using ProjectHierarchization.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectHierarchization
{
    class Program
    {
        static void Main(string[] args) {
            string solutionFilePath = args[0];

            Solution solution = new Solution();

            string solutionFolderPath = Path.GetDirectoryName(solutionFilePath);

            string[] solutionFileLines = File.ReadAllLines(solutionFilePath);

            Regex projectInfoRegEx = new Regex("Project\\(\"\\{.*\\}\"\\) = \"(?<name>.*)\", \"(?<path>.*)\", \".*\\}\"");

            foreach (var line in solutionFileLines) {
                Match projectMatch = projectInfoRegEx.Match(line);
                if(projectMatch.Success) {
                    string projectName = projectMatch.Groups["name"].Value;
                    string projectPath = projectMatch.Groups["path"].Value;
                    string projectFullPath = solutionFolderPath + "\\" + projectPath;
                    Console.WriteLine(projectFullPath);
                }
            }
        }
    }
}

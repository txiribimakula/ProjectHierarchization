using ProjectHierarchization.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectHierarchization
{
    class Program
    {
        static void Main(string[] args) {
            string solutionFilePath = args[0];

            Solution solution = new Solution(Path.GetFileName(solutionFilePath), Path.GetFileNameWithoutExtension(solutionFilePath));

            string solutionFolderPath = Path.GetDirectoryName(solutionFilePath);
            string[] solutionFileLines = File.ReadAllLines(solutionFilePath);

            Regex projectInfoRegEx = new Regex("Project\\(\"\\{.*\\}\"\\) = \"(?<name>.*)\", \"(?<path>.*)\", \".*\\}\"");

            foreach (var line in solutionFileLines) {
                Match projectMatch = projectInfoRegEx.Match(line);
                if(projectMatch.Success) {
                    Project project = new Project(projectMatch.Groups["name"].Value, projectMatch.Groups["name"].Value);
                    
                    string projectFullPath = solutionFolderPath + "\\" + projectMatch.Groups["path"].Value;
                }
            }
        }
    }
}

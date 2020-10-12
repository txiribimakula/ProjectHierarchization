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

            Solution solution = new Solution();
            solution.Id = Path.GetFileName(solutionFilePath);
            solution.Name = Path.GetFileNameWithoutExtension(solutionFilePath);
            solution.Projects = new List<Project>();

            string solutionFolderPath = Path.GetDirectoryName(solutionFilePath);
            string[] solutionFileLines = File.ReadAllLines(solutionFilePath);

            Regex projectInfoRegEx = new Regex("Project\\(\"\\{.*\\}\"\\) = \"(?<name>.*)\", \"(?<path>.*)\", \".*\\}\"");

            foreach (var line in solutionFileLines) {
                Match projectMatch = projectInfoRegEx.Match(line);
                if(projectMatch.Success) {
                    Project project = new Project();
                    project.Id = projectMatch.Groups["name"].Value;
                    project.Name = project.Id;
                    project.Dependencies = new List<string>();
                    
                    string projectFullPath = solutionFolderPath + "\\" + projectMatch.Groups["path"].Value;
                }
            }
        }
    }
}

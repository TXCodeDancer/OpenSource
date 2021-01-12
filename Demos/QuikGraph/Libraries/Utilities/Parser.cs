using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class Parser
    {
        private static Regex CSharpCommentRegex =
        new Regex(@"(\/\/.*?(\r?\n|$))|(\/\*(?:[\s\S]*?)\*\/)|(""(?:\\[^\n]|[^""\n])*"")|(@(?:""[^""]*"")+)", RegexOptions.Compiled);

        public static List<string[]> Parse(List<string> lines)
        {
            var noComments = UnCommentLines(lines);
            var cleanLines = CleanLines(noComments);
            var parsedLines = ParseLine(cleanLines);

            return parsedLines;
        }

        public static List<string> RemoveComments(List<string> lines)
        {
            var noComments = UnCommentLines(lines);
            var cleanLines = CleanLines(noComments);

            return cleanLines;
        }

        public static List<string> CleanLines(List<string> lines)
        {
            List<string> output = new List<string>();
            foreach (string line in lines)
            {
                if (!String.IsNullOrWhiteSpace(line))
                {
                    var trimmed = line.Trim();
                    output.Add(trimmed);
                }
            }

            return output;
        }

        public static List<string> UnCommentLines(List<string> lines)
        {
            bool inBlockComment = false;
            List<string> output = new List<string>();
            foreach (string line in lines)
            {
                // Code from https://dotnetfiddle.net/J98Ior
                string noComments = CSharpCommentRegex.Replace(line, me =>
                {
                    if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                    {
                        return me.Groups[2].Value;
                    }
                    return me.Value;
                });

                if (noComments.Contains(@"/*"))
                {
                    var commentIdx = noComments.IndexOf(@"/*");
                    noComments = noComments.Substring(0, commentIdx);
                    inBlockComment = true;
                }
                else if (inBlockComment)
                {
                    if (noComments.Contains(@"*/"))
                    {
                        var commentIdx = noComments.IndexOf(@"*/");
                        noComments = noComments.Substring(commentIdx + 2);
                        inBlockComment = false;
                    }
                    else
                    {
                        noComments = "";
                    }
                }

                output.Add(noComments);
            }

            return output;
        }

        private static List<string[]> ParseLine(List<string> lines)
        {
            List<string[]> output = new List<string[]>();
            foreach (var line in lines)
            {
                output.Add(Regex.Split(line, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"));
            }
            return output;
        }
    }
}

using Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Theory]
        [MemberData(nameof(GetInputFiles))]
        public void Test0(string inputFile)
        {
            var resultfile = $"{inputFile}.r";
            var answerfile = $"{inputFile}.a";
            List<string> inputs = File.ReadAllLines(inputFile).ToList();
            var nodes = inputs[0].Split(' ').ToList(); // First line is a space delimited list of node type and names: int 1 2 3 or string a b c
            var nodeType = nodes[0];
            nodes.RemoveAt(0);

            // Remove line of node name
            inputs.RemoveAt(0);
            List<List<string>> edges = new List<List<string>>();
            foreach (var e in inputs)
            {
                edges.Add(e.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  1 2 or a b 5
            }

            Program.GraphVisualizerHelper(nodes, nodeType, edges, inputFile);

            //             List<string> lines = new List<string>();
            //             lines.Add(actual.ToString());
            //             File.WriteAllLines(resultfile, lines);
            //
            //             List<string> answers = File.ReadAllLines(answerfile).ToList();
            //             l = 0;
            //             tokens = answers[l++].Split(' ');
            //             var expected = long.Parse(tokens[0]);
            //             Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetInputFiles =>
            new List<object[]>
            {
                new object[] { new string(@"D:\HackerSpace\GitHub\Public\Examples\QuikGraph\Visualize\Tests\Cases\02") },
            };
    }
}
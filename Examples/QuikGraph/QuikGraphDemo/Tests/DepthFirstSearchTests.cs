using Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    public class DepthFirstSearchTests
    {
        [Theory]
        [MemberData(nameof(GetInputFiles))]
        public void Test0(string inputFile)
        {
            var expectedfile = $"{inputFile}.a";
            var resultsfile = $"{inputFile}.r";
            List<string> inputs = File.ReadAllLines(inputFile).ToList();
            var nodes = inputs[0].Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"

            // Remove line of node name
            inputs.RemoveAt(0);
            List<List<string>> edges = new List<List<string>>();
            foreach (var e in inputs)
            {
                edges.Add(e.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            var actual = Program.DepthFirstSearchHelper(nodes, edges, inputFile);
            File.WriteAllLines(resultsfile, actual);

            // Verify results
            List<string> expected = File.ReadAllLines(expectedfile).ToList();
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        public static IEnumerable<object[]> GetInputFiles =>
            new List<object[]>
            {
                new object[] { new string(@"..\..\..\Cases\DFS\01") },
                new object[] { new string(@"..\..\..\Cases\DFS\02") },
            };
    }
}
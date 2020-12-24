//
// Tests: Test method to demonstrate usage of the Visualize.Visualizer library.
//

using Main;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Tests
{
    public class VisualizerTests
    {
        [Theory]
        [MemberData(nameof(GetInputFiles))]
        public void Test0(string inputFile)
        {
            var actualfile = $"{inputFile}.dot";
            var expectedfile = $"{inputFile}.a";
            List<string> inputs = File.ReadAllLines(inputFile).ToList();
            var nodes = inputs[0].Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"

            // Remove line of node name
            inputs.RemoveAt(0);
            List<List<string>> edges = new List<List<string>>();
            foreach (var e in inputs)
            {
                edges.Add(e.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            Program.GraphVisualizerHelper(nodes, edges, inputFile);

            // Verify results of dot file
            List<string> expected = File.ReadAllLines(expectedfile).ToList();
            List<string> actual = File.ReadAllLines(actualfile).ToList();
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        public static IEnumerable<object[]> GetInputFiles =>
            new List<object[]>
            {
                new object[] { new string(@"..\..\..\Cases\Visualizer\01") },
                new object[] { new string(@"..\..\..\Cases\Visualizer\02") },
            };
    }
}
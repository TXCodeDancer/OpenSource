using Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.AlgorithmsTests.MaxFlowTests
{
    public class EdmondsKarpMaxFlowTests
    {
        [Theory]
        [MemberData(nameof(GetInputFiles))]
        public void Test0(string inputFile)
        {
            string directory = Path.GetDirectoryName(inputFile);
            string file = Path.GetFileNameWithoutExtension(inputFile);
            var outputFile = @$"{directory}\MaxFlow\EdmondsKarp\{file}";
            var expectedfile = @$"{outputFile}.a";
            var resultsfile = $"{outputFile}.r";

            List<string> inputs = File.ReadAllLines(inputFile).ToList();
            var nodes = inputs[0].Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"

            // Remove line of node name
            inputs.RemoveAt(0);
            List<List<string>> edges = new List<List<string>>();
            foreach (var e in inputs)
            {
                edges.Add(e.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            var source = nodes[0];
            var sink = nodes[nodes.Count - 1];
            List<string> actual = MaximumFlowHelper.EdmondsKarpMaxFlow(nodes, edges, source, sink);
            File.WriteAllLines(resultsfile, actual);

            // Verify results
            List<string> expected = File.ReadAllLines(expectedfile).ToList();
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        [Theory]
        [MemberData(nameof(GetInputFiles))]
        public void Test1(string inputFile)
        {
            string directory = Path.GetDirectoryName(inputFile);
            string file = Path.GetFileNameWithoutExtension(inputFile);
            var outputFile = @$"{directory}\MaxFlow\EdmondsKarpPredecessors\{file}";
            var expectedfile = @$"{outputFile}.a";
            var resultsfile = $"{outputFile}.r";

            List<string> inputs = File.ReadAllLines(inputFile).ToList();
            var nodes = inputs[0].Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"

            // Remove line of node name
            inputs.RemoveAt(0);
            List<List<string>> edges = new List<List<string>>();
            foreach (var e in inputs)
            {
                edges.Add(e.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            var source = nodes[0];
            var sink = nodes[nodes.Count - 1];
            List<string> actual = MaximumFlowHelper.EdmondsKarpMaxFlowPredecessors(nodes, edges, source, sink);
            File.WriteAllLines(resultsfile, actual);

            // Verify results
            List<string> expected = File.ReadAllLines(expectedfile).ToList();
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }

        [Theory]
        [MemberData(nameof(GetInputFiles))]
        public void Test2(string inputFile)
        {
            string directory = Path.GetDirectoryName(inputFile);
            string file = Path.GetFileNameWithoutExtension(inputFile);
            var outputFile = @$"{directory}\MaxFlow\EdmondsKarpResidualCapacities\{file}";
            var expectedfile = @$"{outputFile}.a";
            var resultsfile = $"{outputFile}.r";

            List<string> inputs = File.ReadAllLines(inputFile).ToList();
            var nodes = inputs[0].Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"

            // Remove line of node name
            inputs.RemoveAt(0);
            List<List<string>> edges = new List<List<string>>();
            foreach (var e in inputs)
            {
                edges.Add(e.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            var source = nodes[0];
            var sink = nodes[nodes.Count - 1];
            List<string> actual = MaximumFlowHelper.EdmondsKarpMaxFlowResidualCapacities(nodes, edges, source, sink);
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
                // Only tagged graphs are valid
                new object[] { new string(@"..\..\..\Cases\02") },
                new object[] { new string(@"..\..\..\Cases\06") },
                new object[] { new string(@"..\..\..\Cases\07") },
            };
    }
}
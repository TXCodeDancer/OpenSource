using Main;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Tests.AlgorithmsTests.Search
{
    public class BestFirstFrontierSearchTests
    {
        [Theory]
        [MemberData(nameof(GetInputFiles))]
        public void Test0(string inputFile)
        {
            string directory = Path.GetDirectoryName(inputFile);
            string file = Path.GetFileNameWithoutExtension(inputFile);
            var outputFile = @$"{directory}\Search\BestFirstFrontier\{file}";
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

            var actual = SearchHelper.BestFirstFrontierSearchVertexPredecessor(nodes, edges, nodes[0], nodes[nodes.Count - 1]);
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
            var outputFile = @$"{directory}\Search\BestFirstFrontier\Seek\{file}";
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

            var actual = SearchHelper.BestFirstFrontierSearchSeekTarget(nodes, edges, nodes[0], nodes[nodes.Count - 1]);
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
                new object[] { new string(@"..\..\..\Cases\01") },
                new object[] { new string(@"..\..\..\Cases\02") },
                new object[] { new string(@"..\..\..\Cases\03") },
                new object[] { new string(@"..\..\..\Cases\04") },
                new object[] { new string(@"..\..\..\Cases\05") },
                new object[] { new string(@"..\..\..\Cases\06") },
                new object[] { new string(@"..\..\..\Cases\08") },
            };
    }
}
using QuikGraph;
using QuikGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.ShortestPath
{
    public static class FloydWarshallShortestPath
    {
        public static List<KeyValuePair<(int, int), double>> Get(AdjacencyGraph<int, Edge<int>> graph, int root)
        {
            Func<Edge<int>, double> Weights = e => 1.0;

            var algorithm = new FloydWarshallAllShortestPathAlgorithm<int, Edge<int>>(graph, Weights);

            algorithm.Compute();
            var results = new List<KeyValuePair<(int, int), double>>();
            foreach (var v in graph.Vertices)
            {
                double distance = double.PositiveInfinity;
                algorithm.TryGetDistance(root, v, out distance);
                results.Add(new KeyValuePair<(int, int), double>((root, v), distance));
            }
            return results;
        }

        public static List<KeyValuePair<(string, string), double>> Get(AdjacencyGraph<string, TaggedEdge<string, string>> graph, string root)
        {
            Func<TaggedEdge<string, string>, double> Weights = e => double.Parse(e.Tag);

            var algorithm = new FloydWarshallAllShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, Weights);

            algorithm.Compute();
            var results = new List<KeyValuePair<(string, string), double>>();
            foreach (var v in graph.Vertices)
            {
                double distance = double.PositiveInfinity;
                algorithm.TryGetDistance(root, v, out distance);
                results.Add(new KeyValuePair<(string, string), double>((root, v), distance));
            }
            return results;
        }
    }
}
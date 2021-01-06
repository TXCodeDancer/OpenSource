using QuikGraph;
using QuikGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;

namespace Algorithms.ShortestPath
{
    public static class AStarShortestPath
    {
        public static IDictionary<int, double> Get(AdjacencyGraph<int, Edge<int>> graph, int root)
        {
            Func<int, double> Heuristic = v => 1.0;
            Func<Edge<int>, double> Weights = e => 1.0;

            var algorithm = new AStarShortestPathAlgorithm<int, Edge<int>>(graph, Weights, Heuristic);

            algorithm.Compute(root);
            var foo = algorithm.VisitedGraph;
            return algorithm.Distances;
        }

        public static IDictionary<string, double> Get(AdjacencyGraph<string, TaggedEdge<string, string>> graph, string root)
        {
            Func<string, double> Heuristic = v => 1.0;
            Func<TaggedEdge<string, string>, double> Weights = e => double.Parse(e.Tag);

            var algorithm = new AStarShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, Weights, Heuristic);

            algorithm.Compute(root);
            var foo = algorithm.VisitedGraph;
            return algorithm.Distances;
        }
    }
}
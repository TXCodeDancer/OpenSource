using QuikGraph;
using QuikGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;

namespace Algorithms.ShortestPath
{
    public static class BellmanFordShortestPath
    {
        public static IDictionary<int, double> Get(AdjacencyGraph<int, Edge<int>> graph)
        {
            Func<Edge<int>, double> Weights = e => 1.0;

            var algorithm = new BellmanFordShortestPathAlgorithm<int, Edge<int>>(graph, Weights);

            algorithm.Compute();
            var foo = algorithm.VisitedGraph;
            return algorithm.Distances;
        }

        public static IDictionary<string, double> Get(AdjacencyGraph<string, TaggedEdge<string, string>> graph)
        {
            Func<TaggedEdge<string, string>, double> Weights = e => double.Parse(e.Tag);

            var algorithm = new BellmanFordShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, Weights);

            algorithm.Compute();
            var foo = algorithm.VisitedGraph;
            return algorithm.Distances;
        }
    }
}
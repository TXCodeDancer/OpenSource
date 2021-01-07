using QuikGraph;
using QuikGraph.Algorithms;
using QuikGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;

namespace Algorithms.ShortestPath
{
    public static class DirectedAcyclicGraphShortestPath
    {
        public static (bool, IDictionary<int, double>) Get(AdjacencyGraph<int, Edge<int>> graph, int root)
        {
            if (!graph.IsDirectedAcyclicGraph())
                return (false, new Dictionary<int, double>());

            Func<Edge<int>, double> Weights = e => 1.0;
            var algorithm = new DagShortestPathAlgorithm<int, Edge<int>>(graph, Weights);

            algorithm.Compute(root);
            return (true, algorithm.Distances);
        }

        public static (bool, IDictionary<string, double>) Get(AdjacencyGraph<string, TaggedEdge<string, string>> graph, string root)
        {
            if (!graph.IsDirectedAcyclicGraph())
                return (false, new Dictionary<string, double>());

            Func<TaggedEdge<string, string>, double> Weights = e => double.Parse(e.Tag);
            var algorithm = new DagShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, Weights);

            algorithm.Compute(root);
            return (true, algorithm.Distances);
        }
    }
}
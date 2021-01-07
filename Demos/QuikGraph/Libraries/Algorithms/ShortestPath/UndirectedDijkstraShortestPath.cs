using QuikGraph;
using QuikGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.ShortestPath
{
    public class UndirectedDijkstraShortestPath
    {
        public static IDictionary<int, double> Get(IUndirectedGraph<int, Edge<int>> graph, int root)
        {
            Func<Edge<int>, double> Weights = e => 1.0;

            var algorithm = new UndirectedDijkstraShortestPathAlgorithm<int, Edge<int>>(graph, Weights);

            algorithm.Compute(root);
            return algorithm.Distances;
        }

        public static IDictionary<string, double> Get(IUndirectedGraph<string, TaggedEdge<string, string>> graph, string root)
        {
            Func<TaggedEdge<string, string>, double> Weights = e => double.Parse(e.Tag);

            var algorithm = new UndirectedDijkstraShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, Weights);

            algorithm.Compute(root);
            return algorithm.Distances;
        }
    }
}
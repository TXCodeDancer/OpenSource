using QuikGraph;
using QuikGraph.Algorithms.ConnectedComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.ConnectedComponents
{
    public static class StronglyConnectedComponents
    {
        public static IDictionary<int, int> Get(AdjacencyGraph<int, Edge<int>> g)
        {
            var algorithm = new StronglyConnectedComponentsAlgorithm<int, Edge<int>>(g);
            algorithm.Compute();
            return algorithm.Components;
        }

        public static IDictionary<string, int> Get(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var algorithm = new StronglyConnectedComponentsAlgorithm<string, TaggedEdge<string, string>>(g);
            algorithm.Compute();
            return algorithm.Components;
        }

        public static BidirectionalGraph<int, Edge<int>>[] GetGraphs(AdjacencyGraph<int, Edge<int>> g)
        {
            var algorithm = new StronglyConnectedComponentsAlgorithm<int, Edge<int>>(g);
            algorithm.Compute();
            return algorithm.Graphs;
        }

        public static BidirectionalGraph<string, TaggedEdge<string, string>>[] GetGraphs(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var algorithm = new StronglyConnectedComponentsAlgorithm<string, TaggedEdge<string, string>>(g);
            algorithm.Compute();
            return algorithm.Graphs;
        }
    }
}
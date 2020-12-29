using QuikGraph;
using QuikGraph.Algorithms.ConnectedComponents;
using System.Collections.Generic;

namespace Algorithms.ConnectedComponents
{
    public static class IncrementalConnectedComponents
    {
        public static KeyValuePair<int, IDictionary<int, int>> Get(UndirectedGraph<int, Edge<int>> g)
        {
            var algorithm = new IncrementalConnectedComponentsAlgorithm<int, Edge<int>>(g);
            algorithm.Compute();
            return algorithm.GetComponents();
        }

        public static KeyValuePair<int, IDictionary<string, int>> Get(UndirectedGraph<string, TaggedEdge<string, string>> g)
        {
            var algorithm = new IncrementalConnectedComponentsAlgorithm<string, TaggedEdge<string, string>>(g);
            algorithm.Compute();
            return algorithm.GetComponents();
        }
    }
}
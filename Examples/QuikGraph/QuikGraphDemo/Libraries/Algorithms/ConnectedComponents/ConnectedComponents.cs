using QuikGraph;
using QuikGraph.Algorithms.ConnectedComponents;
using System.Collections.Generic;

namespace Algorithms.ConnectedComponents
{
    public static class ConnectedComponents
    {
        public static IDictionary<int, int> Get(UndirectedGraph<int, Edge<int>> g)
        {
            var algorithm = new ConnectedComponentsAlgorithm<int, Edge<int>>(g);
            algorithm.Compute();
            return algorithm.Components;
        }

        public static IDictionary<string, int> Get(UndirectedGraph<string, TaggedEdge<string, string>> g)
        {
            var algorithm = new ConnectedComponentsAlgorithm<string, TaggedEdge<string, string>>(g);
            algorithm.Compute();
            return algorithm.Components;
        }
    }
}
using QuikGraph;
using QuikGraph.Algorithms.VertexColoring;
using System.Collections.Generic;

namespace Algorithms.VertexColoring
{
    public static class VertexColoring
    {
        public static IDictionary<int, int?> Get(UndirectedGraph<int, Edge<int>> g)
        {
            var algorithm = new VertexColoringAlgorithm<int, Edge<int>>(g);
            algorithm.Compute();
            return algorithm.Colors;
        }

        public static IDictionary<string, int?> Get(UndirectedGraph<string, TaggedEdge<string, string>> g)
        {
            var algorithm = new VertexColoringAlgorithm<string, TaggedEdge<string, string>>(g);
            algorithm.Compute();
            return algorithm.Colors;
        }
    }
}

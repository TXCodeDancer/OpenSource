using QuikGraph;
using QuikGraph.Algorithms.VertexCover;
using QuikGraph.Collections;
using System;

namespace Algorithms.VertexCover
{
    public static class VertexCover
    {
        public static VertexList<int> Get(UndirectedGraph<int, Edge<int>> g, int seed = 123456) // Seeding with 123456 for testing. Seeding with 456789, etc. may provide different CoverSet count
        {
            var algorithm = new MinimumVertexCoverApproximationAlgorithm<int, Edge<int>>(g, new Random(seed));
            algorithm.Compute();
            return algorithm.CoverSet;
        }

        public static VertexList<string> Get(UndirectedGraph<string, TaggedEdge<string, string>> g, int seed = 123456) // Seeding with 123456 for testing. Seeding with 456789, etc. may provide different CoverSet count
        {
            var algorithm = new MinimumVertexCoverApproximationAlgorithm<string, TaggedEdge<string, string>>(g, new Random(seed));
            algorithm.Compute();
            return algorithm.CoverSet;
        }
    }
}

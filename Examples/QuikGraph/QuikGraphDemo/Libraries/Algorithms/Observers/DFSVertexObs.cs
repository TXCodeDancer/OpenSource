using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms
{
    public static class DFSVertexObs
    {
        public static IEnumerable<int> Get(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new VertexRecorderObserver<int>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Vertices;
            }
        }

        public static IEnumerable<string> Get(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new VertexRecorderObserver<string>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Vertices;
            }
        }
    }
}
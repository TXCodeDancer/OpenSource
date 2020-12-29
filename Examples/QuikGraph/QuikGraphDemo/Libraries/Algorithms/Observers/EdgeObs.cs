using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms
{
    public static class EdgeObs
    {
        public static IEnumerable<Edge<int>> Get(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new EdgeRecorderObserver<int, Edge<int>>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Edges;
            }
        }

        public static IEnumerable<TaggedEdge<string, string>> Get(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new EdgeRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Edges;
            }
        }
    }
}
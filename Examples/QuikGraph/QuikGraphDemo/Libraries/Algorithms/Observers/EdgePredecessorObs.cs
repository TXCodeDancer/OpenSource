using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms
{
    public static class EdgePredecessorObs
    {
        public static IDictionary<Edge<int>, Edge<int>> Get(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new EdgePredecessorRecorderObserver<int, Edge<int>>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.EdgesPredecessors;
            }
        }

        public static IDictionary<TaggedEdge<string, string>, TaggedEdge<string, string>> Get(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new EdgePredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.EdgesPredecessors;
            }
        }
    }
}
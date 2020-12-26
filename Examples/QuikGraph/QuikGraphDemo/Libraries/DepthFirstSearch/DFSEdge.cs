using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms
{
    public static class DFSEdge
    {
        public static IEnumerable<Edge<int>> Recorder(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new EdgeRecorderObserver<int, Edge<int>>();

            IEnumerable<Edge<int>> traversedEdges;
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                traversedEdges = recorder.Edges;
            }
            return traversedEdges;
        }

        public static IEnumerable<TaggedEdge<string, string>> Recorder(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new EdgeRecorderObserver<string, TaggedEdge<string, string>>();
            IEnumerable<TaggedEdge<string, string>> traversedEdges;
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                traversedEdges = recorder.Edges;
            }
            return traversedEdges;
        }
    }
}
using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms
{
    public static class DFSEdgePredecessorObs
    {
        public static List<ICollection<Edge<int>>> GetAllPaths(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new EdgePredecessorRecorderObserver<int, Edge<int>>();

            List<ICollection<Edge<int>>> results = new List<ICollection<Edge<int>>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                var paths = recorder.AllMergedPaths();
                foreach (var p in paths)
                {
                    results.Add(p);
                }
            }
            return results;
        }

        public static List<ICollection<TaggedEdge<string, string>>> GetAllPaths(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new EdgePredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            List<ICollection<TaggedEdge<string, string>>> results = new List<ICollection<TaggedEdge<string, string>>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                var paths = recorder.AllMergedPaths();
                foreach (var p in paths)
                {
                    results.Add(p);
                }
            }
            return results;
        }
    }
}
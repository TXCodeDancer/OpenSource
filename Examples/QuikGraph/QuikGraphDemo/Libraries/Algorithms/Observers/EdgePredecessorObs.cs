using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms.Observers
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

        public static List<IEnumerable<Edge<int>>> GetAllPaths(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new EdgePredecessorRecorderObserver<int, Edge<int>>();

            List<IEnumerable<Edge<int>>> results = new List<IEnumerable<Edge<int>>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                var paths = recorder.AllPaths();
                foreach (var p in paths)
                {
                    results.Add(p);
                }
            }
            return results;
        }

        public static List<IEnumerable<TaggedEdge<string, string>>> GetAllPaths(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new EdgePredecessorRecorderObserver<string, TaggedEdge<string, string>>();

            List<IEnumerable<TaggedEdge<string, string>>> results = new List<IEnumerable<TaggedEdge<string, string>>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                var paths = recorder.AllPaths();
                foreach (var p in paths)
                {
                    results.Add(p);
                }
            }
            return results;
        }
    }
}
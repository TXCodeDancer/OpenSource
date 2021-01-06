using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms.Observers
{
    public class VertexPredecessorObs
    {
        public static IDictionary<int, Edge<int>> Get(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new VertexPredecessorRecorderObserver<int, Edge<int>>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.VerticesPredecessors;
            }
        }

        public static IDictionary<string, TaggedEdge<string, string>> Get(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new VertexPredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.VerticesPredecessors;
            }
        }

        public static List<IEnumerable<Edge<int>>> GetPaths(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new VertexPredecessorPathRecorderObserver<int, Edge<int>>();

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

        public static IList<IEnumerable<TaggedEdge<string, string>>> GetPaths(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new DepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new VertexPredecessorPathRecorderObserver<string, TaggedEdge<string, string>>();

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
using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms
{
    public class DFSUndirectedVertexPredecessorObs
    {
        public static IDictionary<int, Edge<int>> Get(UndirectedGraph<int, Edge<int>> g)
        {
            var dfs = new UndirectedDepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new UndirectedVertexPredecessorRecorderObserver<int, Edge<int>>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.VerticesPredecessors;
            }
        }

        public static IDictionary<string, TaggedEdge<string, string>> Get(UndirectedGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new UndirectedDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new UndirectedVertexPredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.VerticesPredecessors;
            }
        }

        public static IEnumerable<Edge<int>> GetPath(UndirectedGraph<int, Edge<int>> g, int v)
        {
            var dfs = new UndirectedDepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new UndirectedVertexPredecessorRecorderObserver<int, Edge<int>>();

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                recorder.TryGetPath(v, out var path);
                return path;
            }
        }

        public static IEnumerable<TaggedEdge<string, string>> GetPath(UndirectedGraph<string, TaggedEdge<string, string>> g, string v)
        {
            var dfs = new UndirectedDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new UndirectedVertexPredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                recorder.TryGetPath(v, out var path);
                return path;
            }
        }
    }
}
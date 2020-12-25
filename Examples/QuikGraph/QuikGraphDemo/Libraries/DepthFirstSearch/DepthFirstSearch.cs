using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using System.Collections.Generic;

namespace Algorithms
{
    public static class DepthFirstSearch
    {
        public static IEnumerable<Edge<int>> EdgeRecorder(AdjacencyGraph<int, Edge<int>> g)
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

        public static IEnumerable<TaggedEdge<string, string>> EdgeRecorder(AdjacencyGraph<string, TaggedEdge<string, string>> g)
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

        public static List<List<Edge<int>>> EdgePredecessorRecorder(AdjacencyGraph<int, Edge<int>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new EdgePredecessorRecorderObserver<int, Edge<int>>();

            List<List<Edge<int>>> results = new List<List<Edge<int>>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                var allMergedPaths = recorder.AllMergedPaths();
                foreach (var p in allMergedPaths)
                {
                    results.Add((List<Edge<int>>)p);
                }
            }
            return results;
        }

        public static List<List<TaggedEdge<string, string>>> EdgePredecessorRecorder(AdjacencyGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new EdgeDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new EdgePredecessorRecorderObserver<string, TaggedEdge<string, string>>();
            List<List<TaggedEdge<string, string>>> results = new List<List<TaggedEdge<string, string>>>();
            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                var allMergedPaths = recorder.AllMergedPaths();
                foreach (var p in allMergedPaths)
                {
                    results.Add((List<TaggedEdge<string, string>>)p);
                }
            }
            return results;
        }

        public static IDictionary<int, double> UndirectedVertexDistanceRecorder(UndirectedGraph<int, Edge<int>> g)
        {
            var dfs = new UndirectedDepthFirstSearchAlgorithm<int, Edge<int>>(g);
            var recorder = new UndirectedVertexDistanceRecorderObserver<int, Edge<int>>(edgeWeights => 1.0);

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Distances;
            }
        }

        public static IDictionary<string, double> UndirectedVertexDistanceRecorder(UndirectedGraph<string, TaggedEdge<string, string>> g)
        {
            var dfs = new UndirectedDepthFirstSearchAlgorithm<string, TaggedEdge<string, string>>(g);
            var recorder = new UndirectedVertexDistanceRecorderObserver<string, TaggedEdge<string, string>>(edgeWeights => 1.0);

            using (recorder.Attach(dfs))
            {
                dfs.Compute();
                return recorder.Distances;
            }
        }
    }
}
using QuikGraph;
using QuikGraph.Algorithms.MinimumSpanningTree;
using QuikGraph.Algorithms.Observers;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.MinimumSpanningTree
{
    public static class KruskalMinimumSpanningTree
    {
        public static IEnumerable<Edge<int>> GetEdges(UndirectedGraph<int, Edge<int>> g)
        {
            var algorithm = new KruskalMinimumSpanningTreeAlgorithm<int, Edge<int>>(g, edgeWeights => 1.0);
            var recorder = new EdgeRecorderObserver<int, Edge<int>>();

            using (recorder.Attach(algorithm))
            {
                algorithm.Compute();
                return recorder.Edges;
            }
        }

        public static IEnumerable<TaggedEdge<string, string>> GetEdges(UndirectedGraph<string, TaggedEdge<string, string>> g)
        {
            var algorithm = new KruskalMinimumSpanningTreeAlgorithm<string, TaggedEdge<string, string>>(g, edgeWeights => double.Parse(edgeWeights.Tag));
            var recorder = new EdgeRecorderObserver<string, TaggedEdge<string, string>>();

            using (recorder.Attach(algorithm))
            {
                algorithm.Compute();
                return recorder.Edges;
            }
        }

        public static double GetCost(UndirectedGraph<int, Edge<int>> g)
        {
            var algorithm = new KruskalMinimumSpanningTreeAlgorithm<int, Edge<int>>(g, edgeWeights => 1.0);
            var recorder = new EdgeRecorderObserver<int, Edge<int>>();

            var distances = new Dictionary<Edge<int>, double>();
            foreach (var edge in g.Edges)
            {
                distances[edge] = 1.0;
            }

            using (recorder.Attach(algorithm))
            {
                algorithm.Compute();
                return recorder.Edges.Sum(e => distances[e]);
            }
        }

        public static double GetCost(UndirectedGraph<string, TaggedEdge<string, string>> g)
        {
            var algorithm = new KruskalMinimumSpanningTreeAlgorithm<string, TaggedEdge<string, string>>(g, edgeWeights => double.Parse(edgeWeights.Tag));
            var recorder = new EdgeRecorderObserver<string, TaggedEdge<string, string>>();

            var distances = new Dictionary<TaggedEdge<string, string>, double>();
            foreach (var e in g.Edges)
            {
                distances[e] = double.Parse(e.Tag);
            }

            using (recorder.Attach(algorithm))
            {
                algorithm.Compute();
                return recorder.Edges.Sum(e => distances[e]);
            }
        }
    }
}
using QuikGraph;
using QuikGraph.Algorithms.Observers;
using QuikGraph.Algorithms.Search;
using QuikGraph.Collections;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class BreadthFirstSearch
    {
        public static IDictionary<TVertex, TEdge> GetVertexPredecessor<TVertex, TEdge>(AdjacencyGraph<TVertex, TEdge> g) where TEdge : IEdge<TVertex>
        {
            var algorithm = new BreadthFirstSearchAlgorithm<TVertex, TEdge>(g);

            var recorder = new VertexPredecessorRecorderObserver<TVertex, TEdge>();
            using (recorder.Attach(algorithm))
                algorithm.Compute();

            return recorder.VerticesPredecessors;
        }

        public static List<IEnumerable<TEdge>> GetVertexPaths<TVertex, TEdge>(AdjacencyGraph<TVertex, TEdge> g) where TEdge : IEdge<TVertex>
        {
            var queue = new BinaryQueue<TVertex, double>(vertex => 1.0);
            var verticesColors = new Dictionary<TVertex, GraphColor>();

            var algorithm = new BreadthFirstSearchAlgorithm<TVertex, TEdge>(g, queue, verticesColors);
            var recorder = new VertexPredecessorPathRecorderObserver<TVertex, TEdge>();

            List<IEnumerable<TEdge>> results = new List<IEnumerable<TEdge>>();
            using (recorder.Attach(algorithm))
            {
                algorithm.Compute();
            }

            var paths = recorder.AllPaths();
            foreach (var p in paths)
            {
                results.Add(p);
            }
            return results;
        }
    }
}
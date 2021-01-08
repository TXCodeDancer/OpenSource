//
// Main: Method to demonstrate usage of the Visualize.Visualizer library.
//

using Algorithms.ConnectedComponents;
using Algorithms.MaximumFlow;
using Algorithms.MinimumSpanningTree;
using Algorithms.Observers;
using Algorithms.Search;
using Algorithms.ShortestPath;
using Algorithms.TopologicalSort;
using QuikGraph;
using QuikGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.Linq;
using Visualizers;

namespace Main
{
    public class Graph
    {
        public static bool hasTags(List<List<string>> edges)
        {
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;
            return hasTaggedEdges;
        }

        public static AdjacencyGraph<int, Edge<int>> CreateAdjacencyGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<int, Edge<int>>();
            List<int> intNodes = new List<int>();
            foreach (var v in nodes)
            {
                intNodes.Add(int.Parse(v));
            }

            g.AddVertexRange(intNodes);
            foreach (var e in edges)
            {
                g.AddEdge(new Edge<int>(int.Parse(e[0]), int.Parse(e[1])));
            }

            return g;
        }

        public static AdjacencyGraph<string, TaggedEdge<string, string>> CreateTaggedAdjacencyGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
        }

        public static AdjacencyGraph<string, EquatableTaggedEdge<string, double>> CreateEquatableTaggedAdjacencyGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<string, EquatableTaggedEdge<string, double>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new EquatableTaggedEdge<string, double>(e[0], e[1], double.Parse(e[2])));
            }

            return g;
        }

        public static AdjacencyGraph<int, EquatableTaggedEdge<int, double>> CreateEquatableUnTaggedAdjacencyGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<int, EquatableTaggedEdge<int, double>>();

            List<int> intNodes = new List<int>();
            foreach (var v in nodes)
            {
                intNodes.Add(int.Parse(v));
            }

            g.AddVertexRange(intNodes);
            foreach (var e in edges)
            {
                g.AddEdge(new EquatableTaggedEdge<int, double>(int.Parse(e[0]), int.Parse(e[1]), 1.0));
            }

            return g;
        }

        public static UndirectedGraph<int, Edge<int>> CreateUndirectedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new UndirectedGraph<int, Edge<int>>();
            List<int> intNodes = new List<int>();
            foreach (var v in nodes)
            {
                intNodes.Add(int.Parse(v));
            }

            g.AddVertexRange(intNodes);
            foreach (var e in edges)
            {
                g.AddEdge(new Edge<int>(int.Parse(e[0]), int.Parse(e[1])));
            }

            return g;
        }

        public static UndirectedGraph<string, TaggedEdge<string, string>> CreateUndirectedTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new UndirectedGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
        }

        public static UndirectedGraph<string, TaggedEdge<string, string>> CreateUndirectedTaggedGraph(List<string> nodes, IEnumerable<TaggedEdge<string, string>> edges)
        {
            var g = new UndirectedGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(e);
            }

            return g;
        }

        public static UndirectedGraph<int, Edge<int>> CreateUndirectedTaggedGraph(List<string> nodes, IEnumerable<Edge<int>> edges)
        {
            var g = new UndirectedGraph<int, Edge<int>>();
            foreach (var n in nodes)
            {
                g.AddVertex(int.Parse(n));
            }

            foreach (var e in edges)
            {
                g.AddEdge(e);
            }

            return g;
        }

        public static BidirectionalGraph<int, Edge<int>> CreateBidirectionalGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new BidirectionalGraph<int, Edge<int>>();
            List<int> intNodes = new List<int>();
            foreach (var v in nodes)
            {
                intNodes.Add(int.Parse(v));
            }

            g.AddVertexRange(intNodes);
            foreach (var e in edges)
            {
                g.AddEdge(new Edge<int>(int.Parse(e[0]), int.Parse(e[1])));
            }

            return g;
        }

        public static BidirectionalGraph<string, TaggedEdge<string, string>> CreateBidirectionalTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new BidirectionalGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
        }

        public static void Visualizer(List<string> nodes, List<List<string>> edges, string filepath)
        {
            if (Graph.hasTags(edges))
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var image = new Visualize(GraphvizVertexShape.Box, GraphvizVertexStyle.Rounded);
                image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateAdjacencyGraph(nodes, edges);
                var image = new Visualize(GraphvizVertexShape.Circle);
                image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
        }

        public static void Visualizer(AdjacencyGraph<string, TaggedEdge<string, string>> g, string filepath)
        {
            var image = new Visualize(GraphvizVertexShape.Box, GraphvizVertexStyle.Rounded);
            image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
        }

        public static void Visualizer(AdjacencyGraph<int, Edge<int>> g, string filepath)
        {
            var image = new Visualize(GraphvizVertexShape.Circle);
            image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
        }

        public static void Visualizer(BidirectionalGraph<string, TaggedEdge<string, string>> g, string filepath)
        {
            var image = new Visualize(GraphvizVertexShape.Box, GraphvizVertexStyle.Rounded);
            image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
        }

        public static void Visualizer(BidirectionalGraph<int, Edge<int>> g, string filepath)
        {
            var image = new Visualize(GraphvizVertexShape.Circle);
            image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
        }

        public static void Visualizer(UndirectedGraph<string, TaggedEdge<string, string>> g, string filepath)
        {
            var image = new Visualize(GraphvizVertexShape.Box, GraphvizVertexStyle.Rounded);
            image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
        }

        public static void Visualizer(UndirectedGraph<int, Edge<int>> g, string filepath)
        {
            var image = new Visualize(GraphvizVertexShape.Circle);
            image.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
        }
    }

    public class ConnectedComponentsHelper
    {
        public static List<string> WeaklyConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> StronglyConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = StronglyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = StronglyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> StronglyConnectedComponentsGraph(List<string> nodes, List<List<string>> edges, string outputFile)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = StronglyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var graph = ans[i];
                    var path = $"{outputFile}_{i}";
                    Graph.Visualizer(graph, path);
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = StronglyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var graph = ans[i];
                    var path = $"{outputFile}_{i}";
                    Graph.Visualizer(graph, path);
                }
            }
            return results;
        }

        public static List<string> WeaklyConnectedComponentsGraph(List<string> nodes, List<List<string>> edges, string outputFile)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var graph = ans[i];
                    var path = $"{outputFile}_{i}";
                    Graph.Visualizer(graph, path);
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = WeaklyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var graph = ans[i];
                    var path = $"{outputFile}_{i}";
                    Graph.Visualizer(graph, path);
                }
            }
            return results;
        }

        public static List<string> IncrementalConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = IncrementalConnectedComponents.Get(g);
                var key = ans.Key;
                results.Add($"Components {key}:");
                var dict = ans.Value;
                foreach (var d in dict)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = IncrementalConnectedComponents.Get(g);
                var key = ans.Key;
                results.Add($"Components {key}:");
                var dict = ans.Value;
                foreach (var d in dict)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> GenericConnectedComponentsHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = GenericConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = GenericConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }
    }

    public class MaximumFlowHelper
    {
        public static List<string> EdmondsKarpMaxFlowHelper(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateEquatableTaggedAdjacencyGraph(nodes, edges);
                var ans = EdmondsKarpMaxFlow.Get(g, source, sink);
                results.Add($"{ans}");
            }
            return results;
        }

        public static List<string> EdmondsKarpMaxFlowPredecessors(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateEquatableTaggedAdjacencyGraph(nodes, edges);
                var ans = EdmondsKarpMaxFlow.GetPredecessors(g, source, sink);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> EdmondsKarpMaxFlowResidualCapacities(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateEquatableTaggedAdjacencyGraph(nodes, edges);
                var ans = EdmondsKarpMaxFlow.GetResidualCapacities(g, source, sink);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }
    }

    public class ObserverHelper
    {
        public static List<string> Vertex(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = VertexObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = VertexObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> Edge(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = EdgeObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = EdgeObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> EdgePredecessorPath(List<string> nodes, List<List<string>> edges, string v)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = EdgePredecessorObs.GetPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Edge Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = EdgePredecessorObs.GetPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Edge Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> EdgePredecessor(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = EdgePredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = EdgePredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> VertexDistance(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = VertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = VertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> UndirectedVertexDistance(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> UndirectedVertexPredecessor(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.Get(g);

                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> VertexPredecessor(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = VertexPredecessorObs.Get(g);

                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = VertexPredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> UndirectedVertexPredecessorPath(List<string> nodes, List<List<string>> edges, string v)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.GetPath(g, v);
                foreach (var n in dfs)
                {
                    results.Add(n.ToString());
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var dfs = UndirectedVertexPredecessorObs.GetPath(g, int.Parse(v));
                foreach (var n in dfs)
                {
                    results.Add(n.ToString());
                }
            }
            return results;
        }

        public static List<string> VertexPredecessorPath(List<string> nodes, List<List<string>> edges, string v)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = VertexPredecessorObs.GetPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Vertex Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = VertexPredecessorObs.GetPaths(g);
                for (int i = 0; i < dfs.Count; i++)
                {
                    var p = dfs[i];
                    results.Add($"Vertex Path {i}:");
                    foreach (var e in p)
                        results.Add(e.ToString());
                }
            }
            return results;
        }

        public static List<string> VertexDiscoverTimeStamp(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetDiscoverTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetDiscoverTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> VertexFinishTimeStamp(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetFinishTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetFinishTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }
    }

    public class MinimumSpanningTreeHelper
    {
        public static List<string> KruskalEdge(List<string> nodes, List<List<string>> edges, string filepath)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetEdges(g);
                var mst = Graph.CreateUndirectedTaggedGraph(nodes, ans);
                Graph.Visualizer(mst, filepath);
                foreach (var n in ans)
                {
                    results.Add(n.ToString());
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetEdges(g);
                var mst = Graph.CreateUndirectedTaggedGraph(nodes, ans);
                Graph.Visualizer(mst, filepath);
                foreach (var n in ans)
                {
                    results.Add(n.ToString());
                }
            }
            return results;
        }

        public static List<string> KruskalCost(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetCost(g);
                results.Add(ans.ToString());
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetCost(g);
                results.Add(ans.ToString());
            }
            return results;
        }

        public static List<string> PrimEdge(List<string> nodes, List<List<string>> edges, string filepath)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = PrimMinimumSpanningTree.GetEdges(g);
                var mst = Graph.CreateUndirectedTaggedGraph(nodes, ans);
                Graph.Visualizer(mst, filepath);
                foreach (var n in ans)
                {
                    results.Add(n.ToString());
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = PrimMinimumSpanningTree.GetEdges(g);
                var mst = Graph.CreateUndirectedTaggedGraph(nodes, ans);
                Graph.Visualizer(mst, filepath);
                foreach (var n in ans)
                {
                    results.Add(n.ToString());
                }
            }
            return results;
        }

        public static List<string> PrimCost(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = PrimMinimumSpanningTree.GetCost(g);
                results.Add(ans.ToString());
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = PrimMinimumSpanningTree.GetCost(g);
                results.Add(ans.ToString());
            }
            return results;
        }
    }

    public class SearchHelper
    {
        public static List<string> BestFirstFrontierSearchSeekTarget(List<string> nodes, List<List<string>> edges, string root, string target)
        {
            List<string> results = new List<string>();
            bool ans = false;
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateBidirectionalTaggedGraph(nodes, edges);
                ans = BestFirstFrontierSearch.FoundTarget(g, root, target);
            }
            else
            {
                var g = Graph.CreateBidirectionalGraph(nodes, edges);
                ans = BestFirstFrontierSearch.FoundTarget(g, int.Parse(root), int.Parse(target));
            }

            if (ans)
            {
                results.Add($"Found {target} from {root}");
            }
            else
            {
                results.Add($"Can't find {target} from {root}");
            }
            return results;
        }

        public static List<string> BestFirstFrontierSearchVertexPredecessor(List<string> nodes, List<List<string>> edges, string root, string target)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateBidirectionalTaggedGraph(nodes, edges);
                var ans = BestFirstFrontierSearch.GetVertexPredecessor(g, root, target);
                foreach (var x in ans)
                {
                    results.Add(x.ToString());
                }
            }
            else
            {
                var g = Graph.CreateBidirectionalGraph(nodes, edges);
                var ans = BestFirstFrontierSearch.GetVertexPredecessor(g, int.Parse(root), int.Parse(target));
                foreach (var x in ans)
                {
                    results.Add(x.ToString());
                }
            }
            return results;
        }
    }

    public class ShortestPathHelper
    {
        public static List<string> AStarShortestPathHelper(List<string> nodes, List<List<string>> edges, string root)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = AStarShortestPath.Get(g, root);
                foreach (var d in ans)
                {
                    var value = (d.Value < double.MaxValue) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = AStarShortestPath.Get(g, int.Parse(root));
                foreach (var d in ans)
                {
                    var value = (d.Value < int.MaxValue) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            return results;
        }

        public static List<string> BellmanFordShortestPathHelper(List<string> nodes, List<List<string>> edges, string root)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = BellmanFordShortestPath.Get(g, root);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = BellmanFordShortestPath.Get(g, int.Parse(root));
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> DirectedAcyclicGraphShortestPathHelper(List<string> nodes, List<List<string>> edges, string root)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var (isDiag, ans) = DirectedAcyclicGraphShortestPath.Get(g, root);
                if (isDiag)
                {
                    foreach (var d in ans)
                    {
                        results.Add($"{d.Key}: {d.Value}");
                    }
                }
                else
                    results.Add("This is not a Directed Acyclic Graph.");
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var (isDiag, ans) = DirectedAcyclicGraphShortestPath.Get(g, int.Parse(root));
                if (isDiag)
                {
                    foreach (var d in ans)
                    {
                        results.Add($"{d.Key}: {d.Value}");
                    }
                }
                else
                    results.Add("This is not a Directed Acyclic Graph.");
            }
            return results;
        }

        public static List<string> DijkstraShortestPathHelper(List<string> nodes, List<List<string>> edges, string root)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = DijkstraShortestPath.Get(g, root);
                foreach (var d in ans)
                {
                    var value = (d.Value < int.MaxValue) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = DijkstraShortestPath.Get(g, int.Parse(root));
                foreach (var d in ans)
                {
                    var value = (d.Value < int.MaxValue) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            return results;
        }

        public static List<string> UndirectedDijkstraShortestPathHelper(List<string> nodes, List<List<string>> edges, string root)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = UndirectedDijkstraShortestPath.Get(g, root);
                foreach (var d in ans)
                {
                    var value = (d.Value < int.MaxValue) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = UndirectedDijkstraShortestPath.Get(g, int.Parse(root));
                foreach (var d in ans)
                {
                    var value = (d.Value < int.MaxValue) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            return results;
        }

        public static List<string> FloydWarshallShortestPathHelper(List<string> nodes, List<List<string>> edges, string root)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var ans = FloydWarshallShortestPath.Get(g, root);
                foreach (var d in ans)
                {
                    var value = (d.Value != -1) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var ans = FloydWarshallShortestPath.Get(g, int.Parse(root));
                foreach (var d in ans)
                {
                    var value = (d.Value != -1) ? d.Value : double.PositiveInfinity;
                    results.Add($"{d.Key}: {value}");
                }
            }
            return results;
        }

        public static List<string> YenShortestPathHelper(List<string> nodes, List<List<string>> edges, string root, string target)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateEquatableTaggedAdjacencyGraph(nodes, edges);
                var (ans, message) = YenShortestPath.Get(g, root, target);
                if (message == null)
                {
                    double sum = 0;
                    foreach (var e in ans)
                    {
                        sum += e.Tag;
                        results.Add($"{e}");
                    }
                    results.Add($"Shortest distance ({root} -> {target}) = {sum}");
                }
                else
                {
                    results.Add($"{message} ({root} -> {target})");
                }
            }
            else
            {
                var g = Graph.CreateEquatableUnTaggedAdjacencyGraph(nodes, edges);
                var (ans, message) = YenShortestPath.Get(g, int.Parse(root), int.Parse(target));
                if (message == null)
                {
                    double sum = 0;
                    foreach (var e in ans)
                    {
                        sum += e.Tag;
                        results.Add($"{e}");
                    }
                    results.Add($"Shortest distance ({root} -> {target}) = {sum}");
                }
                else
                {
                    results.Add($"{message} ({root} -> {target})");
                }
            }
            return results;
        }

        public static List<string> YenAllPathsHelper(List<string> nodes, List<List<string>> edges, string root, string target)
        {
            List<string> results = new List<string>();
            int i = 0;
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateEquatableTaggedAdjacencyGraph(nodes, edges);
                var (ans, message) = YenShortestPath.GetAll(g, root, target);
                if (ans != null)
                {
                    foreach (var a in ans)
                    {
                        double sum = 0;
                        results.Add($"Path {i++}:");
                        foreach (var e in a)
                        {
                            sum += e.Tag;
                            results.Add($"{e}");
                        }
                        results.Add($"Distance ({root} -> {target}) = {sum}");
                    }
                }
                else
                {
                    results.Add($"{message} ({root} -> {target})");
                }
            }
            else
            {
                var g = Graph.CreateEquatableUnTaggedAdjacencyGraph(nodes, edges);
                var (ans, message) = YenShortestPath.GetAll(g, int.Parse(root), int.Parse(target));
                if (ans != null)
                {
                    foreach (var a in ans)
                    {
                        double sum = 0;
                        results.Add($"Path {i++}:");
                        foreach (var e in a)
                        {
                            sum += e.Tag;
                            results.Add($"{e}");
                        }
                        results.Add($"Distance ({root} -> {target}) = {sum}");
                    }
                }
                else
                {
                    results.Add($"{message} ({root} -> {target})");
                }
            }
            return results;
        }
    }

    public class TopologicalSortHelpers
    {
        public static List<string> SourceFirstBidirectionalTopologicalSortHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateBidirectionalTaggedGraph(nodes, edges);
                var (ans, message) = SourceFirstBidirectionalTopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            else
            {
                var g = Graph.CreateBidirectionalGraph(nodes, edges);
                var (ans, message) = SourceFirstBidirectionalTopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            return results;
        }

        public static List<string> SourceFirstTopologicalSortHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var (ans, message) = SourceFirstTopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var (ans, message) = SourceFirstTopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            return results;
        }

        public static List<string> TopologicalSortHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateTaggedAdjacencyGraph(nodes, edges);
                var (ans, message) = TopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            else
            {
                var g = Graph.CreateAdjacencyGraph(nodes, edges);
                var (ans, message) = TopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            return results;
        }

        public static List<string> UndirectedFirstTopologicalSortHelper(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var (ans, message) = UndirectedFirstTopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var (ans, message) = UndirectedFirstTopologicalSort.Get(g);
                if (ans != null)
                {
                    foreach (var v in ans)
                        results.Add($"{v}");
                }
                else
                {
                    results.Add($"{message}");
                }
            }
            return results;
        }
    }

    public class Program
    {
        private static void Main()
        {
            string filepath = @"ManualInput";
            var nodes = Console.ReadLine().Split(' ').ToList(); // First line is a space delimited list of node names: "1 2 3" or "a b c"
            List<List<string>> edges = new List<List<string>>();
            string edge;
            while ((edge = Console.ReadLine()) != null && edge != "")
            {
                edges.Add(edge.Split(' ').ToList()); // Remaining lines are space delimited list of edges (nodeA nodeB tag(optional)):  "1 2" or "a b 5"
            }

            Graph.Visualizer(nodes, edges, filepath);
        }
    }
}

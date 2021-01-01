//
// Main: Method to demonstrate usage of the Visualize.Visualizer library.
//

using Algorithms.ConnectedComponents;
using Algorithms.MaximumFlow;
using Algorithms.MinimumSpanningTree;
using Algorithms.Observers;
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

        public static AdjacencyGraph<int, Edge<int>> CreateDirectedGraph(List<string> nodes, List<List<string>> edges)
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

        public static AdjacencyGraph<string, TaggedEdge<string, string>> CreateDirectedTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<string, TaggedEdge<string, string>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
            }

            return g;
        }

        public static AdjacencyGraph<string, EquatableTaggedEdge<string, double>> CreateDirectedEquatableTaggedGraph(List<string> nodes, List<List<string>> edges)
        {
            var g = new AdjacencyGraph<string, EquatableTaggedEdge<string, double>>();
            g.AddVertexRange(nodes);
            foreach (var e in edges)
            {
                g.AddEdge(new EquatableTaggedEdge<string, double>(e[0], e[1], double.Parse(e[2])));
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

        public static void Visualizer(List<string> nodes, List<List<string>> edges, string filepath)
        {
            if (Graph.hasTags(edges))
            {
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                Visualizers.Visualizer.ExportDot(g, filepath);
                Visualizers.Visualizer.VertexShape = GraphvizVertexShape.Box;
                Visualizers.Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                Visualizers.Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
                Visualizers.Visualizer.ExportDot(g, filepath);
                Visualizers.Visualizer.VertexShape = GraphvizVertexShape.Circle;
                Visualizers.Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.dot);
            }
        }
    }

    public class ConnectedComponentsHelper
    {
        public static List<string> WeaklyConnectedComponents(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.WeaklyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.WeaklyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> StronglyConnectedComponents(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.StronglyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.StronglyConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            return results;
        }

        public static List<string> StronglyConnectedComponentsGraph(List<string> nodes, List<List<string>> edges, string filepath)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.StronglyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{filepath}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Box;
                    Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{filepath}_{i}", ImageLayout.circo);
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.StronglyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{filepath}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Circle;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{filepath}_{i}", ImageLayout.dot);
                }
            }
            return results;
        }

        public static List<string> WeaklyConnectedComponentsGraph(List<string> nodes, List<List<string>> edges, string outputFile)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.WeaklyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{outputFile}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Box;
                    Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{outputFile}_{i}", ImageLayout.circo);
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.WeaklyConnectedComponents.GetGraphs(g);
                results.Add($"Graphs: {ans.Length}");
                for (int i = 0; i < ans.Length; i++)
                {
                    var _g = ans[i];
                    Visualizer.ExportDot(_g, $"{outputFile}_{i}");
                    Visualizer.VertexShape = GraphvizVertexShape.Circle;
                    Visualizer.ExportImageFile(_g, GraphvizImageType.Svg, $"{outputFile}_{i}", ImageLayout.dot);
                }
            }
            return results;
        }

        public static List<string> IncrementalConnectedComponents(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.IncrementalConnectedComponents.Get(g);
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
                var ans = Algorithms.ConnectedComponents.IncrementalConnectedComponents.Get(g);
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

        public static List<string> ConnectedComponents(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.ConnectedComponents.Get(g);
                foreach (var d in ans)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = Algorithms.ConnectedComponents.ConnectedComponents.Get(g);
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
        public static List<string> EdmondsKarpMaxFlow(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateDirectedEquatableTaggedGraph(nodes, edges);
                var ans = Algorithms.MaximumFlow.EdmondsKarpMaxFlow.Get(g, source, sink);
                results.Add($"{ans}");
            }
            return results;
        }

        public static List<string> EdmondsKarpMaxFlowPredecessors(List<string> nodes, List<List<string>> edges, string source, string sink)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges)) // Only valid for tagged edges
            {
                var g = Graph.CreateDirectedEquatableTaggedGraph(nodes, edges);
                var ans = Algorithms.MaximumFlow.EdmondsKarpMaxFlow.GetPredecessors(g, source, sink);
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
                var g = Graph.CreateDirectedEquatableTaggedGraph(nodes, edges);
                var ans = Algorithms.MaximumFlow.EdmondsKarpMaxFlow.GetResidualCapacities(g, source, sink);
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
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
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
                AdjacencyGraph<string, TaggedEdge<string, string>> g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgeObs.Get(g);
                foreach (var e in dfs)
                {
                    results.Add(e.ToString());
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
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
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.GetAllPaths(g);
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
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.GetAllPaths(g);
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
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = EdgePredecessorObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                AdjacencyGraph<int, Edge<int>> g = Graph.CreateDirectedGraph(nodes, edges);
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
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexDistanceObs.Get(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
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
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.Get(g);

                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
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
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.GetAllPaths(g);
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
                var g = Graph.CreateDirectedGraph(nodes, edges);
                var dfs = VertexPredecessorObs.GetAllPaths(g);
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

        public static List<string> VertexDiscoverTimeStamp(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetDiscoverTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
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
                var g = Graph.CreateDirectedTaggedGraph(nodes, edges);
                var dfs = VertexTimeStampObs.GetFinishTimes(g);
                foreach (var d in dfs)
                {
                    results.Add($"{d.Key}: {d.Value}");
                }
            }
            else
            {
                var g = Graph.CreateDirectedGraph(nodes, edges);
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
        public static List<string> KruskalEdge(List<string> nodes, List<List<string>> edges)
        {
            List<string> results = new List<string>();
            if (Graph.hasTags(edges))
            {
                var g = Graph.CreateUndirectedTaggedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetEdges(g);
                foreach (var n in ans)
                {
                    results.Add(n.ToString());
                }
            }
            else
            {
                var g = Graph.CreateUndirectedGraph(nodes, edges);
                var ans = KruskalMinimumSpanningTree.GetEdges(g);
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
//
// Main: Method to demonstrate usage of the Visualize.Visualizer library.
//

using QuikGraph;
using QuikGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.IO;
using Visualize;

namespace Main
{
    public class EdgeModel
    {
        public EdgeModel(NodeModel v, long w = 1, string tag = "")
        {
            V = v;
            Tag = tag;
            Weight = w;
        }

        public NodeModel V { get; set; }
        public string Tag { get; set; }
        public long Weight { get; set; }
    }

    public class NodeModel
    {
        public NodeModel(string input)
        {
            var tokens = input.Split(' ');
            ID = int.Parse(tokens[0]);
            if (tokens.Length > 0)
                Name = tokens[1];
        }

        public NodeModel(int iD, string name = "")
        {
            ID = iD;
            Edges = new List<EdgeModel>();
            Name = name;
        }

        public int ID { get; set; }
        public List<EdgeModel> Edges { get; set; }
        public string Name { get; set; }

        public void AddDirectedEdge(NodeModel v, int weight, string tag)
        {
            Edges.Add(new EdgeModel(v, weight, tag));
        }
    }

    public class Program
    {
        public static void GraphVisualizerHelper(List<string> nodes, string nodeType, List<List<string>> edges, string filepath)
        {
            Type type;
            TypeCode typeCode;
            switch (nodeType)
            {
                case "int":
                    int foo = 0;
                    type = foo.GetType();
                    break;

                case "double":
                    type = typeof(double);
                    break;

                default:
                    type = typeof(string);
                    break;
            }
            bool hasTaggedEdges = false;
            if (edges[0].Count > 2)
                hasTaggedEdges = true;

            if (hasTaggedEdges)
            {
                var g = new AdjacencyGraph<string, TaggedEdge<string, string>>();
                g.AddVertexRange(nodes);
                foreach (var e in edges)
                {
                    g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
                }
                Visualizer.ExportDot(g, filepath);
                Visualizer.VertexShape = GraphvizVertexShape.Box;
                Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
            else
            {
                //                 var g = new AdjacencyGraph<int, Edge<int>>();
                //
                //                 g.AddVertexRange(nodes);
                //                 foreach (var e in edges)
                //                 {
                //                     g.AddEdge(new TaggedEdge<string, string>(e[0], e[1], e[2]));
                //                 }
                //                 Visualizer.ExportDot(g, filepath);
                //                 Visualizer.VertexShape = GraphvizVertexShape.Box;
                //                 Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
                //                 Visualizer.ExportImageFile(g, GraphvizImageType.Svg, filepath, ImageLayout.circo);
            }
        }

        private static void Main(string[] args)
        {
            string dir = @"D:\Samples\QuikGraph\QuikSample\Graphs";
            AdjacencyGraph<int, Edge<int>> displayGraph1 = GetGraph1();

            string filename = "test1";
            string filepath = Path.Combine(dir, filename);
            Visualizer.ExportDot(displayGraph1, filepath);
            Visualizer.ExportImageFile(displayGraph1, GraphvizImageType.Svg, filepath, ImageLayout.dot);

            var displayGraph2 = GetGraph2();

            filename = "test2";
            filepath = Path.Combine(dir, filename);
            Visualizer.ExportDot(displayGraph2, filepath);
            Visualizer.VertexShape = GraphvizVertexShape.Box;
            Visualizer.VertexStyle = GraphvizVertexStyle.Rounded;
            Visualizer.ExportImageFile(displayGraph2, GraphvizImageType.Svg, filepath, ImageLayout.circo);

            //             var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(displayGraph1);
            //             //do the search
            //             dfs.Compute();
            //
            //             var dfsGraph = dfs.VisitedGraph;
            //             filename = "test3";
            //             CreateImageFile((AdjacencyGraph<int, Edge<int>>)dfsGraph, GraphvizImageType.Svg, filename);
        }

        private static AdjacencyGraph<int, Edge<int>> GetGraph1()
        {
            var graph = new AdjacencyGraph<int, Edge<int>>();
            graph.AddVertexRange(new[] { 1, 2, 3, 4, 5 });
            graph.AddEdgeRange(new[]
            {
                new Edge<int>(1, 4),
                new Edge<int>(1, 2),
                new Edge<int>(2, 3),
                new Edge<int>(3, 5),
                new Edge<int>(3, 1),
                new Edge<int>(4, 3),
                new Edge<int>(5, 1),
            });

            var displayGraph = new AdjacencyGraph<int, Edge<int>>();

            foreach (var vertex in graph.Vertices)
            {
                displayGraph.AddVertex(vertex);
            }
            foreach (var edge in graph.Edges)
            {
                displayGraph.AddEdge(edge);
            }

            return displayGraph;
        }

        private static AdjacencyGraph<string, TaggedEdge<string, string>> GetGraph2()
        {
            var graph = new AdjacencyGraph<string, TaggedEdge<string, string>>();
            graph.AddVertexRange(new[] { "a", "b", "c", "d", "e" });
            graph.AddEdgeRange(new[]
            {
                new TaggedEdge<string, string>("a", "b", "5"),
                new TaggedEdge<string, string>("a", "d", "1"),
                new TaggedEdge<string, string>("b", "c", "6"),
                new TaggedEdge<string, string>("c", "a", "7"),
                new TaggedEdge<string, string>("c", "e", "3"),
                new TaggedEdge<string, string>("d", "c", "2"),
                new TaggedEdge<string, string>("e", "a", "4"),
            });

            var displayGraph = new AdjacencyGraph<string, TaggedEdge<string, string>>();

            foreach (var vertex in graph.Vertices)
            {
                displayGraph.AddVertex(vertex);
            }
            foreach (var edge in graph.Edges)
            {
                displayGraph.AddEdge(edge);
            }

            return displayGraph;
        }
    }
}
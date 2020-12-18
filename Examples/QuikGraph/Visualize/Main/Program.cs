using QuikGraph;
using QuikGraph.Algorithms.Search;
using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;

namespace Main
{
    internal class Program
    {
        public static void ShowPicture(string filename)
        {
            // How to open file with default viewer?
            //             using (Form f = new Form())
            //             {
            //                 // f.FormBorderStyle = FormBorderStyle.None;
            //
            //                 PictureBox picture = new PictureBox()
            //                 {
            //                     ImageLocation = filename,
            //                     SizeMode = PictureBoxSizeMode.Normal,
            //                     Dock = DockStyle.Fill,
            //                     Size = new Size(100, 300),
            //                 };
            //                 f.Controls.Add(picture);
            //                 f.Size = picture.Size;
            //
            //                 f.ShowDialog();
            //                 f.Refresh();
            //                 f.Show();
            //             }
        }

        private sealed class FileDotEngine : IDotEngine
        {
            public string Run(GraphvizImageType imageType, string dot, string outputFilePath, string layout)
            {
                File.WriteAllText(outputFilePath + ".dot", dot);
                string type = imageType.ToString().ToLower();

                if (true)
                {
                    // assumes graphviz is on the path:
                    string args = string.Format(CultureInfo.InvariantCulture, $"{outputFilePath}.dot -T{type} -O");
                    System.Diagnostics.Process process = System.Diagnostics.Process.Start($"{layout}.exe", args);
                    if (true)
                    {
                        process.WaitForExit();
                        // ShowPicture(filename + ".pdf");
                    }
                }
                return outputFilePath;
            }

            public string Run(GraphvizImageType imageType, string dot, string outputFilePath)
            {
                var fileInfoList = outputFilePath.Split(' ');
                string filename = fileInfoList[0];
                string layoutEngine = "dot";
                if (fileInfoList.Length > 1)
                    layoutEngine = fileInfoList[1];

                return Run(imageType, dot, filename, layoutEngine);
            }
        }

        private static void Main(string[] args)
        {
            AdjacencyGraph<int, Edge<int>> displayGraph1 = GetGraph1();

            string filename = "test1";
            ExportDot(displayGraph1, filename);
            CreateImageFile(displayGraph1, GraphvizImageType.Svg, filename);

            var displayGraph2 = GetGraph2();

            filename = "test2";
            ExportDot(displayGraph2, filename);
            CreateImageFile(displayGraph2, GraphvizImageType.Svg, filename);

            var dfs = new DepthFirstSearchAlgorithm<int, Edge<int>>(displayGraph1);
            //do the search
            dfs.Compute();

            var dfsGraph = dfs.VisitedGraph;
            filename = "test3";
            CreateImageFile((AdjacencyGraph<int, Edge<int>>)dfsGraph, GraphvizImageType.Svg, filename);
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

        private static void ExportDot(AdjacencyGraph<int, Edge<int>> graph, string filename, string dir = @"D:\Samples\QuikGraph\QuikSample\Graphs")
        {
            string fullFileName = Path.Combine(dir, filename);
            var viz = new GraphvizAlgorithm<int, Edge<int>>(graph);

            var dotfile = fullFileName;
            viz.Generate(new FileDotEngine(), dotfile);
        }

        private static void ExportDot(AdjacencyGraph<string, TaggedEdge<string, string>> graph, string filename, string dir = @"D:\Samples\QuikGraph\QuikSample\Graphs")
        {
            string fullFileName = Path.Combine(dir, filename);
            var viz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph);

            var dotfile = fullFileName;
            viz.Generate(new FileDotEngine(), dotfile);
        }

        private static void FormatVertexHandler(object sender, FormatVertexEventArgs<int> e)
        {
            Contract.Requires(e != null);

            e.VertexFormat.Label = e.Vertex.ToString();
            e.VertexFormat.Shape = GraphvizVertexShape.Box;
            e.VertexFormat.Style = GraphvizVertexStyle.Rounded;
        }

        private static void FormatVertexHandler(object sender, FormatVertexEventArgs<string> e)
        {
            Contract.Requires(e != null);

            e.VertexFormat.Label = e.Vertex;
            e.VertexFormat.Shape = GraphvizVertexShape.Box;
            e.VertexFormat.Style = GraphvizVertexStyle.Rounded;
        }

        private static string CreateImageFile(AdjacencyGraph<int, Edge<int>> graph, GraphvizImageType imageType, string imageFileName, string dir = @"D:\Samples\QuikGraph\QuikSample\Graphs")
        {
            var graphviz = new GraphvizAlgorithm<int, Edge<int>>(graph)
            {
                ImageType = imageType
            };

            graphviz.FormatVertex += FormatVertexHandler;

            string outputfile = Path.Combine(dir, imageFileName + "_svg");
            string layout = "circo";

            graphviz.Generate(new FileDotEngine(), outputfile + " " + layout);
            return outputfile;
        }

        private static string CreateImageFile(AdjacencyGraph<string, TaggedEdge<string, string>> graph, GraphvizImageType imageType, string imageFileName, string dir = @"D:\Samples\QuikGraph\QuikSample\Graphs")
        {
            var graphviz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph)
            {
                ImageType = imageType
            };

            graphviz.FormatVertex += FormatVertexHandler;
            graphviz.FormatEdge += MyEdgeFormatter;

            string outputfile = Path.Combine(dir, imageFileName + "_svg");
            string layout = "circo";

            graphviz.Generate(new FileDotEngine(), outputfile + " " + layout);
            return outputfile;
        }

        private static void MyEdgeFormatter(object sender, FormatEdgeEventArgs<string, TaggedEdge<string, string>> e)
        {
            GraphvizEdgeLabel label = new GraphvizEdgeLabel
            {
                Value = e.Edge.Tag,
            };
            e.EdgeFormat.Label = label;
        }

        private static void VizFormatVertex(object sender, FormatVertexEventArgs<string> e)
        {
            Contract.Requires(e != null);
            e.VertexFormat.Label = e.Vertex.ToString(CultureInfo.InvariantCulture);
        }
    }
}
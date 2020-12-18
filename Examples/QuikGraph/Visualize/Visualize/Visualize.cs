using QuikGraph.Graphviz;
using QuikGraph.Graphviz.Dot;
using System;
using System.Globalization;
using System.IO;

namespace Visualize
{
    public enum ImageLayout
    {
        None = 0,
    }

    public static class Visualizer
    {
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
    }
}
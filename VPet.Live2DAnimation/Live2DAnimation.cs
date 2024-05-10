
using LinePutScript;
using System.IO;
using System.Windows.Controls;
using VPet_Simulator.Core;
using static VPet_Simulator.Core.Picture;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D¶¯»­
    /// </summary>
    public class Live2DAnimation : IImageRun
    {
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is DirectoryInfo p))
            {
                Picture.LoadGraph(graph, path, info);
                return;
            }
            var paths = p.GetFiles();

            bool isLoop = info[(gbol)"loop"];
            PNGAnimation pa = new PNGAnimation(graph, path.FullName, paths, new GraphInfo(path, info), isLoop);
            graph.AddGraph(pa);
        }
        public Live2DAnimation(GraphCore graphCore, string path, FileInfo[] paths, GraphInfo graphinfo, bool isLoop = false)
        {

        }
        public bool IsLoop { get; set; }

        public bool IsReady { get; set; } = false;

        public bool IsFail { get; set; } = false;

        public string FailMessage { get; set; } = "";

        public GraphInfo GraphInfo { get; set; }

        public IGraph.TaskControl Control { get; set; }

        public Task Run(Image img, Action EndAction = null)
        {
            throw new NotImplementedException();
        }

        public void Run(Decorator parant, Action EndAction = null)
        {
            throw new NotImplementedException();
        }
    }

}

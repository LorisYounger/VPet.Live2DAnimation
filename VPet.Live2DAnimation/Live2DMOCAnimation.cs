
using LinePutScript;
using Live2DCSharpSDK.WPF;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using VPet_Simulator.Core;
using static VPet_Simulator.Core.Picture;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D动画 核心MOC文件
    /// </summary>
    public class Live2DMOCAnimation : IGraph
    {
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is FileInfo f) || !f.Extension.Equals(".moc3", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            bool isLoop = info[(gbol)"loop"];
            string modelname = info[(gstr)"modelname"];
            var gi = new GraphInfo(path, info);
            if (string.IsNullOrWhiteSpace(modelname))
            {
                modelname = gi.Name;
            }
            graph.AddGraph(new Live2DMOCAnimation(graph, f,gi, modelname, isLoop));
        }
        private GraphCore GraphCore;
        public Live2DWPFModel Model { get; set; }
        public string ModelName { get; set; }
        public Live2DMOCAnimation(GraphCore graphCore, FileInfo path, GraphInfo graphinfo, string modelname, bool isLoop = false)
        {
            IsLoop = isLoop;
            GraphInfo = graphinfo;
            GraphCore = graphCore;
            try
            {
                Model = new Live2DWPFModel(path.FullName);
                ModelName = modelname;
                GraphCore.CommConfig["L2D" + ModelName] = Model;
                IsReady = true;
            }
            catch (Exception e)
            {
                IsFail = true;
                FailMessage = e.ToString();
            }
        }
        public bool IsLoop { get; set; }

        public bool IsReady { get; set; } = false;

        public bool IsFail { get; set; } = false;

        public string FailMessage { get; set; } = "";

        public GraphInfo GraphInfo { get; set; }

        public IGraph.TaskControl Control { get; set; }


        public override bool Equals(object obj)
        {
            if (!IsReady || !GraphCore.CommConfig.ContainsKey("L2D" + ModelName))
            {
                return false;
            }
            return GraphCore.CommConfig["L2D" + ModelName] == obj;
        }
        public void Run(Decorator parant, Action EndAction = null)
        {
            throw new NotImplementedException();
        }
    }

}

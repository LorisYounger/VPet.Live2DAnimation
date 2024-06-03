using LinePutScript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPet_Simulator.Core;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// 在VPET加载动画前运行初始化方法
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// 在VPET加载动画前运行初始化方法
        /// </summary>
        public static void Main()
        {
            PetLoader.IGraphConvert.Add("l2dmoc", Live2DMOCAnimation.LoadGraph);
            PetLoader.IGraphConvert.Add("l2dmot", Live2DMotionAnimation.LoadGraph);
            PetLoader.IGraphConvert.Add("l2d", LoadGraph);
        }
        /// <summary>
        /// 自动判断和加载L2D动画/模型
        /// </summary>
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is FileInfo f))
            {
                return;
            }
            bool isLoop = info[(gbol)"loop"];
            if (f.Name.ToLower().EndsWith(".motion3.json"))
                Live2DMotionAnimation.LoadGraph(graph, f, info);
            else if (f.Extension.Equals(".moc3", StringComparison.CurrentCultureIgnoreCase))
                Live2DMOCAnimation.LoadGraph(graph, f, info);
        }
    }
}

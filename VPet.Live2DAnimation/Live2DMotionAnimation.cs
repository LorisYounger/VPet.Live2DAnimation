
using LinePutScript;
using Live2DCSharpSDK.WPF;
using System.IO;
using System.Windows.Controls;
using VPet_Simulator.Core;
using static VPet_Simulator.Core.IGraph;
using static VPet_Simulator.Core.Picture;

namespace VPet.Live2DAnimation
{
    /// <summary>
    /// Live2D动画 动作文件
    /// </summary>
    public class Live2DMotionAnimation : AILive2DAnimation
    {
        public static void LoadGraph(GraphCore graph, FileSystemInfo path, ILine info)
        {
            if (!(path is FileInfo f) || !f.Name.ToLower().EndsWith(".motion3.json", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            bool isLoop = info[(gbol)"loop"];
            string modelname = info[(gstr)"modelname"];
            if (string.IsNullOrWhiteSpace(modelname))
            {
                modelname = path.Name.Split('.')[0];
            }
            graph.AddGraph(new Live2DMotionAnimation(graph, f, new GraphInfo(path, info), modelname, isLoop));
        }
        private GraphCore GraphCore;
        /// <summary>
        /// Json地址
        /// </summary>
        public string Path { get; set; }

        public Live2DMotionAnimation(GraphCore graphCore, FileInfo path, GraphInfo graphinfo, string modelname, bool isLoop = false)
        {
            IsLoop = isLoop;
            GraphInfo = graphinfo;
            GraphCore = graphCore;
            Path = path.FullName;
            ModelName = modelname;
        }

        public override bool IsReady => true;

        public new TaskControl Control
        {
            get => ((Live2DModelBaseAnimation)GraphCore.CommConfig["L2D" + ModelName]).Control;
            set => ((Live2DModelBaseAnimation)GraphCore.CommConfig["L2D" + ModelName]).Control = value;
        }

        public override void Run(Decorator parant, Action EndAction = null)
        {
            if (!IsReady || !GraphCore.CommConfig.ContainsKey("L2D" + ModelName))
            {
                EndAction?.Invoke();
                return;
            }
            if (Control?.PlayState == true)
            {//如果当前正在运行,掐断
                Control.Stop();
            }
            var l2b = (Live2DModelBaseAnimation)GraphCore.CommConfig["L2D" + ModelName];
            Live2DWPFModel model = l2b.Model;
            Viewbox viewcontrol = l2b.ViewControl;
            var NEWControl = new TaskControl(EndAction);
            Control = NEWControl;
            parant.Dispatcher.Invoke(() =>
            {
                if (parant.Tag != this)
                {
                    if (!Equals(parant.Tag))
                    {
                        parant.Tag = model;
                        if (viewcontrol.Parent != null)
                        {
                            ((Decorator)viewcontrol.Parent).Child = null;
                        }
                        parant.Child = viewcontrol;
                    }
                    parant.Tag = this;
                }
                model.StartMotion(Path, (x, y) => Run(NEWControl));
            });
        }
        /// <summary>
        /// 通过控制器运行
        /// </summary>
        /// <param name="Control"></param>
        public void Run(TaskControl Control)
        {
            //判断是否要下一步
            switch (Control.Type)
            {
                case TaskControl.ControlType.Stop:
                    Control.EndAction?.Invoke();
                    return;
                case TaskControl.ControlType.Status_Stoped:
                    return;
                case TaskControl.ControlType.Continue:
                    Control.Type = TaskControl.ControlType.Status_Quo;
                    Run(Control);
                    return;
                case TaskControl.ControlType.Status_Quo:
                    if (IsLoop)
                    {
                        Task.Run(() => Run(Control));
                    }
                    else
                    {
                        Control.Type = TaskControl.ControlType.Status_Stoped;
                        Control.EndAction?.Invoke(); //运行结束动画时事件
                    }
                    return;
            }
        }

        public override void Dispose()
        {
            
        }
    }

}

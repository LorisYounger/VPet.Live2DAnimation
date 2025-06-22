
using VPet.Live2DAnimation;
using VPet_Simulator.Core;
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.Live2DAnimation
{
    public class Live2DPlugin : MainPlugin
    {
        public Live2DPlugin(IMainWindow mainwin) : base(mainwin)
        {
            if (!PetLoader.IGraphConvert.TryGetValue("l2dmoc", out _))//避免重复加载
                Program.Main();
        }
        public override void LoadPlugin()
        {

        }
        public override string PluginName => "Live2DAnimation";
        /// <summary>
        /// 设置所有Live2D动画的帧率
        /// </summary>
        /// <param name="framesPerSecond">帧率,默认60</param>
        public void SetAllFramesPerSecond(double framesPerSecond) => Live2DModelBaseAnimation.SetAllFramesPerSecond(MW.Core.Graph, framesPerSecond);
    }

}

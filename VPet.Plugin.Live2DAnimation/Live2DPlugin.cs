
using VPet.Live2DAnimation;
using VPet_Simulator.Core;
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.Live2DAnimation
{
    public class Live2DPlugin : MainPlugin
    {
        public Live2DPlugin(IMainWindow mainwin) : base(mainwin)
        {
            if (!PetLoader.IGraphConvert.TryGetValue("l2dmoc", out _))//�����ظ�����
                Program.Main();
        }
        public override void LoadPlugin()
        {

        }
        public override string PluginName => "Live2DAnimation";
        /// <summary>
        /// ��������Live2D������֡��
        /// </summary>
        /// <param name="framesPerSecond">֡��,Ĭ��60</param>
        public void SetAllFramesPerSecond(double framesPerSecond) => Live2DModelBaseAnimation.SetAllFramesPerSecond(MW.Core.Graph, framesPerSecond);
    }

}

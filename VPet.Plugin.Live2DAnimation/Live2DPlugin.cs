
using VPet.Live2DAnimation;
using VPet_Simulator.Core;
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.Live2DAnimation
{
    public class Live2DPlugin : MainPlugin
    {
        public Live2DPlugin(IMainWindow mainwin) : base(mainwin)
        {
            if (!PetLoader.IGraphConvert.TryGetValue("l2dmoc", out _))//±ÜÃâÖØ¸´¼ÓÔØ
                Program.Main();
        }
        public override void LoadPlugin()
        {

        }
        public override string PluginName => "Live2DAnimation";

    }

}

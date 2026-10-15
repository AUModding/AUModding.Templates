using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace ModTemplate;

[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]
public partial class TemplatePlugin : BasePlugin
{
    public Harmony Harmony { get; } = new(Id);

    public override void Load()
    {
        Harmony.PatchAll();
    }

    public override bool Unload()
    {
        Harmony.UnpatchSelf();
        return base.Unload();
    }
}
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using MiraAPI.Translation;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;

namespace ModTemplate;

[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public partial class TemplatePlugin : BasePlugin, IMiraPlugin
{
    public Harmony Harmony { get; } = new(Id);

    public string OptionsTitleText => "ModTemplate";
    public ConfigFile GetConfigFile() => Config;

    public TemplatePlugin()
    {
        MiraLocaleManager.Register(Id);
    }

    public override void Load()
    {
        Harmony.PatchAll();
        ReactorCredits.Register<TemplatePlugin>(location => location is ReactorCredits.Location.MainMenu);
    }

    public override bool Unload()
    {
        Harmony.UnpatchSelf();
        return base.Unload();
    }
}
using System.ComponentModel;
using Microsoft.VisualStudio.Shell;
using VsLinuxDebugger.Core;

namespace Xeno.VsLinuxDebug.OptionsPages
{
  public partial class OptionsPage : DialogPage
  {
    private const string Experimental = "Warning Experimental";
    private const string RemoteDebugger = "Remote Debugger";
    private const string Scripts = "Pre/Post launch scripts";

    [Category(Experimental)]
    [DisplayName("Debug Display GUI")]
    [Description(
      "Display application on remote machine. This is helpful for debugging " +
      "GUI applications on remote devices.")]
    public bool RemoteDebugDisplayGui { get; set; } = false;

    [Category(RemoteDebugger)]
    [DisplayName("Upload Debug build to folder")]
    [Description("Folder for to transfer files to. For HOME folder, use './VSLinuxDbg' and not '~/VSLinuxDbg'")]
    public string RemoteDeployDebugBasePath { get; set; } = $"./VSLinuxDbg"; // "LinuxDbg"

    [Category(RemoteDebugger)]
    [DisplayName("Upload Release build to folder")]
    [Description("Folder for to transfer files to. For HOME folder, use './VSLinuxRls' and not '~/VSLinuxRls'")]
    public string RemoteDeployReleaseBasePath { get; set; } = $"./VSLinuxRls";
    
    [Category(RemoteDebugger)]
    [DisplayName("Append project name to upload path")]
    [Description("Append project name to upload path")]
    public bool RemoteDebugAppendProjName { get; set; } = false;

    [Category(RemoteDebugger)]
    [DisplayName(".NET executable")]
    [Description("Path of the .NET executable on remote machine. (Samples: `dotnet`, `~/.dotnet/dotnet`)")]
    public string RemoteDotNetPath { get; set; } = Constants.DefaultDotNetPath;

    [Category(RemoteDebugger)]
    [DisplayName("Visual Studio Debugger Path")]
    [Description(
      "Root folder of Visual Studio Debugger. " +
      "(Samples: `~/.vs-debugger/`, `~/.vsdbg`)")]
    public string RemoteVsDbgRootPath { get; set; } = Constants.DefaultVsdbgBasePath;

    [Category(Experimental)]
    [DisplayName("Use Command Line Arguments")]
    [Description(
      "Apply command line arguments from Visual Studio Project Settings. " +
      "(Experimental : Project Settings -> Debugging -> Command Line Arguments)")]
    public bool UseCommandLineArgs { get; set; } = false;

    [Category(Scripts)]
    [DisplayName("Before launch command")]
    [Description(
      "Executes bash command before launching project. To add multiple commands append using '&&&&'. \n" +
      "Example: systemctl stop shell.service &&&& sudo killall -9 dotnet")]
    public string PreLaunchCommand { get; set; } = "systemctl stop shell.service && sudo killall -9 dotnet";

    [Category(Scripts)]
    [DisplayName("Post launch command")]
    [Description(
      "Executes bash command after launching project. To add multiple commands append using '&&&&'. \n" +
      "Example: sleep 10 &&&& systemctl start shell.service")]
    public string PostLaunchCommand { get; set; } = "sleep 10 && systemctl start shell.service";
  }
}

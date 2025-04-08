using System;
using System.Windows;
using VsLinuxDebugger.Core;
using Newtonsoft.Json;
using System.IO;

namespace VsLinuxDebugger.Core
{
  public class UserOptions : BaseViewModel
  {
    public UserOptions()
    {

      Id = Guid.NewGuid().ToString();

      DeleteLaunchJsonAfterBuild = false; 
      HostIp = "127.0.0.1"; 
      HostPort = 22; 
      LocalPLinkPath = ""; 
      LocalSwitchLinuxDbgOutput = false; 
      PreLaunchCommand = DefaultPreDebugScriptWithParameters; 
      PostLaunchCommand = DefaultDebugScriptWithParameters; 
      RemoteDeployDebugBasePath = "./VSLinuxDbg";
      RemoteDeployReleaseBasePath = "./VSLinuxRls";
      RemoteDebugAppendProjName = false;
      LocalVsDbgRootPath = "C:\\works\\vs-debugger\\"; 
      RemoteDotNetPath = Constants.DefaultDotNetPath; 
      RemoteVsDbgBasePath = Constants.DefaultVsdbgBasePath; 
      UserGroupName = "";
      UserName = "raspberry";
      UserPass = "pi"; 
      UserPrivateKeyEnabled = false;
      UserPrivateKeyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh\\id_rsa"); ; 
      UserPrivateKeyPassword = "";
      UseSSHExeEnabled = false;
      PlinkAutoConfirmEnabled = true;
    }

    public string FullDescription
    {
      get
      {
          return $"{UserName}@{HostIp}:{HostPort}";
      }
      set
      {
        NotifyPropertyChanged();
      }
    }

    [JsonIgnore]
    public string SupportedScriptParameters
    {
      get
      {
        return "( ੭ ･ᴗ･ )੭";
      }
    }

    private string _id;
    public string Id { get => _id; set { _id = value; NotifyPropertyChanged(); } }

    private bool _deleteLaunchJsonAfterBuild;
    public bool DeleteLaunchJsonAfterBuild
    {
      get => _deleteLaunchJsonAfterBuild;
      set
      {
        _deleteLaunchJsonAfterBuild = value;
        NotifyPropertyChanged();
      }
    }

    private string _hostIp;
    public string HostIp
    {
      get => _hostIp;
      set
      {
        _hostIp = value;
        NotifyPropertyChanged();
      }
    }

    private int _hostPort;
    public int HostPort
    {
      get => _hostPort;
      set
      {
        _hostPort = value;
        NotifyPropertyChanged();
      }
    }

    private string _localPLinkPath;
    public string LocalPLinkPath
    {
      get => _localPLinkPath;
      set
      {
        _localPLinkPath = value;
        NotifyPropertyChanged();
      }
    }

    private bool _localSwitchLinuxDbgOutput;
    public bool LocalSwitchLinuxDbgOutput
    {
      get => _localSwitchLinuxDbgOutput;
      set
      {
        _localSwitchLinuxDbgOutput = value;
        NotifyPropertyChanged();
      }
    }

    private string _preLaunchCommand;
    public string PreLaunchCommand
    {
      get => _preLaunchCommand;
      set
      {
        _preLaunchCommand = value;
        NotifyPropertyChanged();
      }
    }

    private string _postLaunchCommand;
    public string PostLaunchCommand
    {
      get => _postLaunchCommand;
      set
      {
        _postLaunchCommand = value;
        NotifyPropertyChanged();
      }
    }

    private string _remoteDeployDebugBasePath;
    public string RemoteDeployDebugBasePath
    {
      get => _remoteDeployDebugBasePath;
      set
      {
        _remoteDeployDebugBasePath = value;
        NotifyPropertyChanged();
      }
    }

    private string _remoteDeployReleaseBasePath;
    public string RemoteDeployReleaseBasePath
    {
      get => _remoteDeployReleaseBasePath;
      set
      {
        _remoteDeployReleaseBasePath = value;
        NotifyPropertyChanged();
      }
    }

    private bool _remoteDebugAppendProjName;
    public bool RemoteDebugAppendProjName
    {
      get => _remoteDebugAppendProjName;
      set
      {
        _remoteDebugAppendProjName = value;
        NotifyPropertyChanged();
      }
    }

    private string _localVsDbgRootPath;
    public string LocalVsDbgRootPath
    {
      get => _localVsDbgRootPath;
      set
      {
        _localVsDbgRootPath = value;
        NotifyPropertyChanged();
      }
    }

    private string _remoteDotNetPath;
    public string RemoteDotNetPath
    {
      get => _remoteDotNetPath;
      set
      {
        _remoteDotNetPath = value;
        NotifyPropertyChanged();
      }
    }

    private string _remoteVsDbgBasePath;
    public string RemoteVsDbgBasePath
    {
      get => _remoteVsDbgBasePath;
      set
      {
        _remoteVsDbgBasePath = value;
        NotifyPropertyChanged();
      }
    }

    public string RemoteVsDbgFullPath => LinuxPath.Combine(RemoteVsDbgBasePath, Constants.VS2022, Constants.AppVSDbg);

    private string _userGroupName;
    public string UserGroupName
    {
      get => _userGroupName;
      set
      {
        _userGroupName = value;
        NotifyPropertyChanged();
      }
    }

    private string _userName;
    public string UserName
    {
      get => _userName;
      set
      {
        _userName = value;
        NotifyPropertyChanged();
      }
    }

    private string _userPass;
    public string UserPass
    {
      get => _userPass;
      set
      {
        _userPass = value;
        NotifyPropertyChanged();
      }
    }

    private bool _userPrivateKeyEnabled;
    public bool UserPrivateKeyEnabled
    {
      get => _userPrivateKeyEnabled;
      set
      {
        _userPrivateKeyEnabled = value;
        NotifyPropertyChanged();
      }
    }

    private string _userPrivateKeyPath;
    public string UserPrivateKeyPath
    {
      get => _userPrivateKeyPath;
      set
      {
        _userPrivateKeyPath = value;
        NotifyPropertyChanged();
      }
    }

    private string _userPrivateKeyPassword;
    public string UserPrivateKeyPassword
    {
      get => _userPrivateKeyPassword;
      set
      {
        _userPrivateKeyPassword = value;
        NotifyPropertyChanged();
      }
    }

    private bool _useSSHExeEnabled = false;
    public bool UseSSHExeEnabled
    {
      get => _useSSHExeEnabled;
      set
      {
        _useSSHExeEnabled = value;
        NotifyPropertyChanged();
      }
    }

    private bool _plinkAutoConfirmEnabled = false;
    public bool PlinkAutoConfirmEnabled
    {
      get => _plinkAutoConfirmEnabled;
      set
      {
        _plinkAutoConfirmEnabled = value;
        NotifyPropertyChanged();
      }
    }

    public void SetDefaultPreDebugScript()
    {
      PreLaunchCommand = DefaultPreDebugScriptWithParameters;
    }

    public void SetDefaultDebugScript()
    {
      PostLaunchCommand = DefaultDebugScriptWithParameters;
    }

    private string DefaultPreDebugScriptWithParameters
    {
      get
      {
        return "sudo killall -9 dotnet && systemctl stop shell.service && sudo killall -9 dotnet";
      }
    }

    private string DefaultDebugScriptWithParameters
    {
      get
      {
        return "sleep 10 && systemctl start shell.service";
      }
    }
  }
}

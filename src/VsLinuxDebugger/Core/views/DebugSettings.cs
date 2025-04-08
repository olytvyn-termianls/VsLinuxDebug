using System;
using System.Collections.ObjectModel;
using System.Linq;
using VsLinuxDebugger.Core;

namespace VsLinuxDebugger.Core
{
    public class DebugSettingsModel : BaseViewModel
    {
        private UserSettingsContainer _settingsContainer;

        public DebugSettingsModel()
        { 
            _settingsContainer = UserSettingsManager.Instance.Load();
        }

        public void SaveDebugSettings()
        {
            UserSettingsManager.Instance.Save(_settingsContainer);
        }

        public void LoadFromDebugSettings(string path)
        {
            SettingsContainer = UserSettingsManager.Instance.LoadFromPath(path);
        }

        public void SaveAsDebugSettings(string path)
        {
            UserSettingsManager.Instance.SaveAs(_settingsContainer, path);
        }

        public UserSettingsContainer SettingsContainer
        {
            get
            {
                return _settingsContainer;
            }
            set
            {
                _settingsContainer = value;
                NotifyPropertyChanged();
            }
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: marky.Properties.Settings
// Assembly: marky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEECB73C-7F92-4DF1-8A09-4AD07863D974
// Assembly location: C:\Users\shuvo\Downloads\marky.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace marky.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}

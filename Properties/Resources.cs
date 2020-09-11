// Decompiled with JetBrains decompiler
// Type: marky.Properties.Resources
// Assembly: marky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEECB73C-7F92-4DF1-8A09-4AD07863D974
// Assembly location: C:\Users\shuvo\Downloads\marky.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace marky.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (marky.Properties.Resources.resourceMan == null)
          marky.Properties.Resources.resourceMan = new ResourceManager("marky.Properties.Resources", typeof (marky.Properties.Resources).Assembly);
        return marky.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => marky.Properties.Resources.resourceCulture;
      set => marky.Properties.Resources.resourceCulture = value;
    }
  }
}

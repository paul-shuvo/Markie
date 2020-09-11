// Decompiled with JetBrains decompiler
// Type: marky.App
// Assembly: marky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEECB73C-7F92-4DF1-8A09-4AD07863D974
// Assembly location: C:\Users\shuvo\Downloads\marky.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace marky
{
  public class App : Application
  {
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent() => this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}

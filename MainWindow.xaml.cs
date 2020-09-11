

using MarkedNet;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace marky
{
  public partial class MainWindow : Window, IComponentConnector
  {
    private string filePath = "";
    public static string theme = File.ReadAllText("assets/config.txt").Split(':')[1].Trim();
    private string css = File.ReadAllText(string.Format("assets/styles/{0}.css", theme));
        //private string css = File.ReadAllText("assets/default.css");
    //internal MainWindow Marky;
    //internal Menu menu;
    //internal TextBox markdownInput;
    //internal WebBrowser markdownPreview;
    //private bool _contentLoaded;

    public MainWindow()
    {
            this.InitializeComponent();
            //Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            //string[] commandLineArgs = Environment.GetCommandLineArgs();
            //  if (commandLineArgs.Length != 2)
            //    return;

            this.openMDFile("assets/sample.md");
    }

    private void openMDFile(string directory)
    {
      this.filePath = directory;
      this.markdownInput.Text = File.ReadAllText(this.filePath);
    }

    private void previewMarkdown(object sender, TextChangedEventArgs e) => this.markdownPreview.NavigateToString(string.Format("<html>\r\n                <!--[if lt IE 7 ]> <html class=\"ie6\" lang=\"en\"> <![endif]-->\r\n<!--[if IE 7 ]>    <html class=\"ie7\" lang=\"en\"> <![endif]-->\r\n<!--[if IE 8 ]>    <html class=\"ie8\" lang=\"en\"> <![endif]-->\r\n<!--[if IE 9 ]>    <html class=\"ie9\" lang=\"en\"> <![endif]-->\r\n<!--[if (gt IE 9)|!(IE)]><!--> <html lang=\"en\"> <!--<![endif]-->\r\n                <head>\r\n                    <style>\r\n                        {0}\r\n                    </style>\r\n                </head>\r\n                <body>\r\n                    {1}\r\n                </body>\r\n            </html>", (object)this.css, (object) new Marked().Parse(this.markdownInput.Text)));

    private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      this.markdownInput.Text = "";
      this.filePath = "";
    }

    private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.DefaultExt = ".md";
      openFileDialog.Filter = "Markdown Files (*.md)|*.md";
      bool? nullable = openFileDialog.ShowDialog();
      bool flag = true;
      if (nullable.GetValueOrDefault() != flag || !nullable.HasValue)
        return;
      string fileName = openFileDialog.FileName;
      this.filePath = fileName;
      this.markdownInput.Text = File.ReadAllText(fileName);
    }

    private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      if (this.filePath != "")
      {
        File.WriteAllText(this.filePath, this.markdownInput.Text);
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.DefaultExt = ".md";
        saveFileDialog.Filter = "Markdown Files (*.md)|*.md";
        bool? nullable = saveFileDialog.ShowDialog();
        bool flag = true;
        if (nullable.GetValueOrDefault() == flag && nullable.HasValue)
        {
          this.filePath = saveFileDialog.FileName;
          File.WriteAllText(this.filePath, this.markdownInput.Text);
        }
      }
    }

    private void clickedExit(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    private void creditsClicked(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("Developed by : Shuvo Kumar Paul \nEmail : shuvo.k.paul@gmail.com \nVersion : 1.0.0 β", "Credits", MessageBoxButton.OK, MessageBoxImage.Asterisk) != MessageBoxResult.Yes)
        return;
      Application.Current.Shutdown();
    }

    private void mdFileDropped(object sender, DragEventArgs e)
    {
      DataObject data = e.Data as DataObject;
      if (!data.ContainsFileDropList())
        return;
      StringCollection fileDropList = data.GetFileDropList();
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string str in fileDropList)
        stringBuilder.Append(str + "\n");
      string str1 = stringBuilder.ToString();
      if (str1.Substring(0, str1.Length - 1).Split('\n').Length > 1)
      {
        if (MessageBox.Show("Please select a single file.", "error", MessageBoxButton.OK, MessageBoxImage.Hand) == MessageBoxResult.Yes)
          Application.Current.Shutdown();
      }
      else if (!str1.Substring(0, str1.Length - 1).EndsWith(".md"))
      {
        if (MessageBox.Show("Please select a Markdown file.", "error", MessageBoxButton.OK, MessageBoxImage.Hand) == MessageBoxResult.Yes)
          Application.Current.Shutdown();
      }
      else
        this.openMDFile(str1.Substring(0, str1.Length - 1));
    }

    private void TextBox_PreviewDragOver(object sender, DragEventArgs e) => e.Handled = true;

    //[DebuggerNonUserCode]
    //[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    //public void InitializeComponent()
    //{
    //  if (this._contentLoaded)
    //    return;
    //  this._contentLoaded = true;
    //  Application.LoadComponent((object) this, new Uri("/marky;component/mainwindow.xaml", UriKind.Relative));
    //}

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.Marky = (MainWindow) target;
          break;
        case 2:
          ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.OpenCommandBinding_Executed);
          break;
        case 3:
          ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.SaveCommandBinding_Executed);
          break;
        case 4:
          ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.NewCommandBinding_Executed);
          break;
        case 5:
          this.menu = (Menu) target;
          break;
        case 6:
          ((MenuItem) target).Click += new RoutedEventHandler(this.clickedExit);
          break;
        case 7:
          ((MenuItem) target).Click += new RoutedEventHandler(this.creditsClicked);
          break;
        case 8:
          this.markdownInput = (TextBox) target;
          this.markdownInput.TextChanged += new TextChangedEventHandler(this.previewMarkdown);
          this.markdownInput.Drop += new DragEventHandler(this.mdFileDropped);
          this.markdownInput.PreviewDragOver += new DragEventHandler(this.TextBox_PreviewDragOver);
          break;
        case 9:
          this.markdownPreview = (WebBrowser) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }

    }
}

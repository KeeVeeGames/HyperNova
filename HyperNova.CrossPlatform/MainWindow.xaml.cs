using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Data.Converters;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Native;
using Avalonia.Threading;
using HyperNova.Shared;

namespace HyperNova.CrossPlatform
{
    public class MainWindow : Window
    {
        private readonly GMHyper _gmhyper = new GMHyper();
        public List<Template> Templates { get; }
        private enum Status { Running, Stopped }
        private enum TemplateCommand { Save, Delete }
        private TemplateCommand _templateCommand = TemplateCommand.Save;

        readonly Dispatcher _dispatcher = Dispatcher.UIThread;
        private AutoCompleteBox TextBoxGMHyperLocation => this.FindControl<AutoCompleteBox>("NameOfSomeScrollViewer");
        private Button ButtonBrowseGMHyperLocation => this.FindControl<Button>("ButtonBrowseGMHyperLocation");
        private AutoCompleteBox TextBoxProjectName => this.FindControl<AutoCompleteBox>("TextBoxProjectName");
        private Button ButtonBrowseProjectLocation => this.FindControl<Button>("ButtonBrowseProjectLocation");
        private AutoCompleteBox TextBoxCacheLocation => this.FindControl<AutoCompleteBox>("TextBoxCacheLocation");
        private Button ButtonBrowseCacheLocation => this.FindControl<Button>("ButtonBrowseCacheLocation");
        private ComboBox ComboBoxTemplate => this.FindControl<ComboBox>("ComboBoxTemplate");
        private Button ButtonTemplate => this.FindControl<Button>("ButtonTemplate");
        private TextBlock LabelStatus => this.FindControl<TextBlock>("LabelStatus");
        private Button ButtonProcess => this.FindControl<Button>("ButtonProcess");
        private TextBox Console => this.FindControl<TextBox>("Console");

        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif

            DataContext = this;

            //TextBoxGMHyperLocation.Text = Settings.GMHyperLocation.Load();
            //Templates = Settings.Templates.Load();

            //UIUpdateStatus(Status.Stopped);
            //ComboBoxTemplate.SelectedIndex = 0;

            _gmhyper.ExitedHandler += GMHyperExitedHandler;
            _gmhyper.OutputHandler += GMHyperOutputHandler;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void UIUpdateStatus(Status status)
        {
            Trace.WriteLine("JOPA");
            switch (status)
            {
                case Status.Running:
                    ButtonProcess.Content = "Stop";
                    LabelStatus.Text = "Running";
                    break;

                case Status.Stopped:
                    ButtonProcess.Content = "Start";
                    LabelStatus.Text = "Stopped";
                    Console.Text = "";
                    break;
            }
        }

        private void GMHyperExitedHandler(object sender, EventArgs e)
        {
            _dispatcher.InvokeAsync(() => { UIUpdateStatus(Status.Stopped); });
        }

        private void GMHyperOutputHandler(object sender, DataReceivedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(e.Data))
            //{
            //    Dispatcher.Invoke(() =>
            //    {
            //        Console.AppendText(e.Data + Environment.NewLine);
            //        Console.ScrollToEnd();
            //    });
            //}
        }

        private void TextBoxGMHyperLocation_TextChanged(object sender, EventArgs e)
        {
            //TextBox textBox = sender as TextBox;

            //Settings.GMHyperLocation.Save(textBox.Text);
        }

        private void ButtonBrowseGMHyperLocation_Click(object sender, RoutedEventArgs e)
        {
            _gmhyper.Start("C:\\ProgramData\\GMHyper");
            //VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            //bool? dialogResult = dialog.ShowDialog();
            //if (dialogResult.HasValue && dialogResult.Value)
            //{
            //    TextBoxGMHyperLocation.Text = dialog.SelectedPath;
            //}
        }

        private void TextBoxTemplate_TextChanged(object sender, EventArgs e)
        {
            //TextBox textBox = sender as TextBox;

            //if (textBox.IsFocused)
            //{
            //    ComboBoxTemplate.SelectedIndex = -1;
            //}
        }

        private void ButtonFindLocations_Click(object sender, RoutedEventArgs e)
        {
            //string projectName = TextBoxProjectName.Text;

            //if (projectName != "")
            //{
            //    int length = Math.Min(10, projectName.Length);
            //    string cacheName = projectName.Substring(0, length).Replace(" ", "_");

            //    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //    string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //    string[] projectPath = Directory.GetDirectories($"{documentsPath}\\GameMakerStudio2\\", $"{projectName}*",
            //        SearchOption.AllDirectories);

            //    if (projectPath.Length != 0)
            //    {
            //        TextBoxProjectLocation.Text = projectPath[0];
            //    }

            //    string[] cachePath = Directory.GetDirectories($"{appDataPath}\\GameMakerStudio2\\Cache\\GMS2CACHE\\", $"{cacheName}*",
            //        SearchOption.TopDirectoryOnly);

            //    if (cachePath.Length != 0)
            //    {
            //        TextBoxCacheLocation.Text = cachePath[0];
            //    }
            //}
        }

        private void ButtonBrowseProjectLocation_Click(object sender, RoutedEventArgs e)
        {
            //VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            //bool? dialogResult = dialog.ShowDialog();
            //if (dialogResult.HasValue && dialogResult.Value)
            //{
            //    TextBoxProjectLocation.Text = dialog.SelectedPath;
            //}
        }

        private void ButtonBrowseCacheLocation_Click(object sender, RoutedEventArgs e)
        {
            //VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            //bool? dialogResult = dialog.ShowDialog();
            //if (dialogResult.HasValue && dialogResult.Value)
            //{
            //    TextBoxCacheLocation.Text = dialog.SelectedPath;
            //}
        }

        private void ComboBoxTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox comboBox = sender as ComboBox;

            //if (comboBox.SelectedItem is Template template)
            //{
            //    TextBoxProjectName.Text = template.Name;
            //    TextBoxProjectLocation.Text = template.ProjectLocation;
            //    TextBoxCacheLocation.Text = template.CacheLocation;

            //    Templates.Remove(template);
            //    Templates.Insert(0, template);

            //    ButtonTemplate.Content = "Delete template";
            //    _templateCommand = TemplateCommand.Delete;
            //}
            //else
            //{
            //    ButtonTemplate.Content = "Save template";
            //    _templateCommand = TemplateCommand.Save;
            //}
        }

        private void ButtonTemplate_Click(object sender, RoutedEventArgs e)
        {
            //switch (_templateCommand)
            //{
            //    case TemplateCommand.Delete:
            //        Templates.Remove(ComboBoxTemplate.SelectionBoxItem as Template);
            //        ComboBoxTemplate.Items.Refresh();
            //        ComboBoxTemplate.SelectedIndex = -1;

            //        TextBoxProjectName.Text = "";
            //        TextBoxProjectLocation.Text = "";
            //        TextBoxCacheLocation.Text = "";

            //        Settings.Templates.Save(Templates);

            //        break;

            //    case TemplateCommand.Save:
            //        Templates.Insert(0, new Template(TextBoxProjectName.Text, TextBoxProjectLocation.Text, TextBoxCacheLocation.Text));
            //        ComboBoxTemplate.Items.Refresh();
            //        ComboBoxTemplate.SelectedIndex = 0;

            //        Settings.Templates.Save(Templates);

            //        break;
            //}
        }

        private void ButtonProcess_Click(object sender, RoutedEventArgs e)
        {
            //if (_gmhyper.IsStarted)
            //{
            //    _gmhyper.Close();
            //    UIUpdateStatus(Status.Stopped);
            //}
            //else
            //{
            //    string workingDirectory = TextBoxGMHyperLocation.Text;
            //    try
            //    {
            //        _gmhyper.Start(workingDirectory);
            //        UIUpdateStatus(Status.Running);
            //    }
            //    catch (FileNotFoundException ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (_gmhyper.IsStarted)
            {
                _gmhyper.Close(true);
            }
        }
    }

    public class TextValidConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            foreach (object value in values)
            {
                if (string.IsNullOrEmpty(value as string))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

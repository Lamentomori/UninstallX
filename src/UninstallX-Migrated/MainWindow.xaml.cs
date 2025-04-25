using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UninstallX_Migrated
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<AppEntry> InstalledApps { get; } = new ObservableCollection<AppEntry>();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInstalledApps();
        }

        private void LoadInstalledApps()
        {
            InstalledApps.Clear();

            const string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var key = baseKey.OpenSubKey(uninstallKey))
            {
                LoadAppsFromRegistryKey(key);
            }

            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            using (var key = baseKey.OpenSubKey(uninstallKey))
            {
                LoadAppsFromRegistryKey(key);
            }
        }

        private void LoadAppsFromRegistryKey(RegistryKey key)
        {
            foreach (string subKeyName in key.GetSubKeyNames())
            {
                using (var subKey = key.OpenSubKey(subKeyName))
                {
                    var displayName = subKey.GetValue("DisplayName") as string;
                    var publisher = subKey.GetValue("Publisher") as string;
                    var version = subKey.GetValue("DisplayVersion") as string;
                    var uninstallString = subKey.GetValue("UninstallString") as string;

                    if (!string.IsNullOrEmpty(displayName))
                    {
                        Dispatcher.Invoke(() =>
                        {
                            InstalledApps.Add(new AppEntry
                            {
                                DisplayName = displayName,
                                Publisher = publisher,
                                Version = version,
                                UninstallString = uninstallString
                            });
                        });
                    }
                }
            }
        }

        private void UninstallButton_Click(object sender, RoutedEventArgs e)
        {
            if (AppsListView.SelectedItem is AppEntry selectedApp)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/C {selectedApp.UninstallString}",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error uninstalling: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadInstalledApps();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://cyberwatch.cc/");
        }
    }

    public class AppEntry : INotifyPropertyChanged
    {
        public string DisplayName { get; set; }
        public string Publisher { get; set; }
        public string Version { get; set; }
        public string UninstallString { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

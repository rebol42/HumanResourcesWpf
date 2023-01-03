﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HumanResourcesWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var metroWindow = Current.MainWindow as MetroWindow;

            metroWindow.ShowMessageAsync("Nieoczekiwany wyjątek", "Wystapił nieoczekiwany wyjątek." + Environment.NewLine + e.Exception.Message);
            e.Handled = true;
        }
    }
}

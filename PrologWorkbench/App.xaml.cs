﻿/* Copyright © 2010 Richard G. Todd.
 * Licensed under the terms of the Microsoft Public License (Ms-PL).
 */

using System;
using System.Windows;
using System.Windows.Threading;

namespace Prolog.Workbench
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private AppState m_appState;

        #endregion

        #region Constructors

        public App()
        {
            m_appState = new AppState(this);
        }

        #endregion

        #region Public Properties

        public new static App Current
        {
            get { return (App)(Application.Current); }
        }

        public AppState AppState
        {
            get { return m_appState; }
        }

        public string ApplicationTitle
        {
            get { return FindResource("ApplicationTitle") as string; }
        }

        #endregion

        #region Event Handlers

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;

            Program program = null;
            if (e.Args.Length >= 1)
            {
                try
                {
                    program = Program.Load(e.Args[0]);
                }
                catch (Exception ex)
                {
                    CommonExceptionHandlers.HandleException(null, ex);
                }
            }
            if (program == null)
            {
                program = new Program();
            }

            AppState.Program = program;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                Prolog.Workbench.Properties.Settings.Default.Save();
            }
            catch { }
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            CommonExceptionHandlers.HandleException(null, e.Exception);

            e.Handled = true;
        }

        #endregion
    }
}

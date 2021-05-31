﻿/* Copyright © 2010 Richard G. Todd.
 * Licensed under the terms of the Microsoft Public License (Ms-PL).
 */

using System.Windows;
using System.Windows.Controls;

namespace Prolog.Scheduler
{
    /// <summary>
    /// Interaction logic for ScheduleDayControl.xaml
    /// </summary>
    public partial class ScheduleDayControl : UserControl
    {
        #region Constructors

        public ScheduleDayControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Hidden Members

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            if (this.Parent != null)
            {
                this.Width = double.NaN;
                this.Height = double.NaN;
            }
        }

        #endregion
    }
}

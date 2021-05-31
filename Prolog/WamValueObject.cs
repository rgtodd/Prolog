﻿/* Copyright © 2010 Richard G. Todd.
 * Licensed under the terms of the Microsoft Public License (Ms-PL).
 */

using System;

using Prolog.Code;

namespace Prolog
{
    internal sealed class WamValueObject : WamValue
    {
        #region Fields

        private Object m_value;

        #endregion

        #region Constructors

        private WamValueObject(Object value)
        {
            m_value = value;
        }

        public static WamValueObject Create(Object value)
        {
            return new WamValueObject(value);
        }

        public override WamReferenceTarget Clone()
        {
            return new WamValueObject(Object);
        }

        #endregion

        #region Public Properties

        public override object Object
        {
            get { return m_value; }
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}", Object);
        }

        #endregion

        #region Hidden Members

        protected override CodeTerm GetCodeTermBase(WamDeferenceTypes dereferenceType, WamReferenceTargetMapping mapping)
        {
            return new CodeValueObject(Object);
        }

        #endregion
    }
}

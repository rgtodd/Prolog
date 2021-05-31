﻿/* Copyright © 2010 Richard G. Todd.
 * Licensed under the terms of the Microsoft Public License (Ms-PL).
 */

using Prolog.Code;

namespace Prolog.Grammar
{
    // ListTailItem ::= variable
    //              ::= List
    //
    internal sealed class ListTailItem : PrologNonterminal
    {
        #region Fields

        private CodeTerm m_codeTerm;

        #endregion

        #region Rules

        public static void Rule(ListTailItem lhs, Variable variable)
        {
            CodeVariable codeVariable = new CodeVariable(variable.Text);

            lhs.CodeTerm = codeVariable;
        }

        public static void Rule(ListTailItem lhs, List list)
        {
            lhs.CodeTerm = list.CodeList;
        }

        #endregion

        #region Public Properties

        public CodeTerm CodeTerm
        {
            get { return m_codeTerm; }
            private set { m_codeTerm = value; }
        }

        #endregion
    }
}

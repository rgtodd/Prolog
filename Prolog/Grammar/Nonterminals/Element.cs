﻿/* Copyright © 2010 Richard G. Todd.
 * Licensed under the terms of the Microsoft Public License (Ms-PL).
 */

using Prolog.Code;

namespace Prolog.Grammar
{
    // Element ::= Term
    //         ::= Variable
    //         ::= Value
    //         ::= ( BinaryElementExpression700 )
    //         ::= { BinaryElementExpression700 }
    //
    internal sealed class Element : PrologNonterminal
    {
        #region Fields

        private CodeTerm m_codeTerm;

        #endregion

        #region Rules

        public static void Rule(Element lhs, Term term)
        {
            lhs.CodeTerm = term.CodeCompoundTerm;
        }

        public static void Rule(Element lhs, Variable variable)
        {
            lhs.CodeTerm = new CodeVariable(variable.Text);
        }

        public static void Rule(Element lhs, Value value)
        {
            lhs.CodeTerm = value.CodeTerm;
        }

        public static void Rule(Element lhs, OpenParenthesis openParenthesis, BinaryElementExpression700 binaryElementExpression, CloseParenthesis closeParenthesis)
        {
            lhs.CodeTerm = binaryElementExpression.CodeTerm;
        }

        public static void Rule(Element lhs, OpenBrace openBrace, BinaryElementExpression700 binaryElementExpression, CloseBrace closeBrace)
        {
            lhs.CodeTerm = new CodeCompoundTerm(new CodeFunctor("eval", 1), new CodeTerm[] { binaryElementExpression.CodeTerm });
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

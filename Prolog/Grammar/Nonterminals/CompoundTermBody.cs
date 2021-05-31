﻿/* Copyright © 2010 Richard G. Todd.
 * Licensed under the terms of the Microsoft Public License (Ms-PL).
 */

using System.Collections.Generic;

using Prolog.Code;

namespace Prolog.Grammar
{
    // CompoundTermBody ::= CompoundTermMember AdditionalCompoundTermMembers
    //
    internal sealed class CompoundTermBody : PrologNonterminal
    {
        #region Fields

        private List<CodeTerm> m_codeTerms = new List<CodeTerm>();

        #endregion

        #region Rules

        public static void Rule(CompoundTermBody lhs, CompoundTermMember compoundTermMember, AdditionalCompoundTermMembers additionalCompoundTermMembers)
        {
            lhs.CodeTerms.Add(compoundTermMember.CodeTerm);
            lhs.CodeTerms.AddRange(additionalCompoundTermMembers.CodeTerms);
        }

        #endregion

        #region Public Properties

        public List<CodeTerm> CodeTerms
        {
            get { return m_codeTerms; }
        }

        #endregion
    }
}

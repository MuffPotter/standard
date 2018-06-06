using System;
using Standard.Win32;

namespace Standard.Security.Privileges
{
    /// <summary>Access rights for access tokens.</summary>
    [Flags]
    public enum TokenAccessRights
    {
        /// <summary>Right to attach a primary token to a process.</summary>
        AssignPrimary = 0,

        /// <summary>Right to duplicate an access token.</summary>
        Duplicate = 1,

        /// <summary>Right to attach an impersonation access token to a process.</summary>
        Impersonate = 4,

        /// <summary>Right to query an access token.</summary>
        Query = 8,

        /// <summary>Right to query the source of an access token.</summary>
        QuerySource = 16,

        /// <summary>Right to enable or disable the privileges in an access token.</summary>
        AdjustPrivileges = 32,

        /// <summary>Right to adjust the attributes of the groups in an access token.</summary>
        AdjustGroups = 64,

        /// <summary>Right to change the default owner, primary group, or DACL of an access token.</summary>
        AdjustDefault = 128,

        /// <summary>Right to adjust the session ID of an access token.</summary>
        AdjustSessionId = 256,

        /// <summary>Combines all possible access rights for a token.</summary>
        AllAccess = NativeMethods.AccessTypeMasks.StandardRightsRequired | AssignPrimary | Duplicate | Impersonate | Query | QuerySource | AdjustPrivileges | AdjustGroups | AdjustDefault | AdjustSessionId,

        /// <summary>Combines the standard rights required to read with <see cref="Query"/>.</summary>
        Read = NativeMethods.AccessTypeMasks.StandardRightsRead | Query,

        /// <summary>Combines the standard rights required to write with <see cref="AdjustDefault"/>, <see cref="AdjustGroups"/> and <see cref="AdjustPrivileges"/>.</summary>
        Write = NativeMethods.AccessTypeMasks.StandardRightsWrite | AdjustPrivileges | AdjustGroups | AdjustDefault,

        /// <summary>Combines the standard rights required to execute with <see cref="Impersonate"/>.</summary>
        Execute = NativeMethods.AccessTypeMasks.StandardRightsExecute | Impersonate
    }
}

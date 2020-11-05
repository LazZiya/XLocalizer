using System;

namespace XLocalizer.Identity
{
    /// <summary>
    /// This class is deprected. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/identity-errors.md">Localizing Identity Errors</a>
    /// </summary>
    [Obsolete("This class is deprected. See https://docs.ziyad.info/en/XLocalizer/v1.0/identity-errors.md")]
    public interface IIdentityErrorMessagesProvider
    {
        /// <summary>
        /// "Email '{0}' is already taken."
        /// </summary>
        string DuplicateEmail { get; }

        /// <summary>
        /// "User name '{0}' is already taken."
        /// </summary>
        string DuplicateUserName { get; }

        /// <summary>
        /// "Email '{0}' is invalid."
        /// </summary>
        string InvalidEmail { get; }

        /// <summary>
        /// "Role name '{0}' is already taken."
        /// </summary>
        string DuplicateRoleName { get; }

        /// <summary>
        /// "Role name '{0}' is invalid."
        /// </summary>
        string InvalidRoleName { get; }

        /// <summary>
        /// "Invalid token."
        /// </summary>
        string InvalidToken { get; }

        /// <summary>
        /// "User name '{0}' is invalid, can only contain letters or digits."
        /// </summary>
        string InvalidUserName { get; }

        /// <summary>
        /// "A user with this login already exists."
        /// </summary>
        string LoginAlreadyAssociated { get; }

        /// <summary>
        /// "Incorrect password."
        /// </summary>
        string PasswordMismatch { get; }

        /// <summary>
        /// "Passwords must have at least one digit ('0'-'9')."
        /// </summary>
        string PasswordRequiresDigit { get; }

        /// <summary>
        /// "Passwords must have at least one lowercase ('a'-'z')."
        /// </summary>
        string PasswordRequiresLower { get; }

        /// <summary>
        /// "Passwords must have at least one non alphanumeric character."
        /// </summary>
        string PasswordRequiresNonAlphanumeric { get; }

        /// <summary>
        /// "Passwords must use at least {0} different characters."
        /// </summary>
        string PasswordRequiresUniqueChars { get; }

        /// <summary>
        /// "Passwords must have at least one uppercase ('A'-'Z')."
        /// </summary>
        string PasswordRequiresUpper { get; }

        /// <summary>
        /// "Passwords must be at least {0} characters."
        /// </summary>
        string PasswordTooShort { get; }

        /// <summary>
        /// "User already has a password set."
        /// </summary>
        string UserAlreadyHasPassword { get; }

        /// <summary>
        /// "User already in role '{0}'."
        /// </summary>
        string UserAlreadyInRole { get; }

        /// <summary>
        /// "User is not in role '{0}'."
        /// </summary>
        string UserNotInRole { get; }

        /// <summary>
        /// "Lockout is not enabled for this user."
        /// </summary>
        string UserLockoutNotEnabled { get; }

        /// <summary>
        /// "Recovery code redemption failed."
        /// </summary>
        string RecoveryCodeRedemptionFailed { get; }

        /// <summary>
        /// "Optimistic concurrency failure, object has been modified."
        /// </summary>
        string ConcurrencyFailure { get; }

        /// <summary>
        /// "An unknown failure has occurred."
        /// </summary>
        string DefaultError { get; }
    }
}

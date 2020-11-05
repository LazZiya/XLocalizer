using System;

namespace XLocalizer.Identity
{
    /// <summary>
    /// This class is deprected. See <a href="https://docs.ziyad.info/en/XLocalizer/v1.0/identity-errors.md">Localizing Identity Errors</a>
    /// </summary>
    [Obsolete("This class is deprected. See https://docs.ziyad.info/en/XLocalizer/v1.0/identity-errors.md")]
    public class DefaultIdentityErrorsProvider : IIdentityErrorMessagesProvider
    {
        string IIdentityErrorMessagesProvider.DuplicateEmail => "Email '{0}' is already taken.";

        string IIdentityErrorMessagesProvider.DuplicateUserName => "User name '{0}' is already taken.";

        string IIdentityErrorMessagesProvider.InvalidEmail => "Email '{0}' is invalid.";

        string IIdentityErrorMessagesProvider.DuplicateRoleName => "Role name '{0}' is already taken.";

        string IIdentityErrorMessagesProvider.InvalidRoleName => "Role name '{0}' is invalid.";

        string IIdentityErrorMessagesProvider.InvalidToken => "Invalid token.";

        string IIdentityErrorMessagesProvider.InvalidUserName => "User name '{0}' is invalid, can only contain letters or digits.";

        string IIdentityErrorMessagesProvider.LoginAlreadyAssociated => "A user with this login already exists.";

        string IIdentityErrorMessagesProvider.PasswordMismatch => "Incorrect password.";

        string IIdentityErrorMessagesProvider.PasswordRequiresDigit => "Passwords must have at least one digit ('0'-'9').";

        string IIdentityErrorMessagesProvider.PasswordRequiresLower => "Passwords must have at least one lowercase ('a'-'z').";

        string IIdentityErrorMessagesProvider.PasswordRequiresNonAlphanumeric => "Passwords must have at least one non alphanumeric character.";

        string IIdentityErrorMessagesProvider.PasswordRequiresUniqueChars => "Passwords must use at least {0} different characters.";

        string IIdentityErrorMessagesProvider.PasswordRequiresUpper => "Passwords must have at least one uppercase ('A'-'Z').";

        string IIdentityErrorMessagesProvider.PasswordTooShort => "Passwords must be at least {0} characters.";

        string IIdentityErrorMessagesProvider.UserAlreadyHasPassword => "User already has a password set.";

        string IIdentityErrorMessagesProvider.UserAlreadyInRole => "User already in role '{0}'.";

        string IIdentityErrorMessagesProvider.UserNotInRole => "User is not in role '{0}'.";

        string IIdentityErrorMessagesProvider.UserLockoutNotEnabled => "Lockout is not enabled for this user.";

        string IIdentityErrorMessagesProvider.RecoveryCodeRedemptionFailed => "Recovery code redemption failed.";

        string IIdentityErrorMessagesProvider.ConcurrencyFailure => "Optimistic concurrency failure, object has been modified.";

        string IIdentityErrorMessagesProvider.DefaultError => "An unknown failure has occurred.";
    }
}

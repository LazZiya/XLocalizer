using System.ComponentModel.DataAnnotations;

namespace XLocalizer.ErrorMessages
{
    /// <summary>
    /// Provides all identity describer error messages in one single class. 
    /// This class is part of XLocalizer members, so it can be overridden in appsettings.json or antother file.
    /// Overriding values in appsettings.jso allows to customize the error messages, 
    /// or to provide default error messages in a different culture other than en
    /// </summary>
    public class IdentityErrors
    {
        /// <summary>
        /// "Email '{0}' is already taken."
        /// </summary>
        [Required]
        public string DuplicateEmail { get; set; } = "Email '{0}' is already taken.";

        /// <summary>
        /// "User name '{0}' is already taken."
        /// </summary>
        [Required]
        public string DuplicateUserName { get; set; } = "User name '{0}' is already taken.";

        /// <summary>
        /// "Email '{0}' is invalid."
        /// </summary>
        [Required]
        public string InvalidEmail { get; set; } = "Email '{0}' is invalid.";

        /// <summary>
        /// "Role name '{0}' is already taken."
        /// </summary>
        [Required]
        public string DuplicateRoleName { get; set; } = "Role name '{0}' is already taken.";

        /// <summary>
        /// "Role name '{0}' is invalid."
        /// </summary>
        [Required]
        public string InvalidRoleName { get; set; } = "Role name '{0}' is invalid.";

        /// <summary>
        /// "Invalid token."
        /// </summary>
        [Required]
        public string InvalidToken { get; set; } = "Invalid token.";

        /// <summary>
        /// "User name '{0}' is invalid, can only contain letters or digits."
        /// </summary>
        [Required]
        public string InvalidUserName { get; set; } = "User name '{0}' is invalid, can only contain letters or digits.";

        /// <summary>
        /// "A user with this login already exists."
        /// </summary>
        [Required]
        public string LoginAlreadyAssociated { get; set; } = "A user with this login already exists.";

        /// <summary>
        /// "Incorrect password."
        /// </summary>
        [Required]
        public string PasswordMismatch { get; set; } = "Incorrect password.";

        /// <summary>
        /// "Passwords must have at least one digit ('0'-'9')."
        /// </summary>
        [Required]
        public string PasswordRequiresDigit { get; set; } = "Passwords must have at least one digit ('0'-'9').";

        /// <summary>
        /// "Passwords must have at least one lowercase ('a'-'z')."
        /// </summary>
        [Required]
        public string PasswordRequiresLower { get; set; } = "Passwords must have at least one lowercase ('a'-'z').";

        /// <summary>
        /// "Passwords must have at least one non alphanumeric character."
        /// </summary>
        [Required]
        public string PasswordRequiresNonAlphanumeric { get; set; } = "Passwords must have at least one non alphanumeric character.";

        /// <summary>
        /// "Passwords must use at least {0} different characters."
        /// </summary>
        [Required]
        public string PasswordRequiresUniqueChars { get; set; } = "Passwords must use at least {0} different characters.";

        /// <summary>
        /// "Passwords must have at least one uppercase ('A'-'Z')."
        /// </summary>
        [Required]
        public string PasswordRequiresUpper { get; set; } = "Passwords must have at least one uppercase ('A'-'Z').";

        /// <summary>
        /// "Passwords must be at least {0} characters."
        /// </summary>
        [Required]
        public string PasswordTooShort { get; set; } = "Passwords must be at least {0} characters.";

        /// <summary>
        /// "User already has a password set."
        /// </summary>
        [Required]
        public string UserAlreadyHasPassword { get; set; } = "User already has a password set.";

        /// <summary>
        /// "User already in role '{0}'."
        /// </summary>
        [Required]
        public string UserAlreadyInRole { get; set; } = "User already in role '{0}'.";

        /// <summary>
        /// "User is not in role '{0}'."
        /// </summary>
        [Required]
        public string UserNotInRole { get; set; } = "User is not in role '{0}'.";

        /// <summary>
        /// "Lockout is not enabled for this user."
        /// </summary>
        [Required]
        public string UserLockoutNotEnabled { get; set; } = "Lockout is not enabled for this user.";

        /// <summary>
        /// "Recovery code redemption failed."
        /// </summary>
        [Required]
        public string RecoveryCodeRedemptionFailed { get; set; } = "Recovery code redemption failed.";

        /// <summary>
        /// "Optimistic concurrency failure, object has been modified."
        /// </summary>
        [Required]
        public string ConcurrencyFailure { get; set; } = "Optimistic concurrency failure, object has been modified.";

        /// <summary>
        /// "An unknown failure has occurred."
        /// </summary>
        [Required]
        public string DefaultError { get; set; } = "An unknown failure has occurred.";
    }
}

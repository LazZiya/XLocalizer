using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace XLocalizer.Identity
{
    /// <summary>
    /// Identity describer errors localizer.
    /// Original mesages obtained from: https://github.com/aspnet/AspNetCore/blob/master/src/Identity/Extensions.Core/src/Resources.resx
    /// </summary>
    public class IdentityErrorsLocalizer : IdentityErrorDescriber 
    {
        private readonly IStringLocalizer Localizer;
                
        /// <summary>
        /// Initialize identity erroors localization based on DB locailzer
        /// </summary>
        /// <param name="localizer"></param>
        public IdentityErrorsLocalizer(IStringLocalizer localizer)
        {
            Localizer = localizer;
        }

        private IdentityError LocalizedIdentityError(string code, params object[] args)
        {
            var msg = Localizer[code, args];

            return new IdentityError { Code = code, Description = msg };
        }

        /// <summary>
        /// "Email '{0}' is already taken."
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError DuplicateEmail(string email) 
            => LocalizedIdentityError("Email '{0}' is already taken.", email);

        /// <summary>
        /// "User name '{0}' is already taken."
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError DuplicateUserName(string userName) 
            => LocalizedIdentityError("User name '{0}' is already taken.", userName);

        /// <summary>
        /// "Email '{0}' is invalid."
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError InvalidEmail(string email) 
            => LocalizedIdentityError("Email '{0}' is invalid.", email);

        /// <summary>
        /// "Role name '{0}' is already taken."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError DuplicateRoleName(string role) 
            => LocalizedIdentityError("Role name '{0}' is already taken.", role);

        /// <summary>
        /// "Role name '{0}' is invalid."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError InvalidRoleName(string role) 
            => LocalizedIdentityError("Role name '{0}' is invalid.", role);

        /// <summary>
        /// "Invalid token."
        /// </summary>
        /// <returns></returns>
        public override IdentityError InvalidToken() 
            => LocalizedIdentityError("Invalid token.");

        /// <summary>
        /// "User name '{0}' is invalid, can only contain letters or digits."
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError InvalidUserName(string userName) 
            => LocalizedIdentityError("User name '{0}' is invalid, can only contain letters or digits.", userName);

        /// <summary>
        /// "A user with this login already exists."
        /// </summary>
        /// <returns></returns>
        public override IdentityError LoginAlreadyAssociated() 
            => LocalizedIdentityError("A user with this login already exists.");

        /// <summary>
        /// "Incorrect password."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordMismatch() 
            => LocalizedIdentityError("Incorrect password.");

        /// <summary>
        /// "Passwords must have at least one digit ('0'-'9')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresDigit() 
            => LocalizedIdentityError("Passwords must have at least one digit ('0'-'9').");

        /// <summary>
        /// "Passwords must have at least one lowercase ('a'-'z')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresLower() 
            => LocalizedIdentityError("Passwords must have at least one lowercase ('a'-'z').");

        /// <summary>
        /// "Passwords must have at least one non alphanumeric character."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresNonAlphanumeric() 
            => LocalizedIdentityError("Passwords must have at least one non alphanumeric character.");

        /// <summary>
        /// "Passwords must use at least {0} different characters."
        /// </summary>
        /// <param name="uniqueChars"></param>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars) 
            => LocalizedIdentityError("Passwords must use at least {0} different characters.", uniqueChars);

        /// <summary>
        /// "Passwords must have at least one uppercase ('A'-'Z')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUpper() 
            => LocalizedIdentityError("Passwords must have at least one uppercase ('A'-'Z').");

        /// <summary>
        /// "Passwords must be at least {0} characters."
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override IdentityError PasswordTooShort(int length) 
            => LocalizedIdentityError("Passwords must be at least {0} characters.", length);

        /// <summary>
        /// "User already has a password set."
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserAlreadyHasPassword() 
            => LocalizedIdentityError("User already has a password set.");

        /// <summary>
        /// "User already in role '{0}'."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserAlreadyInRole(string role) 
            => LocalizedIdentityError("User already in role '{0}'.", role);

        /// <summary>
        /// "User is not in role '{0}'."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserNotInRole(string role) 
            => LocalizedIdentityError("User is not in role '{0}'.", role);

        /// <summary>
        /// "Lockout is not enabled for this user."
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserLockoutNotEnabled() 
            => LocalizedIdentityError("Lockout is not enabled for this user.");

        /// <summary>
        /// "Recovery code redemption failed."
        /// </summary>
        /// <returns></returns>
        public override IdentityError RecoveryCodeRedemptionFailed() 
            => LocalizedIdentityError("Recovery code redemption failed.");

        /// <summary>
        /// "Optimistic concurrency failure, object has been modified."
        /// </summary>
        /// <returns></returns>
        public override IdentityError ConcurrencyFailure() 
            => LocalizedIdentityError("Optimistic concurrency failure, object has been modified.");

        /// <summary>
        /// "An unknown failure has occurred."
        /// </summary>
        /// <returns></returns>
        public override IdentityError DefaultError() 
            => LocalizedIdentityError("An unknown failure has occurred.");
    }
}

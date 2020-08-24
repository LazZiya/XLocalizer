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
        private readonly IStringLocalizer _localizer;
        private readonly IIdentityErrorMessagesProvider _errProvider;
                
        /// <summary>
        /// Initialize identity erroors localization based on DB locailzer
        /// </summary>
        /// <param name="localizer"></param>
        /// <param name="errProvider"></param>
        public IdentityErrorsLocalizer(IStringLocalizer localizer, IIdentityErrorMessagesProvider errProvider)
        {
            _localizer = localizer;
            _errProvider = errProvider;
        }

        private IdentityError LocalizedIdentityError(string code, params object[] args)
        {
            var msg = _localizer[code, args];

            return new IdentityError { Code = code, Description = msg };
        }

        /// <summary>
        /// "Email '{0}' is already taken."
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError DuplicateEmail(string email) 
            => LocalizedIdentityError(_errProvider.DuplicateEmail, email);

        /// <summary>
        /// "User name '{0}' is already taken."
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError DuplicateUserName(string userName) 
            => LocalizedIdentityError(_errProvider.DuplicateUserName, userName);

        /// <summary>
        /// "Email '{0}' is invalid."
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError InvalidEmail(string email) 
            => LocalizedIdentityError(_errProvider.InvalidEmail, email);

        /// <summary>
        /// "Role name '{0}' is already taken."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError DuplicateRoleName(string role) 
            => LocalizedIdentityError(_errProvider.DuplicateRoleName, role);

        /// <summary>
        /// "Role name '{0}' is invalid."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError InvalidRoleName(string role) 
            => LocalizedIdentityError(_errProvider.InvalidRoleName, role);

        /// <summary>
        /// "Invalid token."
        /// </summary>
        /// <returns></returns>
        public override IdentityError InvalidToken() 
            => LocalizedIdentityError(_errProvider.InvalidToken);

        /// <summary>
        /// "User name '{0}' is invalid, can only contain letters or digits."
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError InvalidUserName(string userName) 
            => LocalizedIdentityError(_errProvider.InvalidUserName, userName);

        /// <summary>
        /// "A user with this login already exists."
        /// </summary>
        /// <returns></returns>
        public override IdentityError LoginAlreadyAssociated() 
            => LocalizedIdentityError(_errProvider.LoginAlreadyAssociated);

        /// <summary>
        /// "Incorrect password."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordMismatch() 
            => LocalizedIdentityError(_errProvider.PasswordMismatch);

        /// <summary>
        /// "Passwords must have at least one digit ('0'-'9')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresDigit() 
            => LocalizedIdentityError(_errProvider.PasswordRequiresDigit);

        /// <summary>
        /// "Passwords must have at least one lowercase ('a'-'z')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresLower() 
            => LocalizedIdentityError(_errProvider.PasswordRequiresLower);

        /// <summary>
        /// "Passwords must have at least one non alphanumeric character."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresNonAlphanumeric() 
            => LocalizedIdentityError(_errProvider.PasswordRequiresNonAlphanumeric);

        /// <summary>
        /// "Passwords must use at least {0} different characters."
        /// </summary>
        /// <param name="uniqueChars"></param>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars) 
            => LocalizedIdentityError(_errProvider.PasswordRequiresUniqueChars, uniqueChars);

        /// <summary>
        /// "Passwords must have at least one uppercase ('A'-'Z')."
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUpper() 
            => LocalizedIdentityError(_errProvider.PasswordRequiresUpper);

        /// <summary>
        /// "Passwords must be at least {0} characters."
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override IdentityError PasswordTooShort(int length) 
            => LocalizedIdentityError(_errProvider.PasswordTooShort, length);

        /// <summary>
        /// "User already has a password set."
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserAlreadyHasPassword() 
            => LocalizedIdentityError(_errProvider.UserAlreadyHasPassword);

        /// <summary>
        /// "User already in role '{0}'."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserAlreadyInRole(string role) 
            => LocalizedIdentityError(_errProvider.UserAlreadyInRole, role);

        /// <summary>
        /// "User is not in role '{0}'."
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserNotInRole(string role) 
            => LocalizedIdentityError(_errProvider.UserNotInRole, role);

        /// <summary>
        /// "Lockout is not enabled for this user."
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserLockoutNotEnabled() 
            => LocalizedIdentityError(_errProvider.UserLockoutNotEnabled);

        /// <summary>
        /// "Recovery code redemption failed."
        /// </summary>
        /// <returns></returns>
        public override IdentityError RecoveryCodeRedemptionFailed() 
            => LocalizedIdentityError(_errProvider.RecoveryCodeRedemptionFailed);

        /// <summary>
        /// "Optimistic concurrency failure, object has been modified."
        /// </summary>
        /// <returns></returns>
        public override IdentityError ConcurrencyFailure() 
            => LocalizedIdentityError(_errProvider.ConcurrencyFailure);

        /// <summary>
        /// "An unknown failure has occurred."
        /// </summary>
        /// <returns></returns>
        public override IdentityError DefaultError() 
            => LocalizedIdentityError(_errProvider.DefaultError);
    }
}

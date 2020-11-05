using System.ComponentModel.DataAnnotations;

namespace XLocalizer.ErrorMessages
{
    /// <summary>
    /// Provides all validiation error messages in one single class. 
    /// This class is part of XLocalizer members, so it can be overridden in appsettings.json or antother file.
    /// Overriding values in appsettings.jso allows to customize the error messages, 
    /// or to provide default error messages in a different culture other than en
    /// Original messages obtained from <a href="https://github.com/dotnet/corefx/blob/master/src/System.ComponentModel.Annotations/src/Resources/Strings.resx"/>
    /// </summary>
    public class ValidationErrors
    {
        /// <summary>
        /// "'{0}' and '{1}' do not match."
        /// </summary>
        [Required]
        public string CompareAttribute_MustMatch { get; set; } = "'{0}' and '{1}' do not match.";

        /// <summary>
        /// "The {0} field is not a valid credit card number."
        /// </summary>
        [Required]
        public string CreditCardAttribute_Invalid { get; set; } = "The {0} field is not a valid credit card number.";

        /// <summary>
        /// "{0} is not valid."
        /// </summary>
        [Required]
        public string CustomValidationAttribute_ValidationError { get; set; } = "{0} is not valid.";

        /// <summary>
        /// "The custom DataType string cannot be null or empty."
        /// </summary>
        [Required]
        public string DataTypeAttribute_EmptyDataTypeString { get; set; } = "The custom DataType string cannot be null or empty.";

        /// <summary>
        /// "The {0} field is not a valid e-mail address."
        /// </summary>
        [Required]
        public string EmailAddressAttribute_Invalid { get; set; } = "The {0} field is not a valid e-mail address.";

        /// <summary>
        /// "The {0} field only accepts files with the following extensions: {1}"
        /// </summary>
        [Required]
        public string FileExtensionsAttribute_Invalid { get; set; } = "The {0} field only accepts files with the following extensions: {1}";

        /// <summary>
        /// "The field {0} must be a string or array type with a maximum length of '{1}'."
        /// </summary>
        [Required]
        public string MaxLengthAttribute_ValidationError { get; set; } = "The field {0} must be a string or array type with a maximum length of '{1}'.";

        /// <summary>
        /// "The field {0} must be a string or array type with a minimum length of '{1}'."
        /// </summary>
        [Required]
        public string MinLengthAttribute_ValidationError { get; set; } = "The field {0} must be a string or array type with a minimum length of '{1}'.";

        /// <summary>
        /// "The {0} field is not a valid phone number."
        /// </summary>
        [Required]
        public string PhoneAttribute_Invalid { get; set; } = "The {0} field is not a valid phone number.";

        /// <summary>
        /// "The field {0} must be between {1} and {2}."
        /// </summary>
        [Required]
        public string RangeAttribute_ValidationError { get; set; } = "The field {0} must be between {1} and {2}.";

        /// <summary>
        /// "The field {0} must match the regular expression '{1}'."
        /// </summary>
        [Required]
        public string RegexAttribute_ValidationError { get; set; } = "The field {0} must match the regular expression '{1}'.";

        /// <summary>
        /// "The {0} field is required."
        /// </summary>
        [Required]
        public string RequiredAttribute_ValidationError { get; set; } = "The {0} field is required.";

        /// <summary>
        /// "The field {0} must be a string with a maximum length of {1}."
        /// </summary>
        [Required]
        public string StringLengthAttribute_ValidationError { get; set; } = "The field {0} must be a string with a maximum length of {1}.";

        /// <summary>
        /// "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}."
        /// </summary>
        [Required]
        public string StringLengthAttribute_ValidationErrorIncludingMinimum { get; set; } = "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.";

        /// <summary>
        /// "The {0} field is not a valid fully-qualified http, https, or ftp URL."
        /// </summary>
        [Required]
        public string UrlAttribute_Invalid { get; set; } = "The {0} field is not a valid fully-qualified http, https, or ftp URL.";

        /// <summary>
        /// "The field {0} is invalid."
        /// </summary>
        [Required]
        public string ValidationAttribute_ValidationError { get; set; } = "The field {0} is invalid.";
    }
}

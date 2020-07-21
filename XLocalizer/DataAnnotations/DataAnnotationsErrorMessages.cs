namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Original messages obtained from <a href="https://github.com/dotnet/corefx/blob/master/src/System.ComponentModel.Annotations/src/Resources/Strings.resx"/>
    /// </summary>
    public struct DataAnnotationsErrorMessages
    {
        /// <summary>
        /// The argument '{0}' cannot be null, empty or contain only whitespace.
        /// </summary>
        public const string ArgumentIsNullOrWhitespace = "The argument '{0}' cannot be null, empty or contain only whitespace.";

        /// <summary>
        /// The associated metadata type for type '{0}' contains the following unknown properties or fields: {1}. Please make sure that the names of these members match the names of the properties on the main type.
        /// </summary>
        public const string AssociatedMetadataTypeTypeDescriptor_MetadataTypeContainsUnknownProperties = "The associated metadata type for type '{0}' contains the following unknown properties or fields: {1}. Please make sure that the names of these members match the names of the properties on the main type.";

        /// <summary>
        /// The type '{0}' does not contain a public property named '{1}'.
        /// </summary>
        public const string AttributeStore_Unknown_Property = "The type '{0}' does not contain a public property named '{1}'.";

        /// <summary>
        /// The property {0}.{1} could not be found.
        /// </summary>
        public const string Common_PropertyNotFound = "The property {0}.{1} could not be found.";

        /// <summary>
        /// '{0}' and '{1}' do not match.
        /// </summary>
        public const string CompareAttribute_MustMatch = "'{0}' and '{1}' do not match.";

        /// <summary>
        /// Could not find a property named {0}.
        /// </summary>
        public const string CompareAttribute_UnknownProperty = "Could not find a property named {0}.";

        /// <summary>
        /// The {0} field is not a valid credit card number.
        /// </summary>
        public const string CreditCardAttribute_Invalid = "The {0} field is not a valid credit card number.";

        /// <summary>
        /// The CustomValidationAttribute method '{0}' in type '{1}' must return System.ComponentModel.DataAnnotations.ValidationResult.  Use System.ComponentModel.DataAnnotations.ValidationResult.Success to represent success.
        /// </summary>
        public const string CustomValidationAttribute_Method_Must_Return_ValidationResult = "The CustomValidationAttribute method '{0}' in type '{1}' must return System.ComponentModel.DataAnnotations.ValidationResult.  Use System.ComponentModel.DataAnnotations.ValidationResult.Success to represent success.";

        /// <summary>
        /// The CustomValidationAttribute method '{0}' does not exist in type '{1}' or is not public and static.
        /// </summary>
        public const string CustomValidationAttribute_Method_Not_Found = "The CustomValidationAttribute method '{0}' does not exist in type '{1}' or is not public and static.";

        /// <summary>
        /// The CustomValidationAttribute.Method was not specified.
        /// </summary>
        public const string CustomValidationAttribute_Method_Required = "The CustomValidationAttribute.Method was not specified.";

        /// <summary>
        /// The CustomValidationAttribute method '{0}' in type '{1}' must match the expected signature: public static ValidationResult {0}(object value, ValidationContext context).  The value can be strongly typed.  The ValidationContext parameter is optional.
        /// </summary>
        public const string CustomValidationAttribute_Method_Signature = "The CustomValidationAttribute method '{0}' in type '{1}' must match the expected signature: public static ValidationResult {0}(object value, ValidationContext context).  The value can be strongly typed.  The ValidationContext parameter is optional.";

        /// <summary>
        /// Could not convert the value of type '{0}' to '{1}' as expected by method {2}.{3}.
        /// </summary>
        public const string CustomValidationAttribute_Type_Conversion_Failed = "Could not convert the value of type '{0}' to '{1}' as expected by method {2}.{3}.";

        /// <summary>
        /// The custom validation type '{0}' must be public.
        /// </summary>
        public const string CustomValidationAttribute_Type_Must_Be_Public = "The custom validation type '{0}' must be public.";

        /// <summary>
        /// {0} is not valid.
        /// </summary>
        public const string CustomValidationAttribute_ValidationError = "{0} is not valid.";

        /// <summary>
        /// The CustomValidationAttribute.ValidatorType was not specified.
        /// </summary>
        public const string CustomValidationAttribute_ValidatorType_Required = "The CustomValidationAttribute.ValidatorType was not specified.";

        /// <summary>
        /// The custom DataType string cannot be null or empty.
        /// </summary>
        public const string DataTypeAttribute_EmptyDataTypeString = "The custom DataType string cannot be null or empty.";

        /// <summary>
        /// The {0} property has not been set.  Use the {1} method to get the value.
        /// </summary>
        public const string DisplayAttribute_PropertyNotSet = "The {0} property has not been set.  Use the {1} method to get the value.";

        /// <summary>
        /// The {0} field is not a valid e-mail address.
        /// </summary>
        public const string EmailAddressAttribute_Invalid = "The {0} field is not a valid e-mail address.";

        /// <summary>
        /// The type provided for EnumDataTypeAttribute cannot be null.
        /// </summary>
        public const string EnumDataTypeAttribute_TypeCannotBeNull = "The type provided for EnumDataTypeAttribute cannot be null.";

        /// <summary>
        /// The type '{0}' needs to represent an enumeration type.
        /// </summary>
        public const string EnumDataTypeAttribute_TypeNeedsToBeAnEnum = "The type '{0}' needs to represent an enumeration type.";

        /// <summary>
        /// The {0} field only accepts files with the following extensions: {1}
        /// </summary>
        public const string FileExtensionsAttribute_Invalid = "The {0} field only accepts files with the following extensions: {1}";

        /// <summary>
        /// The field of type {0} must be a string, array or ICollection type.
        /// </summary>
        public const string LengthAttribute_InvalidValueType = "The field of type {0} must be a string, array or ICollection type.";

        /// <summary>
        /// Cannot retrieve property '{0}' because localization failed.  Type '{1}' is not public or does not contain a public static string property with the name '{2}'.
        /// </summary>
        public const string LocalizableString_LocalizationFailed = "Cannot retrieve property '{0}' because localization failed.  Type '{1}' is not public or does not contain a public static string property with the name '{2}'.";

        /// <summary>
        /// MaxLengthAttribute must have a Length value that is greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length.
        /// </summary>
        public const string MaxLengthAttribute_InvalidMaxLength = "MaxLengthAttribute must have a Length value that is greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length.";

        /// <summary>
        /// The field {0} must be a string or array type with a maximum length of '{1}'.
        /// </summary>
        public const string MaxLengthAttribute_ValidationError = "The field {0} must be a string or array type with a maximum length of '{1}'.";

        /// <summary>
        /// MetadataClassType cannot be null.
        /// </summary>
        public const string MetadataTypeAttribute_TypeCannotBeNull = "MetadataClassType cannot be null.";

        /// <summary>
        /// MinLengthAttribute must have a Length value that is zero or greater.
        /// </summary>
        public const string MinLengthAttribute_InvalidMinLength = "MinLengthAttribute must have a Length value that is zero or greater.";

        /// <summary>
        /// The field {0} must be a string or array type with a minimum length of '{1}'.
        /// </summary>
        public const string MinLengthAttribute_ValidationError = "The field {0} must be a string or array type with a minimum length of '{1}'.";

        /// <summary>
        /// The {0} field is not a valid phone number.
        /// </summary>
        public const string PhoneAttribute_Invalid = "The {0} field is not a valid phone number.";

        /// <summary>
        /// The type {0} must implement {1}.
        /// </summary>
        public const string RangeAttribute_ArbitraryTypeNotIComparable = "The type {0} must implement {1}.";

        /// <summary>
        /// The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.
        /// </summary>
        public const string RangeAttribute_MinGreaterThanMax = "The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.";

        /// <summary>
        /// The minimum and maximum values must be set.
        /// </summary>
        public const string RangeAttribute_Must_Set_Min_And_Max = "The minimum and maximum values must be set.";

        /// <summary>
        /// The OperandType must be set when strings are used for minimum and maximum values.
        /// </summary>
        public const string RangeAttribute_Must_Set_Operand_Type = "The OperandType must be set when strings are used for minimum and maximum values.";

        /// <summary>
        /// The field {0} must be between {1} and {2}.
        /// </summary>
        public const string RangeAttribute_ValidationError = "The field {0} must be between {1} and {2}.";

        /// <summary>
        /// The field {0} must match the regular expression '{1}'.
        /// </summary>
        public const string RegexAttribute_ValidationError = "The field {0} must match the regular expression '{1}'.";

        /// <summary>
        /// The pattern must be set to a valid regular expression.
        /// </summary>
        public const string RegularExpressionAttribute_Empty_Pattern = "The pattern must be set to a valid regular expression.";

        /// <summary>
        /// The {0} field is required.
        /// </summary>
        public const string RequiredAttribute_ValidationError = "The {0} field is required.";

        /// <summary>
        /// The maximum length must be a nonnegative integer.
        /// </summary>
        public const string StringLengthAttribute_InvalidMaxLength = "The maximum length must be a nonnegative integer.";

        /// <summary>
        /// The field {0} must be a string with a maximum length of {1}.
        /// </summary>
        public const string StringLengthAttribute_ValidationError = "The field {0} must be a string with a maximum length of {1}.";

        /// <summary>
        /// The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.
        /// </summary>
        public const string StringLengthAttribute_ValidationErrorIncludingMinimum = "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.";

        /// <summary>
        /// The key parameter at position {0} with value '{1}' is not a string. Every key control parameter must be a string.
        /// </summary>
        public const string UIHintImplementation_ControlParameterKeyIsNotAString = "The key parameter at position {0} with value '{1}' is not a string. Every key control parameter must be a string.";

        /// <summary>
        /// The key parameter at position {0} is null. Every key control parameter must be a string.
        /// </summary>
        public const string UIHintImplementation_ControlParameterKeyIsNull = "The key parameter at position {0} is null. Every key control parameter must be a string.";

        /// <summary>
        /// The key parameter at position {0} with value '{1}' occurs more than once.
        /// </summary>
        public const string UIHintImplementation_ControlParameterKeyOccursMoreThanOnce = "The key parameter at position {0} with value '{1}' occurs more than once.";

        /// <summary>
        /// The number of control parameters must be even.
        /// </summary>
        public const string UIHintImplementation_NeedEvenNumberOfControlParameters = "The number of control parameters must be even.";

        /// <summary>
        /// The {0} field is not a valid fully-qualified http, https, or ftp URL.
        /// </summary>
        public const string UrlAttribute_Invalid = "The {0} field is not a valid fully-qualified http, https, or ftp URL.";

        /// <summary>
        /// Either ErrorMessageString or ErrorMessageResourceName must be set, but not both.
        /// </summary>
        public const string ValidationAttribute_Cannot_Set_ErrorMessage_And_Resource = "Either ErrorMessageString or ErrorMessageResourceName must be set, but not both.";

        /// <summary>
        /// IsValid(object value) has not been implemented by this class.  The preferred entry point is GetValidationResult() and classes should override IsValid(object value, ValidationContext context).
        /// </summary>
        public const string ValidationAttribute_IsValid_NotImplemented = "IsValid(object value) has not been implemented by this class.  The preferred entry point is GetValidationResult() and classes should override IsValid(object value, ValidationContext context).";

        /// <summary>
        /// Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute.
        /// </summary>
        public const string ValidationAttribute_NeedBothResourceTypeAndResourceName = "Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute.";

        /// <summary>
        /// The property '{0}' on resource type '{1}' is not a string type.
        /// </summary>
        public const string ValidationAttribute_ResourcePropertyNotStringType = "The property '{0}' on resource type '{1}' is not a string type.";

        /// <summary>
        /// The resource type '{0}' does not have an accessible static property named '{1}'.
        /// </summary>
        public const string ValidationAttribute_ResourceTypeDoesNotHaveProperty = "The resource type '{0}' does not have an accessible static property named '{1}'.";

        /// <summary>
        /// The field {0} is invalid.
        /// </summary>
        public const string ValidationAttribute_ValidationError = "The field {0} is invalid.";

        /// <summary>
        /// The instance provided must match the ObjectInstance on the ValidationContext supplied.
        /// </summary>
        public const string Validator_InstanceMustMatchValidationContextInstance = "The instance provided must match the ObjectInstance on the ValidationContext supplied.";

        /// <summary>
        /// The value for property '{0}' must be of type '{1}'.
        /// </summary>
        public const string Validator_Property_Value_Wrong_Type = "The value for property '{0}' must be of type '{1}'.";
    }
}

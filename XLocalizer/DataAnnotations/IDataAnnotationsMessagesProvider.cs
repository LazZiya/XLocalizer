namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Interface to provide custom default data annotation error messages.
    /// Messages can be provided in any culture, so user can provide localized error messages here,
    /// but the default request culture in startup must be configured same as messages culture.
    /// </summary>
    public interface IDataAnnotationsMessagesProvider
    {
        /// <summary>
        /// The argument '{0}' cannot be null, empty or contain only whitespace.
        /// </summary>
        string ArgumentIsNullOrWhitespace { get; }

        /// <summary>
        /// The associated metadata type for type '{0}' contains the following unknown properties or fields: {1}. Please make sure that the names of these members match the names of the properties on the main type.
        /// </summary>
        string AssociatedMetadataTypeTypeDescriptor_MetadataTypeContainsUnknownProperties { get; }

        /// <summary>
        /// The type '{0}' does not contain a property named '{1}'.
        /// </summary>
        string AttributeStore_Unknown_Property { get; }

        /// <summary>
        /// The property {0}.{1} could not be found.
        /// </summary>
        string Common_PropertyNotFound { get; }

        /// <summary>
        /// '{0}' and '{1}' do not match.
        /// </summary>
        string CompareAttribute_MustMatch { get; }

        /// <summary>
        /// Could not find a property named {0}.
        /// </summary>
        string CompareAttribute_UnknownProperty { get; }

        /// <summary>
        /// The {0} field is not a valid credit card number.
        /// </summary>
        string CreditCardAttribute_Invalid { get; }

        /// <summary>
        /// Could not convert the value of type '{0}' to '{1}' as expected by method {2}.{3}.
        /// </summary>
        string CustomValidationAttribute_Type_Conversion_Failed { get; }

        /// <summary>
        /// The custom validation type '{0}' must be public.
        /// </summary>
        string CustomValidationAttribute_Type_Must_Be_Public { get; }

        /// <summary>
        /// {0} is not valid.
        /// </summary>
        string CustomValidationAttribute_ValidationError { get; }

        /// <summary>
        /// The custom DataType string cannot be null or empty.
        /// </summary>
        string DataTypeAttribute_EmptyDataTypeString { get; }

        /// <summary>
        /// The {0} property has not been set.  Use the {1} method to get the value.
        /// </summary>
        string DisplayAttribute_PropertyNotSet { get; }

        /// <summary>
        /// The {0} field is not a valid e-mail address.
        /// </summary>
        string EmailAddressAttribute_Invalid { get; }

        /// <summary>
        /// The type provided for EnumDataTypeAttribute cannot be null.
        /// </summary>
        string EnumDataTypeAttribute_TypeCannotBeNull { get; }

        /// <summary>
        /// The type '{0}' needs to represent an enumeration type.
        /// </summary>
        string EnumDataTypeAttribute_TypeNeedsToBeAnEnum { get; }

        /// <summary>
        /// The {0} field only accepts files with the following extensions: {1}
        /// </summary>
        string FileExtensionsAttribute_Invalid { get; }

        /// <summary>
        /// The field of type {0} must be a string, array or ICollection type.
        /// </summary>
        string LengthAttribute_InvalidValueType { get; }


        /// <summary>
        /// MaxLengthAttribute must have a Length value that is greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length.
        /// </summary>
        string MaxLengthAttribute_InvalidMaxLength { get; }

        /// <summary>
        /// The field {0} must be a string or array type with a maximum length of '{1}'.
        /// </summary>
        string MaxLengthAttribute_ValidationError { get; }

        /// <summary>
        /// MetadataClassType cannot be null.
        /// </summary>
        string MetadataTypeAttribute_TypeCannotBeNull { get; }

        /// <summary>
        /// MinLengthAttribute must have a Length value that is zero or greater.
        /// </summary>
        string MinLengthAttribute_InvalidMinLength { get; }

        /// <summary>
        /// The field {0} must be a string or array type with a minimum length of '{1}'.
        /// </summary>
        string MinLengthAttribute_ValidationError { get; }

        /// <summary>
        /// The {0} field is not a valid phone number.
        /// </summary>
        string PhoneAttribute_Invalid { get; }

        /// <summary>
        /// The type {0} must implement {1}.
        /// </summary>
        string RangeAttribute_ArbitraryTypeNotIComparable { get; }

        /// <summary>
        /// The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.
        /// </summary>
        string RangeAttribute_MinGreaterThanMax { get; }

        /// <summary>
        /// The minimum and maximum values must be set.
        /// </summary>
        string RangeAttribute_Must_Set_Min_And_Max { get; }

        /// <summary>
        /// The OperandType must be set when strings are used for minimum and maximum values.
        /// </summary>
        string RangeAttribute_Must_Set_Operand_Type { get; }

        /// <summary>
        /// The field {0} must be between {1} and {2}.
        /// </summary>
        string RangeAttribute_ValidationError { get; }

        /// <summary>
        /// The field {0} must match the regular expression '{1}'.
        /// </summary>
        string RegexAttribute_ValidationError { get; }

        /// <summary>
        /// The pattern must be set to a valid regular expression.
        /// </summary>
        string RegularExpressionAttribute_Empty_Pattern { get; }

        /// <summary>
        /// The {0} field is required.
        /// </summary>
        string RequiredAttribute_ValidationError { get; }

        /// <summary>
        /// The maximum length must be a nonnegative integer.
        /// </summary>
        string StringLengthAttribute_InvalidMaxLength { get; }

        /// <summary>
        /// The field {0} must be a string with a maximum length of {1}.
        /// </summary>
        string StringLengthAttribute_ValidationError { get; }

        /// <summary>
        /// The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.
        /// </summary>
        string StringLengthAttribute_ValidationErrorIncludingMinimum { get; }

        /// <summary>
        /// The key parameter at position {0} with value '{1}' is not a string. Every key control parameter must be a string.
        /// </summary>
        string UIHintImplementation_ControlParameterKeyIsNotAString { get; }

        /// <summary>
        /// The key parameter at position {0} is null. Every key control parameter must be a string.
        /// </summary>
        string UIHintImplementation_ControlParameterKeyIsNull { get; }

        /// <summary>
        /// The key parameter at position {0} with value '{1}' occurs more than once.
        /// </summary>
        string UIHintImplementation_ControlParameterKeyOccursMoreThanOnce { get; }

        /// <summary>
        /// The number of control parameters must be even.
        /// </summary>
        string UIHintImplementation_NeedEvenNumberOfControlParameters { get; }

        /// <summary>
        /// The {0} field is not a valid fully-qualified http, https, or ftp URL.
        /// </summary>
        string UrlAttribute_Invalid { get; }

        /// <summary>
        /// Either ErrorMessageString or ErrorMessageResourceName must be set, but not both.
        /// </summary>
        string ValidationAttribute_Cannot_Set_ErrorMessage_And_Resource { get; }

        /// <summary>
        /// IsValid(object value) has not been implemented by this class.  The preferred entry point is GetValidationResult() and classes should override IsValid(object value, ValidationContext context).
        /// </summary>
        string ValidationAttribute_IsValid_NotImplemented { get; }

        /// <summary>
        /// Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute.
        /// </summary>
        string ValidationAttribute_NeedBothResourceTypeAndResourceName { get; }

        /// <summary>
        /// The property '{0}' on resource type '{1}' is not a string type.
        /// </summary>
        string ValidationAttribute_ResourcePropertyNotStringType { get; }

        /// <summary>
        /// The resource type '{0}' does not have an accessible static property named '{1}'.
        /// </summary>
        string ValidationAttribute_ResourceTypeDoesNotHaveProperty { get; }

        /// <summary>
        /// The field {0} is invalid.
        /// </summary>
        string ValidationAttribute_ValidationError { get; }

        /// <summary>
        /// The instance provided must match the ObjectInstance on the ValidationContext supplied.
        /// </summary>
        string Validator_InstanceMustMatchValidationContextInstance { get; }

        /// <summary>
        /// The value for property '{0}' must be of type '{1}'.
        /// </summary>
        string Validator_Property_Value_Wrong_Type { get; }
    }
}

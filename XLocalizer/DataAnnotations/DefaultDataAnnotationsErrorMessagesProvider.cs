namespace XLocalizer.DataAnnotations
{
    /// <summary>
    /// Original messages obtained from <a href="https://github.com/dotnet/corefx/blob/master/src/System.ComponentModel.Annotations/src/Resources/Strings.resx"/>
    /// </summary>
    public class DefaultDataAnnotationsErrorMessagesProvider : IDataAnnotationsMessagesProvider
    {
        string IDataAnnotationsMessagesProvider.ArgumentIsNullOrWhitespace => "The argument '{0}' cannot be null, empty or contain only whitespace.";

        string IDataAnnotationsMessagesProvider.AssociatedMetadataTypeTypeDescriptor_MetadataTypeContainsUnknownProperties => "The associated metadata type for type '{0}' contains the following unknown properties or fields: {1}. Please make sure that the names of these members match the names of the properties on the main type.";

        string IDataAnnotationsMessagesProvider.AttributeStore_Unknown_Property => "The type '{0}' does not contain a public property named '{1}'.";

        string IDataAnnotationsMessagesProvider.Common_PropertyNotFound => "The property {0}.{1} could not be found.";

        string IDataAnnotationsMessagesProvider.CompareAttribute_MustMatch => "'{0}' and '{1}' do not match.";

        string IDataAnnotationsMessagesProvider.CompareAttribute_UnknownProperty => "Could not find a property named {0}.";

        string IDataAnnotationsMessagesProvider.CreditCardAttribute_Invalid => "The {0} field is not a valid credit card number.";

        string IDataAnnotationsMessagesProvider.CustomValidationAttribute_Type_Conversion_Failed => "Could not convert the value of type '{0}' to '{1}' as expected by method {2}.{3}.";

        string IDataAnnotationsMessagesProvider.CustomValidationAttribute_Type_Must_Be_Public => "The custom validation type '{0}' must be public.";

        string IDataAnnotationsMessagesProvider.CustomValidationAttribute_ValidationError => "{0} is not valid.";

        string IDataAnnotationsMessagesProvider.DataTypeAttribute_EmptyDataTypeString => "The custom DataType string cannot be null or empty.";

        string IDataAnnotationsMessagesProvider.DisplayAttribute_PropertyNotSet => "The {0} property has not been set.  Use the {1} method to get the value.";

        string IDataAnnotationsMessagesProvider.EmailAddressAttribute_Invalid => "The {0} field is not a valid e-mail address.";

        string IDataAnnotationsMessagesProvider.EnumDataTypeAttribute_TypeCannotBeNull => "The type provided for EnumDataTypeAttribute cannot be null.";

        string IDataAnnotationsMessagesProvider.EnumDataTypeAttribute_TypeNeedsToBeAnEnum => "The type '{0}' needs to represent an enumeration type.";

        string IDataAnnotationsMessagesProvider.FileExtensionsAttribute_Invalid => "The {0} field only accepts files with the following extensions: {1}";

        string IDataAnnotationsMessagesProvider.LengthAttribute_InvalidValueType => "The field of type {0} must be a string, array or ICollection type.";

        string IDataAnnotationsMessagesProvider.MaxLengthAttribute_InvalidMaxLength => "MaxLengthAttribute must have a Length value that is greater than zero. Use MaxLength() without parameters to indicate that the string or array can have the maximum allowable length.";

        string IDataAnnotationsMessagesProvider.MaxLengthAttribute_ValidationError => "The field {0} must be a string or array type with a maximum length of '{1}'.";

        string IDataAnnotationsMessagesProvider.MetadataTypeAttribute_TypeCannotBeNull => "MetadataClassType cannot be null.";

        string IDataAnnotationsMessagesProvider.MinLengthAttribute_InvalidMinLength => "MinLengthAttribute must have a Length value that is zero or greater.";

        string IDataAnnotationsMessagesProvider.MinLengthAttribute_ValidationError => "The field {0} must be a string or array type with a minimum length of '{1}'.";

        string IDataAnnotationsMessagesProvider.PhoneAttribute_Invalid => "The {0} field is not a valid phone number.";

        string IDataAnnotationsMessagesProvider.RangeAttribute_ArbitraryTypeNotIComparable => "The type {0} must implement {1}.";

        string IDataAnnotationsMessagesProvider.RangeAttribute_MinGreaterThanMax => "The maximum value '{0}' must be greater than or equal to the minimum value '{1}'.";

        string IDataAnnotationsMessagesProvider.RangeAttribute_Must_Set_Min_And_Max => "The minimum and maximum values must be set.";

        string IDataAnnotationsMessagesProvider.RangeAttribute_Must_Set_Operand_Type => "The OperandType must be set when strings are used for minimum and maximum values.";

        string IDataAnnotationsMessagesProvider.RangeAttribute_ValidationError => "The field {0} must be between {1} and {2}.";

        string IDataAnnotationsMessagesProvider.RegexAttribute_ValidationError => "The field {0} must match the regular expression '{1}'.";

        string IDataAnnotationsMessagesProvider.RegularExpressionAttribute_Empty_Pattern => "The pattern must be set to a valid regular expression.";

        string IDataAnnotationsMessagesProvider.RequiredAttribute_ValidationError => "The {0} field is required.";

        string IDataAnnotationsMessagesProvider.StringLengthAttribute_InvalidMaxLength => "The maximum length must be a nonnegative integer.";

        string IDataAnnotationsMessagesProvider.StringLengthAttribute_ValidationError => "The field {0} must be a string with a maximum length of {1}.";

        string IDataAnnotationsMessagesProvider.StringLengthAttribute_ValidationErrorIncludingMinimum => "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}.";


        string IDataAnnotationsMessagesProvider.UIHintImplementation_ControlParameterKeyIsNotAString => "The key parameter at position {0} with value '{1}' is not a string. Every key control parameter must be a string.";

        string IDataAnnotationsMessagesProvider.UIHintImplementation_ControlParameterKeyIsNull => "The key parameter at position {0} is null. Every key control parameter must be a string.";

        string IDataAnnotationsMessagesProvider.UIHintImplementation_ControlParameterKeyOccursMoreThanOnce => "The key parameter at position {0} with value '{1}' occurs more than once.";

        string IDataAnnotationsMessagesProvider.UIHintImplementation_NeedEvenNumberOfControlParameters => "The number of control parameters must be even.";

        string IDataAnnotationsMessagesProvider.UrlAttribute_Invalid => "The {0} field is not a valid fully-qualified http, https, or ftp URL.";

        string IDataAnnotationsMessagesProvider.ValidationAttribute_Cannot_Set_ErrorMessage_And_Resource => "Either ErrorMessageString or ErrorMessageResourceName must be set, but not both.";

        string IDataAnnotationsMessagesProvider.ValidationAttribute_IsValid_NotImplemented => "IsValid(object value) has not been implemented by this class.  The preferred entry point is GetValidationResult() and classes should override IsValid(object value, ValidationContext context).";

        string IDataAnnotationsMessagesProvider.ValidationAttribute_NeedBothResourceTypeAndResourceName => "Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute.";

        string IDataAnnotationsMessagesProvider.ValidationAttribute_ResourcePropertyNotStringType => "The property '{0}' on resource type '{1}' is not a string type.";

        string IDataAnnotationsMessagesProvider.ValidationAttribute_ResourceTypeDoesNotHaveProperty => "The resource type '{0}' does not have an accessible static property named '{1}'.";

        string IDataAnnotationsMessagesProvider.ValidationAttribute_ValidationError => "The field {0} is invalid.";

        string IDataAnnotationsMessagesProvider.Validator_InstanceMustMatchValidationContextInstance => "The instance provided must match the ObjectInstance on the ValidationContext supplied.";

        string IDataAnnotationsMessagesProvider.Validator_Property_Value_Wrong_Type => "The value for property '{0}' must be of type '{1}'.";
    }
}

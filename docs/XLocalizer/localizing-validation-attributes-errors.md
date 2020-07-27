## Localizing Data Annotations
Another handful feature of XLocalizer is Express attributes; Some of the data attributes do not produce localized error messages if not specified manually in the attributes `ErrorMessage="..."`. Expess data attributes eliminates the need to manually provide error message for each attribute and it produces localized error messages automatically.

- Sample required attribute usage:
````csharp
using XLocalizer.DataAnnotations;

[ExRequired]
[Display(Name = "Full name")]
public string Name { get; set; }
````

Below is a list of all express data attributes and their default error messages: 
````csharp
// "The {0} field is required."
[ExRequired]

// "The field {0} must be a string with a maximum length of {1}."
[ExStringLength(10)]

// "The field {0} must be a string with a minimum length of {2} and a maximum length of {1}."
[ExStringLength(10, MinimumLength=3)]

// "The field {0} must be between {1} and {2}."
[ExRange(3, 10)]

// "The field {0} must be a string or array type with a minimum length of '{1}'."
[ExMinLength(3)]

// "The field {0} must be a string or array type with a maximum length of '{1}'."
[ExMaxLength(10)]

// "'{0}' and '{1}' do not match."
[ExCompare("other_field")]

// "The field {0} must match the regular expression '{1}'."
[ExRegularExpression("regex_pattern")]
````

The rest of the frameworks data attributes are already providing a default error messages, so they are localized by _ExpressLocalization_ by default as well:

````cs
// "The {0} field is not a valid credit card number."
[CreditCard]

// "{0} is not valid."
[CustomValdiation]

// "The {0} field is not a valid e-mail address."
[EmailAddress]

// "The {0} field only accepts files with the following extensions: {1}"
[FileExtensions]

// "The {0} field is not a valid phone number."
[Phone]

// "The {0} field is not a valid fully-qualified http, https, or ftp URL."
[Url]
```` 

#
### Next: [Model binding errors][1]
#

[1]:../XLocalizer/model-binding-errors.md
# XLocalizer

#### Table of contents
- [What is XLocalizer](what-is-xlocalizer.md)
- [Quick start](setup-quick-start.md)
- [Common Setup](setup.md)
  - [Localization setup based on XML](setup-xml.md)
  - [Localization setup based on DB](setup-db.md)
  - [Localization setup based on RESX](setup-resx.md)
- [Translation services](translate-services.md)
  - [MyMemory Translate](translate-services-mymemory.md)
  - [SYSTRAN.io Translate](translate-services-systran.md)
  - [Google Translate](translate-services-google.md)
  - [Yandex Translate](translate-services-yandex.md)
  - [IBM Watson Language Translator](translate-services-ibm.md)
- [Localizing views](localizing-views.md)
- [Localizing custom backend messages](localizing-custom-backend-messages.md)
- [Localizing validation attributes errors](localizing-validation-attributes-errors.md)
- [Model binding errors](model-binding-errors.md)
- [Identity errors](identity-errors.md)
- [Export XML to RESX](export-xml-to-resx.md)
- [Export DB to RESX](export-db-to-resx.md)

##### Customizing XLocalizer
- [Using custom translator](using-custom-translator.md)
- [Using custom resource provider](using-custom-resource-provider.md)
- [Using custom resource exporter](using-custom-resource-exporter.md)

##### Miscellaneous
  - [Culture fallback behaviour](culture-fallback-behavior.md)
  - [Language navigation](language-navigation.md)
  - [Client side validation](client-side-validation.md)
  - [Validating localized input](validating-localized-input.md)


## Disclaimer Third Parties
All product and company names of translation services are trademarks™ or registered® trademarks of their respective holders. Use of them does not imply any affiliation with or endorsement by them.

During the development of `XLocalizer` I've used many online translation services with the freemium plan, but it is up to you to use a priced plan from the respective service.

 Each translation service has its pros and cons. [MyMemory Translate][1] provided the best results for the languages I've been working with _(in terms performans and amount of free translation requests)_. So, in this documentation you will see most samples refering to [MyMemory Translate][1] as the translation service. But you are free to use any other service that fits your needs.

[1]:https://rapidapi.com/translated/api/mymemory-translation-memory
namespace XLocalizer
{
    /// <summary>
    /// Interface to create custom localization providers depending on any file type.
    /// </summary>
    public interface IXResourceProvider
    {
        /// <summary>
        /// Get a localized value from the resource.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool TryGetValue<TResource>(string name, out string value)
            where TResource : class;

        /// <summary>
        /// Set localized value into the resource.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="comment"></param>
        /// <param name="isApproved">boolean value for automatically created resource keys. False by default.</param>
        /// <returns></returns>
        bool TrySetValue<TResource>(string name, string value, string comment, bool isApproved = false)
            where TResource : class;
    }
}

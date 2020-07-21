namespace XLocalizer.Translate
{
    /// <summary>
    /// Generic interface to implement XTranslator service
    /// that will connext to external translation services
    /// </summary>
    /// <typeparam name="TTranslator"></typeparam>
    public interface IXTranslator<TTranslator> : IXTranslator
        where TTranslator : IStringTranslator
    {

    }

    /// <summary>
    /// Interface to implement ExpressTranslator service
    /// that will connext to external translation services
    /// </summary>
    public interface IXTranslator
    {
        /// <summary>
        /// Try get translation
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format">text ot html</param>
        /// <param name="translation"></param>
        /// <returns></returns>
        bool TryTranslate(string text, string format, out string translation);

        /// <summary>
        /// Try get translation
        /// </summary>
        /// <param name="text"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="format">text or html</param>
        /// <param name="translation"></param>
        /// <returns></returns>
        bool TryTranslate(string text, string from, string to, string format, out string translation);
    }
}
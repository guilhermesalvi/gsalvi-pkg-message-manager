namespace GSalvi.MessageManager
{
    /// <summary>
    /// Defines a manager of application messages
    /// that uses localization resources.
    /// </summary>
    public interface IApplicationMassageManager
    {
        /// <summary>
        /// Returns a string localized from resources.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueParams"></param>
        /// <returns></returns>
        string FindValueByKey(string key, params string[] valueParams);
    }
}

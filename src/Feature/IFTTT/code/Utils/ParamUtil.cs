namespace Community.Feature.IFTTT.Utils
{
    public static class ParamUtil
    {

        /// <summary>
        /// Return value n or null
        /// </summary>
        /// <param name="values">Array of values (or null)</param>
        /// <param name="n">1 based index</param>
        /// <returns></returns>
        public static string GetValue(int n, string[] values)
        {
            if (values == null || values.Length < n)
                return null;
            return values[n - 1];
        }
    }
}
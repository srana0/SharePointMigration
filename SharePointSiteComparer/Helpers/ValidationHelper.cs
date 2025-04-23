namespace SharePointSiteComparer.Helpers
{
    using System;

    public static class ValidationHelper
    {
        public static void EnsureArgumentNotNull<TArgrument>(string argumentName, TArgrument argument)
            where TArgrument : class
        {
            if (null == argument)
            {
                //var stackTrace = new StackTrace();
                //var method = stackTrace.GetFrame(1).GetMethod();
                //Log(method.ReflectedType.FullName, method.Name, argumentName);

                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
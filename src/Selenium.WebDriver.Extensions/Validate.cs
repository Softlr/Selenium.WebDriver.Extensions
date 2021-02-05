namespace Selenium.WebDriver.Extensions
{
    using System;
    using System.Linq.Expressions;
    using static System.String;

    internal static class Validate
    {
        public static TType NotNull<TType>(Expression<Func<TType>> memberExpression)
            where TType : class
        {
            var paramName = ((MemberExpression)memberExpression.Body).Member.Name;
            var value = memberExpression.Compile().Invoke();
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            return value;
        }

        public static string NullOrNotEmpty(Expression<Func<string>> memberExpression)
        {
            var paramName = ((MemberExpression)memberExpression.Body).Member.Name;
            var value = memberExpression.Compile().Invoke();
            return value == null || !IsNullOrEmpty(value.Trim())
                ? value
                : throw new ArgumentException("Argument must be null or not-empty", paramName);
        }

        public static string Required(Expression<Func<string>> memberExpression)
        {
            var paramName = ((MemberExpression)memberExpression.Body).Member.Name;
            var value = memberExpression.Compile().Invoke();
            if (IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(paramName);
            }

            return value;
        }

        public static string Version(Expression<Func<string>> memberExpression)
        {
            var paramName = ((MemberExpression)memberExpression.Body).Member.Name;
            var value = memberExpression.Compile().Invoke();
            if (!System.Version.TryParse(value, out _))
            {
                throw new ArgumentException("Argument is not a valid library version", paramName);
            }

            return value;
        }

        public static string VersionOrLatest(Expression<Func<string>> memberExpression)
        {
            var paramName = ((MemberExpression)memberExpression.Body).Member.Name;
            var value = memberExpression.Compile().Invoke();
            if (value != "latest" && !System.Version.TryParse(value, out _))
            {
                throw new ArgumentException("Argument is not a valid library version", paramName);
            }

            return value;
        }
    }
}

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ChatApp
{
    public static class ExpressionHelpers
    {
        /// <summary>
        /// This compiles an expression and returns the functions return value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambda">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //Convert a lambda into a property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            //Access information about the property so that we can set it 
            var propertyInfo = (PropertyInfo)expression.Member;

            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //Set the property to the value 
            propertyInfo.SetValue(target, value);
        }
    }
}

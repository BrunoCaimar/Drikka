using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Drikka.Geo.Data.Mapping
{
    public class Mapper<T>
    {
        public void MapAttribute(Expression<Func<T, object >> expression, string fieldName)
        {
            var res = GetProperty(expression);
        }

        public static PropertyInfo GetProperty(LambdaExpression selector)
        {
            if (selector.Body.NodeType == ExpressionType.MemberAccess)
            {
                return ((MemberExpression)selector.Body).Member as PropertyInfo;
            }

            throw new InvalidOperationException();
        }

        //public static PropertyInfo GetProperty<TValue>(Expression<Func<T, TValue>> selector)
        //{
        //    Expression body = selector;
        //    if (body is LambdaExpression)
        //    {
        //        body = ((LambdaExpression)body).Body;
        //    }
        //    switch (body.NodeType)
        //    {
        //        case ExpressionType.MemberAccess:
        //            return (PropertyInfo)((MemberExpression)body).Member;
        //        default:
        //            throw new InvalidOperationException();
        //    }
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace cpShared.Helpers
{
    public class LinqExpressionHelper
    {
        public static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, object value)
        {
            var parameter = Expression.Parameter(typeof(T));
            var pPropertyDto = Expression.PropertyOrField(parameter, propertyName);
            var body = Expression.Equal(pPropertyDto, Expression.Convert(Expression.Constant(value), pPropertyDto.Type));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }


        public static Expression<Func<TFk, bool>> BuildContainsPredicate<TFk>(string KeyPropertyName, List<int> lstId)
        {
            var pKeyExp = Expression.Parameter(typeof(TFk));
            var pKeyProperty = Expression.PropertyOrField(pKeyExp, KeyPropertyName);
            var method = lstId.GetType().GetMethod("Contains");
            var pKeyPropertyAsInt = Expression.Convert(pKeyProperty, typeof(int));
            //Could also be?var call = Expression.Call(Expression.Constant(lstId), method, pKeyProperty);
            var call = Expression.Call(Expression.Constant(lstId), method, pKeyPropertyAsInt);
            return Expression.Lambda<Func<TFk, bool>>(call, pKeyExp);
        }

        public static Expression<Func<T, bool>> BuildAnyPredicate<T>(string CollectionPropertyName, string SelectorName, int Id)
        {
            var pBaseExp = Expression.Parameter(typeof(T), "qryType");
            var pBaseProperty = Expression.PropertyOrField(pBaseExp, CollectionPropertyName);
            var collectionItemType = pBaseProperty.Type.GetGenericArguments().Single();
            var pCollExp = Expression.Parameter(collectionItemType, "qryColl");
            var selectorProperty = Expression.PropertyOrField(pCollExp, SelectorName);

            LambdaExpression anyPredicate = null;
            anyPredicate = Expression.Lambda(
                Expression.Equal(selectorProperty,
                Expression.Convert(Expression.Constant(Id), selectorProperty.Type)),
            pCollExp);
            //}

            var result = Expression.Call(
                typeof(Enumerable), "Any", new[] { pCollExp.Type },
                pBaseProperty, anyPredicate);

            return MakeLambda(pBaseExp, result) as Expression<Func<T, bool>>;
        }

        private static Expression MakeLambda(Expression parameter, Expression predicate)
        {
            var resultParameterVisitor = new ParameterVisitor();
            resultParameterVisitor.Visit(parameter);
            var resultParameter = resultParameterVisitor.Parameter;
            return Expression.Lambda(predicate, (ParameterExpression)resultParameter);
        }

        public static Expression<Func<T, bool>> BuildNot<T>(Expression<Func<T, bool>> predicate)
        {
            var candidateExpr = predicate.Parameters[0];
            var body = Expression.Not(predicate.Body);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

        private class ParameterVisitor : ExpressionVisitor
        {
            public Expression Parameter
            {
                get;
                private set;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                Parameter = node;
                return node;
            }
        }
    }
}

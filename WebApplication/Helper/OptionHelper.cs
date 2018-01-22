using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WebApplication.Helper
{
    public static class OptionHelper
    {
        public static IList<SelectListItem> OptionsForBoolean<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool selected)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            object trueTitle;
            metaData.AdditionalValues.TryGetValue(BooleanDisplayValuesAttribute.TrueTitleAdditionalValueName, out trueTitle);

            trueTitle = trueTitle ?? "Sim";

            object falseTitle;
            metaData.AdditionalValues.TryGetValue(BooleanDisplayValuesAttribute.FalseTitleAdditionalValueName, out falseTitle);
            falseTitle = falseTitle ?? "Não";

            var options = new[]{
                            new SelectListItem {Text = (string) falseTitle, Value = Boolean.FalseString},
                            new SelectListItem {Text = (string) trueTitle, Value = Boolean.TrueString, Selected = selected}
                            };
            return options;
        }
    }
}
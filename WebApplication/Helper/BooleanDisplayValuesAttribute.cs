using System;
using System.Web.ModelBinding;

namespace WebApplication.Helper
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class BooleanDisplayValuesAttribute : Attribute, IMetadataAware
    {
        public const string TrueTitleAdditionalValueName = "BooleanTrueValueTitle";
        public const string FalseTitleAdditionalValueName = "BooleanFalseValueTitle";

        private readonly string _trueValueTitle;
        private readonly string _falseValueTitle;

        public BooleanDisplayValuesAttribute(string trueValueTitle,
                                             string falseValueTitle)
        {
            _trueValueTitle = trueValueTitle;
            _falseValueTitle = falseValueTitle;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues[TrueTitleAdditionalValueName] = _trueValueTitle;
            metadata.AdditionalValues[FalseTitleAdditionalValueName] = _falseValueTitle;
        }
    }
}
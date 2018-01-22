namespace WebApplication.Helper
{
    public class BooleanDisplayValuesAsYesNoAttribute : BooleanDisplayValuesAttribute
    {
        public BooleanDisplayValuesAsYesNoAttribute()
            : base("Sim", "Não")
        {
        }
    }

}
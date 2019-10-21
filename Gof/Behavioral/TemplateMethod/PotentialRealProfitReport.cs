namespace Gof.Creational.TemplateMethod
{
    public class PotentialRealProfitReport : Report
    {
        protected override string TemplateFileName => "PotentialRealProfitReport.xlsx";

        protected override bool Validation()
        {
            // ...
            return true;
        }
        
        protected override void GenerateReport()
        {
            // ...
        }
    }
}

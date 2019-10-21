namespace Gof.Creational.TemplateMethod
{
    public class LostProfitReport : Report
    {
        protected override string TemplateFileName => "LostProfitReport.xlsx";

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

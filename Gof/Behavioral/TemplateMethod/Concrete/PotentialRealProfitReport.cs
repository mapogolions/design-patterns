using Gof.Creational.TemplateMethod.Abs;

namespace Gof.Creational.TemplateMethod.Concrete
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

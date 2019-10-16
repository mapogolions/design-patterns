using Gof.Creational.TemplateMethod.Abs;

namespace Gof.Creational.TemplateMethod.Concrete
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

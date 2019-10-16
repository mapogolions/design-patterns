using System.IO;
using Gof.TemplateMethod.Abs;

namespace Gof.TemplateMethod.Concrete
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

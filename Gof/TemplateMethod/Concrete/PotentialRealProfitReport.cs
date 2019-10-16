using System.IO;
using Gof.TemplateMethod.Abs;

namespace Gof.TemplateMethod.Concrete
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

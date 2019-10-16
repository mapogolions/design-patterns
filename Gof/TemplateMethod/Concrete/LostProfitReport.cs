using System.IO;
using Gof.TemplateMethod.Abs;

namespace Gof.TemplateMethod.Concrete
{
    public class LostProfitReport : Report
    {
        protected override string TemplateFileName => "LostProfit.xlsx";
        protected override string GenerateFileLinkUrl() => Path.Combine(ReportsDirectory, TemplateFileName);

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

using System.IO;
using Gof.TemplateMethod.Abs;

namespace Gof.TemplateMethod.Concrete
{
    public class PotentialRealProfit : Report
    {
        protected override bool IsValidPath(string path) => true;
        protected override string TemplateFileName => "PotentialRealProfit.xlsx";
        protected override string GenerateFileLinkUrl() => Path.Combine(ReportsDirectory, TemplateFileName);

        protected override void GenerateReport()
        {
            // ...
        }
    }
}

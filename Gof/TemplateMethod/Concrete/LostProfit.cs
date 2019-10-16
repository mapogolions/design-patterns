using System.IO;
using Gof.TemplateMethod.Abs;

namespace Gof.TemplateMethod.Concrete
{
    public class LostProfit : Report
    {
        protected override bool IsValidPath(string path) => true;
        protected override string TemplateFileName => "LostProfit.xlsx";
        protected override string GenerateFileLinkUrl() => Path.Combine(ReportsDirectory, TemplateFileName);

        protected override void GenerateReport()
        {
            // ...
        }
    }
}

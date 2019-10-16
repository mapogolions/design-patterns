using System.IO;
namespace Gof.TemplateMethod.Abs
{
    public abstract class Report
    {
        protected abstract string TemplateFileName { get; }
        protected virtual string ReportsDirectory => "/Reports";
        protected abstract string GenerateFileLinkUrl();
        protected abstract bool Validation();
        protected abstract void GenerateReport();

        public string BuildReport()
        {
            if (!Validation())
                return string.Empty;
            GenerateReport();
            return GenerateFileLinkUrl();
        }
    }
}

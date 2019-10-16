using System.IO;
namespace Gof.TemplateMethod.Abs
{
    public abstract class Report
    {
        protected abstract string TemplateFileName { get; }
        protected virtual string ReportsDirectory => "/Reports";
        protected virtual string GenerateFileLinkUrl() => 
            Path.Combine(ReportsDirectory, TemplateFileName).Replace(@"\", "/");
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

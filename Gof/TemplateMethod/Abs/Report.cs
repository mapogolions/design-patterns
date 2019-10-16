using System.IO;
namespace Gof.TemplateMethod.Abs
{
    public abstract class Report
    {
        protected abstract string TemplateFileName { get; }
        protected virtual string ReportsDirectory => "/Reports";
        protected abstract string GenerateFileLinkUrl();
        protected abstract bool IsValidPath(string path);
        protected abstract void GenerateReport();

        public string BuildReport()
        {
            if (!IsValidPath(Path.Combine(ReportsDirectory, TemplateFileName)))
                return string.Empty;
            GenerateReport();
            return GenerateFileLinkUrl();
        }
    }
}

using Gof.Creational.TemplateMethod.Abs;

namespace Gof.Creational.TemplateMethod
{
    public class FakeClient
    {
        public readonly Report _report;
        public FakeClient(Report report) => _report = report;
        public string BuildReport() => _report.BuildReport();
    }
}

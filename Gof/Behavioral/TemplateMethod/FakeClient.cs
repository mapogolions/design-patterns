namespace Gof.Creational.TemplateMethod
{
    public class FakeClient
    {
        private readonly Report _report;
        public FakeClient(Report report) => _report = report;
        public string BuildReport() => _report.BuildReport();
    }
}

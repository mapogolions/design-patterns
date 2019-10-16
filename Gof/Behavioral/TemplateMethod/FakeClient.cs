using Gof.Creational.TemplateMethod.Abs;

namespace Gof.Creational.TemplateMethod
{
    public class FakeClient
    {
        public Report Report { get; set; }
        public string BuildReport() => Report.BuildReport();
    }
}

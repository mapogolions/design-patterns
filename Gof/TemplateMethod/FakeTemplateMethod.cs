using Gof.TemplateMethod.Abs;

namespace Gof.TemplateMethod
{
    public class FakeTemplateMethod
    {
        public Report Report { get; set; }
        public string BuildReport() => Report.BuildReport();
    }
}

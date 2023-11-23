using Gof.Structural.Adapter.FunctionalInterface;

namespace Gof.Tests.Structural;

public class FunctionalInterfaceAdapterTests
{
    [Fact]
    public void ShouldCreateConnectionString()
    {
        var pipeline = new PreProcessorBehaviour<ConnectionStringOptions, string>(new[] {
            new PreProcessorAdapter<ConnectionStringOptions>(options => options.DataSource = "."),
            new PreProcessorAdapter<ConnectionStringOptions>(options => options.InitialCatalog = "master"),
            new PreProcessorAdapter<ConnectionStringOptions>(options => options.IntegratedSecurity = true),
        });
        var connectionString = pipeline.Handle(new(),
            x => $"Data Source={x.DataSource};Initial Catalog={x.InitialCatalog};Integrated Security={x.IntegratedSecurity}");

        Assert.Equal("Data Source=.;Initial Catalog=master;Integrated Security=True", connectionString);
    }
}

public class ConnectionStringOptions
{
    public string? DataSource { get; set; }
    public string? InitialCatalog { get; set; }
    public bool IntegratedSecurity { get; set; }
}

using System;
using System.Threading.Tasks;
using NUnit.Framework;

public abstract class SquadronSetup<TResource>
{
    [OneTimeSetUp]
    public async Task Initialize()
    {
        Resource = Activator.CreateInstance<TResource>();
        await (Resource as IResourceInitializer).InitializeAsync();
    }

    protected TResource Resource { get; set; }
}

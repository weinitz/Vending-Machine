using System.Diagnostics.CodeAnalysis;

namespace Lexicon.VendingMachine.Model.Snacks
{
    public abstract class Snacks : Product
    {
        [ExcludeFromCodeCoverage] public override string UsageInformation => "Eat it";
    }
}
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lexicon.VendingMachine.Data
{
    [ExcludeFromCodeCoverage]
    public class MenuComponent
    {
        public virtual string Description { get; }
        public virtual double Price { get; }

        public virtual void Add(MenuComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual string Render()
        {
            throw new NotImplementedException();
        }
    }
}
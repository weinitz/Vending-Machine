using System.Collections.Generic;
using System.Text;

namespace Lexicon.VendingMachine.Data
{
    public class Menu : MenuComponent
    {
        private readonly List<MenuComponent> _components = new List<MenuComponent>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public Menu(string description)
        {
            Description = description;
        }

        public override string Description { get; }

        public override void Add(MenuComponent component)
        {
            _components.Add(component);
        }

        public override string Render()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine();
            _stringBuilder.Append("____________" + Description + "______________________\n");
            _stringBuilder.AppendLine();
            foreach (var menuComponent in _components) _stringBuilder.AppendLine(menuComponent.Render());

            return _stringBuilder.ToString();
        }
    }
}
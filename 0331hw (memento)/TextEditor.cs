using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0331hw__memento_
{
    class TextEditor
    {
        private string State;

        public TextEditor(string State)
        {
            this.State = State;
        }

        public IMemento Save()
        {
            return new TextMemento(this.State);
        }
        public void Rewrite(string NewState)
        {
            this.State = NewState;
            Console.WriteLine("Text was changed to: "+ State);
        }
        public void Restore(IMemento memento)
        {
            if (!(memento is TextMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            this.State = memento.GetState();
            Console.Write("Text was changed to:" + State);
        }
    }
    public interface IMemento
    {

        string GetState();

    }

    class TextMemento : IMemento
    {
        private string State;

        public TextMemento(string state)
        {
            this.State = state;
        }

        public string GetState()
        {
            return this.State;
        }
    }

    class Caretaker
    {
        private List<IMemento> Mementos = new List<IMemento>();

        private TextEditor Text = null;

        public Caretaker(TextEditor originator)
        {
            this.Text = originator;
        }

        public void Backup()
        {
            this.Mementos.Add(this.Text.Save());
        }

        public void Undo()
        {
            if (this.Mementos.Count == 0)
            {
                return;
            }

            var Memento = this.Mementos.Last();
            this.Mementos.Remove(Memento);

            Console.WriteLine("Restoring state to: " + Memento.GetState());

            try
            {
                this.Text.Restore(Memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }
    }

}

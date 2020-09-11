
using System.Threading.Tasks;

namespace EmiLab.Ivao.Parsers
{
    internal abstract class IvaoParser
    {
        public virtual object Data { get; protected set; }

        public abstract void Parse();
        public abstract Task ParseAsync();
    }
}
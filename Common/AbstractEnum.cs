using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class AbstractEnum(string label, string dbCode)
    {
        public List<AbstractEnum> EnumList { get; protected set; }
        public string Label { get; protected set; }
        public readonly string DbCode = dbCode;

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

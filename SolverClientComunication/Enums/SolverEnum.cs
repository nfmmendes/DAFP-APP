using System.Collections.Generic;
using Common;

namespace SolverClientComunication.Enums
{
    public class SolverEnum :AbstractEnum 
    {
        public static List<SolverEnum> EnumList = new List<SolverEnum>();

        public static readonly SolverEnum CPLEX = new SolverEnum("Cplex","CPLEX");
        public static readonly SolverEnum GUROBI = new SolverEnum("Gurobi","GUROBI");
        public static readonly SolverEnum XPRESS = new SolverEnum("Xpress","XPRESS");
        public static readonly SolverEnum COIN = new SolverEnum("Coin","COIN");

        private SolverEnum(string label,string dbCode) : base(label,dbCode){
            EnumList.Add(this);
        }

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

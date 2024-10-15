using System;
using Solver.CustomVariables;
using Solver.SolverInterface;

namespace Solver
{
    /// <summary>
    /// Main (and custom) class of the solver
    /// The user should call all variable and constraints creation from here
    /// besides read the data, configure and call the mathematical solver
    /// </summary>
    class SolverConfig
    {
        private Model<IProblemData> Model { get; set; }

        public void StartSolver()
        {
            CreateProblemData(true);
            CreateVariables();
        }

        public void CreateProblemData(bool allInstances = true)
        {
            throw new NotImplementedException();
        }

        private void CreateVariables()
        {
            YTVariableFactory.Instance.CreateVariables(Model);
            
        }

        private void CreateConstraints()
        {
            
        }
        
    }
}

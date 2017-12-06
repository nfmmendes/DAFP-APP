namespace Solver.SolverInterface
{
    public interface IVariableFactory<IProblemData>
    {
        bool CreateVariables(Model model);
    }
}
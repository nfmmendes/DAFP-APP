namespace Solver
{
    class AlgorithmParameters
    {
        #region HeuristicPenalties

            public static readonly double SMALL_DELAY_PENALTY = 100;
            public static readonly double MEDIUM_DELAY_PENALTY = 200;
            public static readonly double BIG_DELAY_PENALTY = 400;
            public static readonly double STOP_PENALTY = 50;
            public static readonly double OUT_OF_TIME_WINDOW_DEPARTURE_PENALTY = 200;
        #endregion

        #region HeuristicControlFlow 

        public static readonly double ITERATIONS_WITHOUT_IMPROVEMENT = 10; //Just a example. It's not used yet. If it changes, remove this coment


        #endregion
    }
}

namespace Solver
{
    public record struct OptimizationParameters
    {
        public  bool UseTimeWindows {  get;  set; }
        public  bool PickUpAll { get; set; }
        public  bool DeliverAll { get; set; }
        public  bool StartFromDepot { get; set; }
        public  bool ComeBackToDepot { get; set; }
        public  int TimeLimit { get; set;  }
        public int AverageManWeight { get; set; }
        public int AverageWomanWeight { get; set; }
        public int AverageChildWeight { get; set; }

    }
}

namespace Dama.Core.MoveValidation
{
    public class MoveValidationResult
    {
        public int TotalRules { get; set; }
        public int Failed { get; set; }
        public int Passed { get; set; }
        public bool IsValid { get; set; }
    }
}
using Dama.Tests;

namespace Dama.Core.MoveValidation
{
    public interface IMoveVlidator
    {
        MoveValidationResult IsValid(MoveInfo args);
       
    }
}
namespace Entities.Exceptions
{
    public sealed class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException() : base("Maximum price should be greater than 10 and less than 1000.")
        {
        }
    }
}
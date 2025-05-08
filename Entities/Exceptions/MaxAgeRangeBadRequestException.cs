namespace Entities.Exceptions
{
    public sealed class MaxAgeRangeBadRequestException : BadRequestException
    {
        public MaxAgeRangeBadRequestException() : base("Max age can not be less than min age")
        {
        }
    }
}

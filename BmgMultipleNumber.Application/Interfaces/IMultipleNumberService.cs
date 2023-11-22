using BmgMultipleNumber.Domain.Entities;

namespace BmgMultipleNumber.Application.Interfaces
{
    public interface IMultipleNumberService
    {
        public List<MultipleNumberEntity> CalcMultipleNumber(List<long> numbers, long multipleNumber);   
    }
}
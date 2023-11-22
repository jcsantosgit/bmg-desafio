using BmgMultipleNumber.Application.Interfaces;
using BmgMultipleNumber.Domain.Entities;

namespace BmgMultipleNumber.Application.Services
{
    public class MultipleNumberService : IMultipleNumberService
    {
        public List<MultipleNumberEntity> CalcMultipleNumber(List<long> numbers, long multipleNumber)
        {
            List<MultipleNumberEntity> entities = new List<MultipleNumberEntity>();

            foreach (var number in numbers)
            {
                var entity = new MultipleNumberEntity();
                entity.Number = number;
                entity.IsMultiple = (number % multipleNumber) == 0;
                entities.Add(entity);
            }

            return entities;
        }        
    }
}
using BmgMultipleNumber.Api.Utils;

namespace BmgMultipleNumber.Api.Models
{
    public class MultipleNumberRequest
    {
        public List<long> Numbers { get; set; }

        public void AreValidNumbers()
        {
            // Valida de a lista está vazia.
            if(Numbers.Count == 0) throw new EmptyListException("Lista vazia");

            // Valida se a lista contém números negativos.
            foreach (var number in Numbers)
            {
                if(number < 0) throw new NegativeNumberException("A lista não pode conter número negativo");
            }
        }
    }
}
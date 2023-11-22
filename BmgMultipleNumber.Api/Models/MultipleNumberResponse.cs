namespace BmgMultipleNumber.Api.Models
{
    public class MultipleNumberResponse
    {
        // Construtor sem parametros.
        public MultipleNumberResponse(){}

        // Construtor que recebe uma lista de objetos.
        public MultipleNumberResponse(List<MultipleNumberModelView> models)
        {
            Result = models;
        }
        
        public List<MultipleNumberModelView> Result { get; set; }
    }
}
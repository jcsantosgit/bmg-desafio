using BmgMultipleNumber.Domain.Entities;

namespace BmgMultipleNumber.Api.Models
{
    public class MultipleNumberModelView
    {
        public long Number { get; set; }
        public bool IsMultiple { get; set; }        

        public static MultipleNumberModelView ParseToModel(MultipleNumberEntity entity)
        {
            try
            {
                MultipleNumberModelView model = new MultipleNumberModelView();
                model.Number = entity.Number;
                model.IsMultiple = entity.IsMultiple;

                return model;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<MultipleNumberModelView> ParseToModels(List<MultipleNumberEntity> entities)
        {
            try
            {
                List<MultipleNumberModelView> models = new List<MultipleNumberModelView>();

                foreach (var entity in entities)
                {
                    models.Add(ParseToModel(entity));
                }

                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
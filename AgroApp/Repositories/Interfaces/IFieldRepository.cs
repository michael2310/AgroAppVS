using AgroApp.Models;
using System.Collections;
namespace AgroApp.Repositories
{
    public interface IFieldRepository
    {
        FieldModel GetFieldById(int fieldId);
        IEnumerable<FieldModel> GetFields();
        IEnumerable<FieldModel> GetFieldsByFarmId(int farmId);
        void AddField(FieldModel field);
        void UpdateField(int fieldId, FieldModel field);
        void DeleteField(int fieldId);
    }
}

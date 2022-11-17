using AgroApp.Data;
using AgroApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroApp.Repositories
{
    public class FieldRepository : IFieldRepository
    {

        private readonly ApplicationDbContext _context;
        public FieldRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public FieldModel GetFieldById(int fieldId)
        => _context.Fields.Include(m => m.Entry).SingleOrDefault(x => x.FieldId == fieldId);

        public IEnumerable<FieldModel> GetFields()
        => _context.Fields;

        public IEnumerable<FieldModel> GetFieldsByFarmId(int farmId)
        {
            List<FieldModel> fields = new List<FieldModel>();
            foreach(FieldModel field in this.GetFields())
            {
                if(field.FarmId == farmId)
                {
                    fields.Add(field);
                }
            }
            return fields;
        }

        public void DeleteField(int fieldId)
        {
            var result = _context.Fields.SingleOrDefault(x => x.FieldId == fieldId);
            if (result != null)
            {
                _context.Fields.Remove(result);
            }

            _context.SaveChanges();
        }

        public void AddField(FieldModel field)
        {
           _context.Fields.Add(field);
            _context.SaveChanges();
        }

        public void UpdateField(int fieldId, FieldModel field)
        {
            var result = _context.Fields.SingleOrDefault(x => x.FieldId == fieldId);
            if(result != null)
            {
                result.Number = field.Number;
                result.Area = field.Area;
                result.Name = field.Name;

                _context.SaveChanges();
            }
        }
    }
}

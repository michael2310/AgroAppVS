using AgroApp.Data;
using AgroApp.Models;

namespace AgroApp.Repositories
{
    public class EntryRepository : IEntryRepository
    {

        private readonly ApplicationDbContext _context;

        public EntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddEntry(EntryModel entry)
        {
            _context.Entries.Add(entry);
            _context.SaveChanges();
        }

        public void DeleteEntry(int entryId)
        {
            var result = _context.Entries.SingleOrDefault(x => x.EntryId == entryId);
            if (result != null)
            {
                _context.Entries.Remove(result);
            }

            _context.SaveChanges();
        }

        public IEnumerable<EntryModel> GetEntriesByFieldId(int fieldId)
        {
            var id = fieldId;
            List<EntryModel> entries = new();
            foreach (EntryModel entry in this.GetEntries())
            {
                if (entry.FieldId == fieldId)
                {
                    entries.Add(entry);
                }
            }
            return entries;
        }

        public IEnumerable<EntryModel> GetEntries()
        {
           
            return _context.Entries.ToList();
        }

        public EntryModel GetEntryById(int entryId)
        {
            return _context.Entries.SingleOrDefault(x => x.EntryId == entryId);
        }


        public void UpdateEntry(int entryId, EntryModel entry)
        {
            throw new NotImplementedException();
        }
    }
}

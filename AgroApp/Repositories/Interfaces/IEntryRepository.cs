using AgroApp.Models;

namespace AgroApp.Repositories
{
    public interface IEntryRepository
    {

        EntryModel GetEntryById(int entryId);
        IEnumerable<EntryModel> GetEntriesByFieldId(int fieldId);
        IEnumerable<EntryModel> GetEntries();
        void AddEntry(EntryModel entry);
        void UpdateEntry(int entryId, EntryModel entry);
        void DeleteEntry(int entryId);
    }
}

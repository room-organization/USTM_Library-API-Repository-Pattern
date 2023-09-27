using Microsoft.EntityFrameworkCore;
using USTMLibrary_API.model;

namespace USTMLibrary_API.Data.Repositories
{
    public class BibliographyRepository : IBibliographyRepository
    {
        private readonly USTMLibrary_APIContext _context;

        public BibliographyRepository(USTMLibrary_APIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bibliography>> GetAll()
        {
            return await _context.Bibliography.ToListAsync();
        }

        public async Task<Bibliography> GetById(int id)
        {
            return await _context.Bibliography.FindAsync(id);
        }

        public async Task Add(Bibliography bibliography)
        {
            _context.Bibliography.Add(bibliography);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Bibliography bibliography)
        {
            _context.Entry(bibliography).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bibliography = await _context.Bibliography.FindAsync(id);
            if (bibliography != null)
            {
                _context.Bibliography.Remove(bibliography);
                await _context.SaveChangesAsync();
            }
        }
    }

}

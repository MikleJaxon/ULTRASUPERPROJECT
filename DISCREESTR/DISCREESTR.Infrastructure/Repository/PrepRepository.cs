using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DISCREESTR.Infrastructure.Data;
using DISCREESTR.DOMAIN;

namespace DISCREESTR.Infrastructure.Repository
{
    public class PrepRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get
            {
                return _context;
            }


        }
        public PrepRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Prep?> GetPrepnameAsync(string Surname)
        {
            return await _context.Preps.Where(p => p.Surname == Surname).FirstOrDefaultAsync();
        }
        public async Task DeletePrepAsync(int Id)
        {
            Prep? prep = await _context.Preps.FindAsync(Id);
            if (prep != null)
            {
                _context.Remove(prep);
                await _context.SaveChangesAsync();
            }
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }
        public async Task<List<Prep>> GetAllPrepsAsync()
        {
            return await _context.Preps.OrderBy(p => p.Surname).ToListAsync();
        }
        public async Task<Prep?> GetByIdAsync(int Id)
        {
            return await _context.Preps.Where(p => p.Id == Id).Include(p => p.Name).FirstOrDefaultAsync();
        }
        public async Task AddPrepAsync(Prep prep)
        {
            _context.Preps.Add(prep);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePrepAsync(Prep prep)
        {
            var existPredm = await _context.Studplans.FindAsync(prep.Id);
            if (existPredm != null)
            {
                _context.Entry(existPredm).CurrentValues.SetValues(prep);

            }
            else
            {
                await _context.SaveChangesAsync();
            }


            await _context.SaveChangesAsync();
        }

    }

}
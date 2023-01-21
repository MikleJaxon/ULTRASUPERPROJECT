using DISCREESTR.DOMAIN;
using DISCREESTR.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DISCREESTR.Infrastructure.Repository
{
    public class StudplanRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public StudplanRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /*public async Task<Studplan> Get*/
        public async Task DeleteAsync(int Id)
        {
            Studplan? studplan = await _context.Studplans.FindAsync(Id);
            if (studplan != null)
            {
                _context.Remove(studplan);
                await _context.SaveChangesAsync();
            }
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }
        public async Task<List<Studplan>> GetAllAsync()
        {
            return await _context.Studplans.OrderBy(p => p.Id).ToListAsync();
        }
        public async Task<Studplan?> GetStudplanAsync(int Id)
        {
            return await _context.Studplans.Where(q => q.Id == Id).FirstOrDefaultAsync();


        }
        public async Task AddStudplanAsync(Studplan studplan)
        {
            _context.Studplans.Add(studplan);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStudplanAsync(Studplan studplan)
        {
            var existStudplan = await _context.Studplans.FindAsync(studplan.Id);
            if (existStudplan != null)
            {
                _context.Entry(existStudplan).CurrentValues.SetValues(studplan);

            }
            else
            {
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }

    }
}

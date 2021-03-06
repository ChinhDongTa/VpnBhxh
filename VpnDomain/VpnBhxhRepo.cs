using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VpnDomain.Models;

namespace VpnDomain
{
    public class VpnBhxhRepo:IVpnBhxhRepo
    {
        readonly VpnBhxhContext db = new();
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VpnBhxh> Find(int id)
        {
            return await db.VpnBhxh.SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<VpnBhxh>> GetAll()
        {
            return await db.VpnBhxh.ToListAsync();
        }

        public Task<IEnumerable<VpnBhxh>> GetExpired(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VpnBhxh>> GetInUse()
        {
            return await db.VpnBhxh.Where(x => x.BeginDate.AddMonths(x.NumMonth) >= DateTime.Now)
                .Include(vpn =>vpn .Staff).ThenInclude(staff => staff.MaPhongBanNavigation)
                .Include(vpn => vpn.Staff).ThenInclude(staff => staff.MaChucVuNavigation).ToListAsync();
        }

        public async Task Save(VpnBhxh item)
        {
            db.Entry(item).State = item.Id == 0 ? EntityState.Added : EntityState.Modified;
            await db.SaveChangesAsync();
        }


        public IQueryable<NhanVien> GetStaffs()
        {
            //var l = db.NhanVien.ToList();
            return db.NhanVien.Where(x => x.NghiViec == false).OrderBy(x => x.HoTen).Include(x=>x.MaPhongBanNavigation).Include(x=>x.MaChucVuNavigation);
        }

        public async Task UpdateStaff(int staffId, string email, string phone)
        {
            var staff = db.NhanVien.Find(staffId);
            if (staff != null)
            {
                if (staff.Email != email)
                {
                    staff.Email = email;
                    db.Entry(staff).State = EntityState.Modified;
                }
                if(staff.DienThoai != phone)
                {
                    staff.DienThoai = phone;
                    db.Entry(staff).State = EntityState.Modified;
                }
                if (db.Entry(staff).State == EntityState.Modified)
                    await db.SaveChangesAsync();
            }    
        }
        
    }
}
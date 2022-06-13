using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VpnDomain.Models;

namespace VpnDomain
{
    public interface IVpnBhxhRepo
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VpnBhxh>> GetAll();

        /// <summary>
        /// Get Vpn Expired
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<IEnumerable<VpnBhxh>> GetExpired(DateTime date);

        /// <summary>
        /// Get Vpn in use
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VpnBhxh>> GetInUse();

        /// <summary>
        /// Find by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<VpnBhxh> Find(int id);

        /// <summary>
        /// Add new or update
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Save(VpnBhxh item);

        /// <summary>
        /// Cập nhật thông tin (chỉ email hoặc phone) từ người đăng ký VPN vào table NhanVien
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task UpdateStaff(int staffId, string email, string phone);

        /// <summary>
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// Get all staff
        /// </summary>
        /// <returns></returns>
        IQueryable<NhanVien> GetStaffs();
    }
}

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
        /// Delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// Get all staff
        /// </summary>
        /// <returns></returns>
        Task<IList<NhanVien>> GetStaffs();
    }
}

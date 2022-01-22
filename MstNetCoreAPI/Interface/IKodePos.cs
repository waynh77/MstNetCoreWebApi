using MstNetCoreAPI.Model;
using MstNetCoreAPI.Models;

namespace MstNetCoreAPI.Interface
{
    public interface IKodePos
    {
        /// <summary>
        /// get list of all kode pos
        /// </summary>
        /// <returns></returns>
        IQueryable<TbKodePosModel> GetKodePosList();

        /// <summary>
        /// get kode pos details by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TbKodePosModel GetKodePosDetailsById(int Id);

        /// <summary>
        ///  add edit kode pos
        /// </summary>
        /// <param name="kodePosModel"></param>
        /// <returns></returns>
        ResponseModel SaveKodePos(TbKodePosModel kodePosModel);


        /// <summary>
        /// delete kode pos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ResponseModel DeleteKodePos(int Id);
    }
}

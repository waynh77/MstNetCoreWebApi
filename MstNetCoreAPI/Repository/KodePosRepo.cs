using MstNetCoreAPI.Interface;
using MstNetCoreAPI.Model;
using MstNetCoreAPI.Models;

namespace MstNetCoreAPI.Repository
{
    public class KodePosRepo : IKodePos
    {
        private readonly MyDbContext _context;
        public KodePosRepo(MyDbContext context)
        {
            _context = context;
        }
        public ResponseModel DeleteKodePos(int Id)
        {
            ResponseModel model = new();
            try
            {
                TbKodePosModel _temp = GetKodePosDetailsById(Id);
                if (_temp != null)
                {
                    _context.Remove<TbKodePosModel>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Kode Pos Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Kode Pos Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public TbKodePosModel GetKodePosDetailsById(int Id)
        {
                TbKodePosModel data = _context.TbKodePos.Where(e => e.Id == Id).FirstOrDefault();
                return data;

        }

        public IQueryable<TbKodePosModel> GetKodePosList()
        {
            return _context.TbKodePos;
        }

        public ResponseModel SaveKodePos(TbKodePosModel kodePosModel)
        {
            ResponseModel model = new();
            try
            {
                TbKodePosModel _temp = GetKodePosDetailsById(kodePosModel.Id);
                if (_temp != null)
                {
                    _temp.NoKodePos = kodePosModel.NoKodePos;
                    _temp.Kelurahan = kodePosModel.Kelurahan;
                    _temp.Kecamatan = kodePosModel.Kecamatan;
                    _temp.Jenis = kodePosModel.Jenis;
                    _temp.Kabupaten = kodePosModel.Kabupaten;
                    _temp.Propinsi = kodePosModel.Propinsi;
                    _context.Update<TbKodePosModel>(_temp);
                    model.Messsage = "Kode Pos Update Successfully";
                }
                else
                {
                    _context.Add<TbKodePosModel>(kodePosModel);
                    model.Messsage = "Kode Pos Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}

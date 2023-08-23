using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL.Controller
{
    public class HoaquaController : ApiController
    {
        //1. Hiện thị toàn bộ sản phẩm
        [HttpGet]
        public List<hoaqua> GetAllHoaqua()
        {
            HoaquaDataContext HoaquaDataContext = new
           HoaquaDataContext();
            return HoaquaDataContext.hoaquas.ToList();
        }
        //2. Hiện thị từng sản phẩm
        [HttpGet]
        public hoaqua GethoaquaById(string id)
        {
            HoaquaDataContext DBhoaquaDataContext = new
            HoaquaDataContext();
            return DBhoaquaDataContext.hoaquas.FirstOrDefault(x =>
           x.mahoaqua == id);
        }
        
        //3. Thêm một sản phẩm
       [HttpPost]
        public bool InsertNewCustomer(string id, string name,
string loaihq, int dongianhap, int dongiaban, string anh, string mota, string trongluong)
        {
            try
            {
                HoaquaDataContext HoaquaDataContext = new
               HoaquaDataContext();
                hoaqua customer = new hoaqua();
                customer.mahoaqua = id;
                customer.Tenhoaqua = name;
                customer.Maloai = loaihq;
                customer.dongiaban = dongiaban;
                customer.Dongianhap = dongianhap;
                //    customer.Anh = "img/" + anh;
                customer.Anh = anh;
                customer.Mota = mota;
                customer.trongluong = trongluong;

                HoaquaDataContext.hoaquas.InsertOnSubmit(customer);
                HoaquaDataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //4. Sửa một sản phẩm
        [HttpPut]
        public bool UpdateCustomer(string id, string name,
string loaihq, int dongianhap, int dongiaban, string anh, string mota, string trongluong)
        {
            try
            {
                HoaquaDataContext HoaquaDataContext = new
               HoaquaDataContext();
                //Lấy mã khách đã có
                hoaqua customer =
             HoaquaDataContext.hoaquas.FirstOrDefault(x => x.mahoaqua == id);
                if (customer == null) return false;
                customer.mahoaqua = id;
                customer.Tenhoaqua = name;
                customer.Maloai = loaihq;
                customer.dongiaban = dongiaban;
                customer.Dongianhap = dongianhap;
                customer.Anh = anh;
                customer.Mota = mota;
                customer.trongluong = trongluong;
             //  HoaquaDataContext.hoaquas.InsertOnSubmit(customer);
                HoaquaDataContext.SubmitChanges();//Xác nhận chỉnh sửa
                return true;
            }
            catch
            {
                return false;
            }
        }

        //5.Xóa một sản phẩm
        [HttpDelete]
        public bool DeleteCustomer(string mahoaqua)
        {
            try
            {
                HoaquaDataContext HoaquaDataContext = new
                HoaquaDataContext();
                //Lấy mã khách đã có
               hoaqua customer =
                HoaquaDataContext.hoaquas.FirstOrDefault(x => x.mahoaqua == mahoaqua);
                HoaquaDataContext.hoaquas.DeleteOnSubmit(customer);
                HoaquaDataContext.SubmitChanges();
                return true;
            }
            catch

            {
                return false;
            }
        }
        //6. Tìm kiếm một sản phẩm

        [HttpGet]
        [Route("api/Hoaqua/SearchhqByname/{name}")]
        public List<hoaqua> SearchhqByid(string name)
        {
            HoaquaDataContext db = new HoaquaDataContext();
            return db.hoaquas.Where(x => x.Tenhoaqua.Contains(name)).ToList();
        }

    }
}
    


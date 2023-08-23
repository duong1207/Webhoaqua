using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL.Controller
{
    public class LoaihqController : ApiController
    {
        [HttpGet]
        public List<Loaihoaqua> GetAllLHoaqua()
        {
            HoaquaDataContext HoaquaDataContext = new
           HoaquaDataContext();
            return HoaquaDataContext.Loaihoaquas.ToList();
        }


    }
}

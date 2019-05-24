using AracBusinessLogicLayer;
using aracDAL.Concrete.Repository;
using AutoMapper;
using DTOarac.DTO;
using EntityArac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaSistemi.RESTAPI.Controllers
{
    public class calisanController : Controller
    {
        // GET: kullanici
        public ActionResult IndexCalisan()
        {
            return View();
        }
        private CalisanManager calisanService = new CalisanManager(new CalisanEntityFramework());

        public void Add(CalisanDTO entity)
        {
            var calisan = Mapper.Map<tblCalisan>(entity);
            calisanService.Add(calisan);

        }

        public bool Delete(int id)
        {
            return calisanService.Delete(id);
        }

        public CalisanDTO Get(int id)
        {
            var entity = calisanService.Get(id);
            return Mapper.Map<CalisanDTO>(entity);
        }

        public List<CalisanDTO> GetAll()
        {
            var calisanlar = calisanService.GetAll();

            return Mapper.Map<List<CalisanDTO>>(calisanlar).ToList();
        }

        public CalisanDTO calisanGiris(string eposta, string sifre)
        {
            var entity = calisanService.CalisanGiris(eposta, sifre);
            return Mapper.Map<CalisanDTO>(entity);
        }

        public void Update(CalisanDTO entity)
        {
            var calisan = Mapper.Map<tblCalisan>(entity);
            calisanService.Update(calisan);
        }
    }
}
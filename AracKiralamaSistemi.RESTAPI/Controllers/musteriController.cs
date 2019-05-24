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
    public class musteriController : Controller
    {
        private MusteriManager musteriService = new MusteriManager(new MusteriEntityFramework());

        // GET: musteri
        public ActionResult IndexMusteri()
        {
            return View();
        }

        public void Add(MusteriDTO entity)
        {
            var musteri = Mapper.Map<tblMusteri>(entity);
            musteriService.Add(musteri);
        }

        public bool Delete(int id)
        {
            return musteriService.Delete(id);
        }

        public MusteriDTO Get(int id)
        {
            var entity = musteriService.Get(id);
            return Mapper.Map<MusteriDTO>(entity);
        }

        public List<MusteriDTO> GetAll()
        {
            var musteriler = musteriService.GetAll();

            return Mapper.Map<List<MusteriDTO>>(musteriler).ToList();
        }

        public MusteriDTO MusteriGiris(string eposta, string sifre)
        {
            var entity = musteriService.MusteriGiris(eposta, sifre);
            return Mapper.Map<MusteriDTO>(entity);
        }

        public void Update(MusteriDTO entity)
        {

            var musteri = Mapper.Map<tblMusteri>(entity);
            musteriService.Update(musteri);
        }
    }
}
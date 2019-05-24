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
    public class raporlamaController : Controller
    {
        // GET: raporlama
        public ActionResult IndexRaporlama()
        {
            return View();
        }

        RaporlarManager raporlarManager = new RaporlarManager(new RaporlarEntityFramework());
        private AraclarManager araclarManager = new AraclarManager(new AracEntityFramework());

        public void Add(RaporlarDTO entity)
        {

            raporlarManager.Add(new tblRaporlar
            {
                aracID = entity.aracID,
                musteriID = entity.musteriID,
                alisTarihi = entity.alisTarihi,
                teslimTarihi = entity.teslimTarihi,
                alisKM = entity.alisKM,
                teslimKM = entity.teslimKM,
                toplamUcret = entity.toplamUcret,
                durum = true,
                sirketID = entity.sirketID

            });
        }

        public bool Delete(int id)
        {
            return raporlarManager.Delete(id);
        }

        public RaporlarDTO Get(int id)
        {
            var entity = raporlarManager.Get(id);
            return Mapper.Map<RaporlarDTO>(entity);
        }

        public List<RaporlarDTO> GetAll()
        {
            var rezervasyonlar = raporlarManager.GetAll();
            return Mapper.Map<List<RaporlarDTO>>(rezervasyonlar).ToList();
        }

        public void Update(RaporlarDTO entity)
        {
            var rezervasyon = Mapper.Map<tblRaporlar>(entity);
            raporlarManager.Update(rezervasyon);
        }
    }
}
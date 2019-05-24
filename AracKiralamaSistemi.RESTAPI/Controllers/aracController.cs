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
    public class aracController : Controller
    {
        // GET: arac
        public ActionResult IndexAraclar()
        {
            return View();
        }

         

        private AraclarManager araclarManager;
        
        public ActionResult aracAdd(AraclarDTO entity)
        {
            araclarManager = new AraclarManager(new AracEntityFramework());
            try
            {
                var arac = Mapper.Map<tblAraclar>(entity);

                araclarManager.Add(arac);
            }
            catch (Exception e)
            {
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                araclarManager.Delete(id);
                return View();

            }
            catch (Exception e)
            {
                return View();
            }


        }

        public AraclarDTO Get(string id)
        {

            var entity = araclarManager.Get(Convert.ToInt32(id));


            return Mapper.Map<tblAraclar, AraclarDTO>(entity);

        }

        public List<AraclarDTO> GetAll()
        {
            var araclar = araclarManager.GetAll();

            return Mapper.Map<List<AraclarDTO>>(araclar);

        }

        public bool Update(AraclarDTO entity)
        {
            try
            {
                var arac = Mapper.Map<tblAraclar>(entity);

                araclarManager.Update(arac);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
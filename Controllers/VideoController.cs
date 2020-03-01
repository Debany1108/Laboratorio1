using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MVCPlantilla.Utilerias;

namespace MvcPlantilla.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mostrar()
        {
            ViewData["Video"] = BaseHelper.ejecutarConsulta("Select*from Video", CommandType.Text);
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int idVideo, string titulo, int reproducciones, string url, string creador)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@reproducciones", reproducciones));
            parametros.Add(new SqlParameter("@url",url));
            parametros.Add(new SqlParameter("@creador",creador));
            BaseHelper.ejecutarSentencia("Insert into Video values (@idVideo, @titulo, @reproducciones, @url, @creador)", CommandType.Text, parametros);
            return View();
        }
         public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
         public ActionResult Update(int idVideo, string titulo, string reproducciones, string url, string creador)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@reproducciones", reproducciones));
            parametros.Add(new SqlParameter("@url", url));
            parametros.Add(new SqlParameter("@creador", creador));

            BaseHelper.ejecutarSentencia("Update Video set titulo=@titulo, reproducciones=@reproducciones, url=@url, creador=@creador where idVideo=@idVideo", CommandType.Text, parametros);
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int idVideo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));

            BaseHelper.ejecutarSentencia("Delete from Video where idVideo=@idVideo", CommandType.Text, parametros);
            return View();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using web_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace web_mvc.Controllers
{
    public class PlataformaController : Controller
    {
        String api = "https://localhost:7052/api/ApiNegocios/";
        // GET: PlataformaController
        async Task<List<Actividad>> actividades()
        {
            List<Actividad> auxiliar = new List<Actividad>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                HttpResponseMessage mensaje = await cliente.GetAsync("actividades");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    auxiliar = JsonConvert.DeserializeObject<List<Actividad>>(respuesta);
                }
            }
            return auxiliar;
        }
        async Task<List<Solicitud>> solicitudes()
        {
            List<Solicitud> auxiliar = new List<Solicitud>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                HttpResponseMessage mensaje = await cliente.GetAsync("solicitudes");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    auxiliar = JsonConvert.DeserializeObject<List<Solicitud>>(respuesta);
                }
            }
            return auxiliar;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.solicitudes = await solicitudes();
            ViewBag.titulo = "Agregar";
            ViewBag.actividades = new SelectList(await actividades(), "idact", "desact");
            //envio un nuevo Seller, GET
            return View(await Task.Run(() => new Solicitud()));
        }
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.solicitudes = await solicitudes();
            ViewBag.actividades = new SelectList(await actividades(), "idact", "desact");
            ViewBag.titulo = "Actualizar";
            Solicitud reg = new Solicitud();
            foreach(Solicitud bean in ViewBag.solicitudes){
                if((bean.nsolicitud+"")==id)
                {   reg = bean;
                    break;
                }
            }
            return View("Index", await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Solicitud reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                reg.fsolicitud = DateTime.Now;
                reg.desact = "-";
                cliente.BaseAddress = new Uri(api);
                //convierto a reg en un cadena json de formato utf-8 y media: applicacion/json
                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                //ejecutar el Put
                HttpResponseMessage respuesta = await cliente.PostAsync("registrar", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            //al finalizar refrescar la pagina
            ViewBag.mensaje = mensaje;
            ViewBag.solicitudes = await solicitudes();
            ViewBag.actividades = new SelectList(await actividades(), "idact", "desact");
            ViewBag.titulo = "Agregar";
            //envio un nuevo Seller, GET
            return View("Index", await Task.Run(() => new Solicitud()));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(Solicitud reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                reg.fsolicitud = DateTime.Now;
                reg.desact = "-";
                cliente.BaseAddress = new Uri(api);
                //convierto a reg en un cadena json de formato utf-8 y media: applicacion/json
                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                //ejecutar el Put
                HttpResponseMessage respuesta = await cliente.PutAsync("actualizar", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            //al finalizar refrescar la pagina
            ViewBag.mensaje = mensaje;
            ViewBag.solicitudes = await solicitudes();
            ViewBag.actividades = new SelectList(await actividades(), "idact", "desact");
            ViewBag.titulo = "Agregar";
            //envio un nuevo Seller, GET
            return View("Index", await Task.Run(() => new Solicitud()));
        }

    }
}

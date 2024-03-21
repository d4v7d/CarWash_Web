using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using PruebaTecnica.WEB.Models;

namespace PruebaTecnica.WEB.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        // GET: Servicios
        public async Task<IActionResult> Index()
        {
            var json = await client.GetStringAsync(API.URL + "Servicios");
            var servicios = JsonConvert.DeserializeObject<IEnumerable<Servicio>>(json);
            return View(servicios);
        }

        // GET: Servicios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var json = await client.GetStringAsync(API.URL + $"Servicios/{id}");
            var servicio = JsonConvert.DeserializeObject<Servicio>(json);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // GET: Servicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Create([Bind("ServicioId,Nombre,Descripcion,Precio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                servicio.ServicioId = Guid.NewGuid();
                HttpResponseMessage response = await client.PostAsync(API.URL + "Servicios", new StringContent(JsonConvert.SerializeObject(servicio), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, "Failed to create the Servicio.");
                }               
            }
            return false;
        }

        // GET: Servicios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var json = await client.GetStringAsync(API.URL + $"Servicios/{id}");
            var servicio = JsonConvert.DeserializeObject<Servicio>(json);

            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Edit([Bind("ServicioId,Nombre,Descripcion,Precio")] Servicio servicio)
        {

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsync(API.URL + $"Servicios/{servicio.ServicioId}", new StringContent(JsonConvert.SerializeObject(servicio), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        // GET: Servicios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var json = await client.GetStringAsync(API.URL + $"Servicios/{id}");
            var servicio = JsonConvert.DeserializeObject<Servicio>(json);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<bool> DeleteConfirmed(Guid id)
        {
            HttpResponseMessage response = await client.DeleteAsync(API.URL + $"Servicios/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}

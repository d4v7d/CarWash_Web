using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PruebaTecnica.WEB.Models;

namespace PruebaTecnica.WEB.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        private readonly HttpClient client = new();

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var json = await client.GetStringAsync(API.URL + "Citas");
            var citas = JsonConvert.DeserializeObject<IEnumerable<Cita>>(json);
            return View(citas);
        }

        public async Task<IActionResult> Cliente()
        {
            var clienteId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var json = await client.GetStringAsync(API.URL + $"Citas/Cliente/{clienteId}");
            var citas = JsonConvert.DeserializeObject<IEnumerable<Cita>>(json);
            return View(citas);
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var json = await client.GetStringAsync(API.URL + $"Citas/{id}");
            var cita = JsonConvert.DeserializeObject<Cita>(json);

            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public async Task<IActionResult> Create()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var json = await client.GetStringAsync(API.URL + "Servicios");
            var servicios = JsonConvert.DeserializeObject<IEnumerable<Servicio>>(json);
            ViewData["ServicioId"] = new SelectList(servicios, "ServicioId", "Nombre");
            var cita = new Cita
            {
                ClienteId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Estado = "Programada",
            };
            return View(cita);
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Create([Bind("ClienteId,Estado,Fecha,ServicioId")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                cita.CitaId = Guid.NewGuid();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
                HttpResponseMessage response = await client.PostAsync(API.URL + "Citas", new StringContent(JsonConvert.SerializeObject(cita), Encoding.UTF8, "application/json"));
                return response.IsSuccessStatusCode;
            }
            return false;
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var json = await client.GetStringAsync(API.URL + $"Citas/{id}");
            var cita = JsonConvert.DeserializeObject<Cita>(json);

            if (cita == null)
            {
                return NotFound();
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var jsonServicios = await client.GetStringAsync(API.URL + "Servicios");
            var servicios = JsonConvert.DeserializeObject<IEnumerable<Servicio>>(jsonServicios);
            ViewData["ServicioId"] = new SelectList(servicios, "ServicioId", "Nombre", cita.ServicioId);
            return View(cita);
        }

        public async Task<IActionResult> EditE(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var json = await client.GetStringAsync(API.URL + $"Citas/{id}");
            var cita = JsonConvert.DeserializeObject<Cita>(json);

            if (cita == null)
            {
                return NotFound();
            }
            var estados = new List<object>()
            {
                new
                {
                    Nombre = "Programada"
                },
                 new
                {
                    Nombre = "Completada"
                },
            };
            ViewData["Estado"] = new SelectList(estados, "Nombre", "Nombre", cita.Estado);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CitaId,Estado,ClienteId,Fecha,ServicioId")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsync(API.URL + $"Citas/{cita.CitaId}", new StringContent(JsonConvert.SerializeObject(cita), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var jsonServicios = await client.GetStringAsync(API.URL + "Servicios");
            var servicios = JsonConvert.DeserializeObject<IEnumerable<Servicio>>(jsonServicios);
            ViewData["ServicioId"] = new SelectList(servicios, "ServicioId", "Nombre", cita.ServicioId);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            var json = await client.GetStringAsync(API.URL + $"Citas/{id}");
            var servicio = JsonConvert.DeserializeObject<Cita>(json);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<bool> DeleteConfirmed(Guid id)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.FindFirstValue("Token"));
            HttpResponseMessage response = await client.DeleteAsync(API.URL + $"Citas/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PruebaTecnica.WEB.Data.Migrations;
using PruebaTecnica.WEB.Models;

namespace PruebaTecnica.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly HttpClient client = new();
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuariosController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var json = await client.GetStringAsync(API.URL + "Usuarios");
            var usuarios = JsonConvert.DeserializeObject<IEnumerable<AspNetUser>>(json);
            foreach (var usuario in usuarios)
            {
                var user = await _userManager.FindByIdAsync(usuario.Id);
                usuario.Rol = _userManager.GetRolesAsync(user).Result.First();
            }
            return View(usuarios);
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var json = await client.GetStringAsync(API.URL + $"Usuarios/{id}");
            var usuario = JsonConvert.DeserializeObject<AspNetUser>(json);
            var user = await _userManager.FindByIdAsync(usuario.Id);
            usuario.Rol = _userManager.GetRolesAsync(user).Result.First();

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var json = await client.GetStringAsync(API.URL + $"Usuarios/{id}");
            var usuario = JsonConvert.DeserializeObject<AspNetUser>(json);

            if (usuario == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(usuario.Id);
            var rol = _userManager.GetRolesAsync(user).Result.First();
            var roles = await _roleManager.Roles.ToListAsync();

            foreach (var r in roles)
            {
                if (rol == r.Name)
                {
                    ViewData["RoleId"] = new SelectList(roles, "Id", "Name", r.Id);
                }
            }

            return View(usuario);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Edit(string id, AspNetUser usuario)
        {
            if (id != usuario.Id)
            {
                return false;
                //return NotFound();
            }

            var user = await _userManager.FindByIdAsync(usuario.Id);
            var roles = await _roleManager.Roles.ToListAsync();
            var rolAnterior = _userManager.GetRolesAsync(user).Result.First();



            if (ModelState.IsValid)
            {
                await _userManager.RemoveFromRoleAsync(user, rolAnterior);

                foreach (var r in roles)
                {
                    if (usuario.RoleId == r.Id)
                    {
                        await _userManager.AddToRoleAsync(user, r.Name);
                    }
                }
                return true;
                //return RedirectToAction(nameof(Index));
            }
            
            foreach (var r in roles)
            {
                if (rolAnterior == r.Name)
                {
                    ViewData["RoleId"] = new SelectList(roles, "Id", "Name", r.Id);
                }
            }
            return false;
            //return View(usuario);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var json = await client.GetStringAsync(API.URL + $"Usuarios/{id}");
            var usuario = JsonConvert.DeserializeObject<AspNetUser>(json);
            var user = await _userManager.FindByIdAsync(id);
            usuario.Rol = _userManager.GetRolesAsync(user).Result.First();
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}

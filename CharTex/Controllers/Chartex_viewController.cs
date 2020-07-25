using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharTex.Models;

namespace CharTex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chartex_viewController : ControllerBase
    {
        private readonly Chartex_Context _context;

        public Chartex_viewController(Chartex_Context context)
        {
            _context = context;
        }

        // GET: api/Chartex_view
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chartex_view>>> Get_Chartex_Views()
        {
            return await _context._Chartex_Views.ToListAsync();
        }

        // GET: api/Chartex_view/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chartex_view>> GetChartex_view(long id)
        {
            var chartex_view = await _context._Chartex_Views.FindAsync(id);

            if (chartex_view == null)
            {
                return NotFound();
            }

            return chartex_view;
        }

       
    }
}

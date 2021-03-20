using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models.Response;
using WebService.Models;
using WebService.Models.Request;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Beer>> response = new Response<List<Beer>>();

            try
            {
                using (BlazorCrudContext db = new BlazorCrudContext())
                {
                    var lst = db.Beers.ToList();
                    response.success = 1;
                    response.data = lst;
                }
            } catch(Exception ex)
            {
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Response<Beer> response = new Response<Beer>();

            try
            {
                using (BlazorCrudContext db = new BlazorCrudContext())
                {
                    var lst = db.Beers.Find(id);
                    response.success = 1;
                    response.data = lst;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(BeerRequest request)
        {
            Response<object> response = new Response<object>();

            try
            {
                using (BlazorCrudContext db = new BlazorCrudContext())
                {
                    Beer beer = new Beer();
                    beer.Name = request.name;
                    beer.Maker = request.maker;
                    db.Beers.Add(beer);
                    db.SaveChanges();
                    response.success = 1;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(BeerRequest request)
        {
            Response<object> response = new Response<object>();

            try
            {
                using (BlazorCrudContext db = new BlazorCrudContext())
                {
                    Beer beer = db.Beers.Find(request.id);
                    beer.Name = request.name;
                    beer.Maker = request.maker;
                    db.Entry(beer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    response.success = 1;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response<object> response = new Response<object>();

            try
            {
                using (BlazorCrudContext db = new BlazorCrudContext())
                {
                    Beer beer = db.Beers.Find(id);
                    db.Remove(beer);
                    db.SaveChanges();
                    response.success = 1;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return Ok(response);
        }
    }
}

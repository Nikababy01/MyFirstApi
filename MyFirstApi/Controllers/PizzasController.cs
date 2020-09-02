using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    // these are attributes:
    //adds where this should be exposed on the internet/ replace [controller] with pizzas below
    //[Route("api/[controller]")]
    // returns JSON data
    [Route("api/pizzas")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        List<Pizza> _pizzas;
        public PizzasController()
        {

            var pizza = new Pizza { Id = 1, Size = "Medium", Toppings = new List<string> { "Pepperoni" } };
            var pizza2 = new Pizza { Id = 2, Size = "Medium", Toppings = new List<string> { "Sausage" } };
            var pizza3 = new Pizza { Id = 3, Size = "Medium", Toppings = new List<string> { "Mushroom" } };

            _pizzas = new List<Pizza> { pizza, pizza2, pizza3 };

        }

        [HttpGet]
        public List<Pizza> GetAllPizzas()
        {
            return _pizzas;
        }
        // get a single pizza

        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            var result = _pizzas.SingleOrDefault(pizza => pizza.Id == id);
            if (result == null)
            {
                return NotFound($"Could not find a pizza with the id {id}");
            }

            return Ok (result);
        }
    }
}


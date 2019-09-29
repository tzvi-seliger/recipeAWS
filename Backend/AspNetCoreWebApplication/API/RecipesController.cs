using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Http;
using System.Text;
using System.Web.Mvc;
using AspNetCoreWebApplication.DAO;
using AspNetCoreWebApplication.Services;
using AspNetCoreWebApplication.API_DAO;

namespace AspNetCoreWebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    public class RecipesController : ControllerBase
    {
        private readonly IDBConn _dBConn;
        public RecipesController(IDBConn dbconn)
        {
            _dBConn = dbconn;
        }

        [HttpGet]
        public List<FullRecipe> Get()
        {
            return new RecipeAPI_DAO(_dBConn).GetAllRecipes();
        }

        [HttpGet]
        [Route("{id:int}")]
        public FullRecipe Get(int id)
        {
            return new RecipeAPI_DAO(_dBConn).GetRecipe(id);
        }

        [HttpPost]
        public bool Post(FullRecipe fullRecipe)
        {
            new RecipeAPI_DAO(_dBConn).PostRecipe(fullRecipe);
            return true;
        }

        [HttpPut]
        public bool Put(FullRecipe fullRecipe)
        {
            new RecipeAPI_DAO(_dBConn).UpdateRecipe(fullRecipe);
            return true;
        }
    }
}
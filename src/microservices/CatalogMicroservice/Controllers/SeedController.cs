using CatalogMicroservice.Model;
using CatalogMicroservice.Repository;
using CatalogMicroservice.Setup.CountryStateCity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SeedController(ICatalogRepository catalogRepository, ICategoryRepository categoryRepository, IWebHostEnvironment env)
        {
            _catalogRepository = catalogRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = env;
        }

        [HttpPost("populate")]
        public async Task<IActionResult> Populate()
        {
            try
            {
                var path = _webHostEnvironment.ContentRootPath;

                var categoryStateCity = _categoryRepository.GetCategory("State/City");
                if (categoryStateCity == null)
                {
                    var stateCity = new CategoryItem()
                    {
                        Id = new Guid("74b16282-c873-45a2-9424-39b05a01f68b"),
                        Name = "State/City"
                    };

                    var jsonPath = $"{path}/Setup/CountryStateCity/countriesStatesCities.json";
                    var stringData = System.IO.File.ReadAllText(jsonPath);
                    var jsonData = JsonConvert.DeserializeObject<List<Country>>(stringData);

                    var dataColombia = jsonData.Where(ct => ct.Iso2 == "CO").FirstOrDefault();

                    if (dataColombia != null)
                    {
                        _categoryRepository.InsertCategory(stateCity);
                        foreach (var state in dataColombia.States)
                        {
                            var stateId = Guid.NewGuid();
                            var stateItem = new CatalogItem()
                            {
                                Id = stateId,
                                Category = stateCity,
                                Key = state.Id.ToString(),
                                Value = state.Name,
                            };

                            _catalogRepository.InsertCatalogItem(stateItem);
                            var cities = state.Cities.ToList();
                            if (cities.Any())
                            {
                                foreach (var city in cities)
                                {
                                    var cityItem = new CatalogItem()
                                    {
                                        Id = Guid.NewGuid(),
                                        ParentKey = stateItem.Key,
                                        Category = stateCity,
                                        Key = city.Id.ToString(),
                                        Value = city.Name,
                                    };
                                    _catalogRepository.InsertCatalogItem(cityItem);
                                }
                            }
                        }
                    }
                }

                var category = _categoryRepository.GetCategory("Identification type");
                if (category == null)
                {
                    var categoryItem = new CategoryItem()
                    {
                        Id = new Guid("1579bcb2-c017-47e1-bdec-065174a74842"),
                        Name = "Identification type"
                    };

                    var jsonPath = $"{path}/Setup/KeyValue/documentType.json";
                    var stringData = System.IO.File.ReadAllText(jsonPath);
                    var keyValueData = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringData);

                    if (keyValueData != null)
                    {
                        _categoryRepository.InsertCategory(categoryItem);
                        foreach (var keyValuePair in keyValueData)
                        {
                            var catalogId = Guid.NewGuid();
                            var catalogItem = new CatalogItem()
                            {
                                Id = catalogId,
                                Category = categoryItem,
                                Key = keyValuePair.Key,
                                Value = keyValuePair.Value,
                            };

                            _catalogRepository.InsertCatalogItem(catalogItem);

                        }
                    }
                }

                var documentStatusCategory = _categoryRepository.GetCategory("Document status");
                if (documentStatusCategory == null)
                {
                    var categoryItem = new CategoryItem()
                    {
                        Id = new Guid("6e25effa-da93-45e4-8dd3-8a5a72d8aa4d"),
                        Name = "Document status"
                    };


                    var jsonPath = $"{path}/Setup/KeyValue/documentStatus.json";
                    var stringData = System.IO.File.ReadAllText(jsonPath);
                    var keyValueData = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringData);

                    if (keyValueData != null)
                    {
                        _categoryRepository.InsertCategory(categoryItem);
                        foreach (var keyValuePair in keyValueData)
                        {
                            var catalogId = Guid.NewGuid();
                            var catalogItem = new CatalogItem()
                            {
                                Id = catalogId,
                                Category = categoryItem,
                                Key = keyValuePair.Key,
                                Value = keyValuePair.Value,
                            };

                            _catalogRepository.InsertCatalogItem(catalogItem);

                        }
                    }
                }


                return CreatedAtAction(nameof(Populate), new { categories = new string[] { "State/City", "Identification type", "Document status" } });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}

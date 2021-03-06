﻿namespace PetFoodShop.Foods.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetFoodShop.Controllers;
    using PetFoodShop.Foods.Controllers.Models;
    using PetFoodShop.Foods.Services;
    using PetFoodShop.Foods.Services.Models.FoodBrand;
    using PetFoodShop.Infrastructure;
    using System.Threading.Tasks;

    public class BrandsController : ApiController
    {
        private readonly IFoodBrandService brandService;
        private readonly IMapper mapper;

        public BrandsController(IFoodBrandService brandService, IMapper mapper)
        {
            this.brandService = brandService;
            this.mapper = mapper;
        }

        [HttpPost(nameof(Create))]
        [AuthorizeAdministrator]
        public async Task<IActionResult> Create(BrandInputModel model)
        {
            var serviceModel = this.mapper.Map<BrandModel>(model);
            var foodBrandId = await this.brandService.Create(serviceModel);
            return this.Created($"/foods/{foodBrandId}/brands", foodBrandId);
        }
    }
}

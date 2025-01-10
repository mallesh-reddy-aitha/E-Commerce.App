using E_Commerce.App.API.RequestHelpers;
using E_Commerce.App.Core.Entities;
using E_Commerce.App.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CreatePagedResult<T>(IGenericRepository<T> genericRepository,
            ISpecification<T> specification, int pageIndex, int pageSize) where T : BaseEntity
        {
            var items = await genericRepository.ListAsync(specification);
            var count = await genericRepository.CountAsync(specification);

            var pagination = new Pagination<T>(pageIndex,
                pageSize, count, items);
            return Ok(pagination);
        }
    }
}

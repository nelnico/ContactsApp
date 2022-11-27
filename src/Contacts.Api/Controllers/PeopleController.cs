using AutoMapper;
using Contacts.Api.Common.Extensions;
using Contacts.Core.Common.Pagination;
using Contacts.Core.Dtos;
using Contacts.Core.Entities;
using Contacts.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Api.Controllers;

public class PeopleController : BaseApiController
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _uow;

    public PeopleController(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet("searchoptions")]
    public IActionResult GetSearchOptions()
    {
        return Ok(new PersonSearchOptionsDto());
    }


    [AllowAnonymous]
    [HttpGet("search")]
    public async Task<ActionResult<PagedList<PersonDto>>> SearchAsync([FromQuery] PersonSearchParams searchParams)
    {
        var data = await _uow.People.SearchAsync(searchParams);
        Response.AddPaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);
        return Ok(data);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetById(int id)
    {
        var data = await _uow.People.GetByIdAsync(id);

        if (data == null) return NotFound();

        var result = _mapper.Map<Person, PersonDto>(data);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpDelete("{id}")]
    public async Task<ActionResult<PersonDto>> Delete(int id)
    {
        var data = await _uow.People.GetByIdAsync(id);

        if (data == null) return NotFound();

        _uow.People.Delete(data);
        await _uow.CompleteAsync();

        return Ok();
    }
}
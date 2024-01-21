using AutoMapper;
using Cadof.Domain;
using Cadof.Infra.Context;
using Cadof.Shared.Models.Character;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cadof.Api.Controllers;

[ApiController]
[Authorize]
[Route("v1/[controller]")]
public class CharacterController
{
    private readonly IDbContext _db;
    private readonly IMapper _mapper;

    public CharacterController(IDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<List<CharacterModel>> GetTop(int take)
    {
        var top = await _db.Characters.Take(take).ToListAsync();
        return _mapper.Map<List<CharacterModel>>(top);
    }
}

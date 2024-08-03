using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rpg.Infra.Context;
using Rpg.Shared.Models.Character;

namespace Rpg.Api.Controllers;

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

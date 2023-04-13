using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DOTNET_RPG.Models;
using DOTNET_RPG.Services.characterService;
using DOTNET_RPG.Dtos.Character;

namespace DOTNET_RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController: ControllerBase
    {
        // en la linea 16 hasta la linea 21 es la inyeccion de dependencia
        private readonly ICharacterService _characterService;
        
        public  CharacterController(ICharacterService characterServices)
        {
            _characterService=characterServices;
        }
       
       // mi servisio de character service envia la informacion y los metodoso en el controlador son los que tienen que esperar

        [HttpGet]
        public async Task<ActionResult<List<GetCharacterDto>>> Get()
        {
           return  Ok(await _characterService.GetAllCharacter());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterDto>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetCharacterDto>>>AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            return Ok(await _characterService.DeleteCharacter(id));
        }

        [HttpPut]
        public async Task<ActionResult<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto newCharacter)
        {
            return Ok(await _characterService.UpdateCharacter(newCharacter));
        }

    

    }
}
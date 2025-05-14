using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<List<GroupDto>>> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroups();
            return Ok(groups);
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetGroupById(long id)
        {
            var group = await _groupService.GetGroupById(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        // POST: api/Group
        [HttpPost]
        public async Task<ActionResult<GroupDto>> CreateGroup([FromBody] Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            group.CreatedAt = DateTime.UtcNow; // Gán thời gian tạo
            var createdGroup = await _groupService.CreateGroup(group);
            return CreatedAtAction(nameof(GetGroupById), new { id = createdGroup.Id }, createdGroup);
        }

        // PUT: api/Group/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(long id, [FromBody] Group group)
        {
            if (id != group.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingGroup = await _groupService.GetById(id);
            if (existingGroup == null)
            {
                return NotFound();
            }

            await _groupService.UpdateGroup(group);
            return NoContent();
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(long id)
        {
            var group = await _groupService.GetById(id);
            if (group == null)
            {
                return NotFound();
            }

            await _groupService.DeleteGroup(id);
            return NoContent();
        }
    }
}
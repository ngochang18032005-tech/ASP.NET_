using ASP.DTOs;
using ASP.Helpers;
using ASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers.API;

[ApiController]
[Route("api/rooms")]
public class RoomApiController : ControllerBase
{
    private readonly RoomService _service;

    public RoomApiController(RoomService service)
    {
        _service = service;
    }

    // GET with paging/filter
    [HttpGet]
    public IActionResult GetAll(int page = 1, int pageSize = 10, string? status = null, string? search = null)
    {
        var data = _service.GetAll(page, pageSize, status, search);

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Get rooms success",
            Data = data
        });
    }

    // GET BY ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var room = _service.GetById(id);
        if (room == null)
            return NotFound(new ApiResponse<object>
            {
                Success = false,
                Message = "Room not found"
            });

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Get room success",
            Data = room
        });
    }

    // CREATE
    [HttpPost]
    public IActionResult Create(CreateRoomDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var room = _service.Create(dto);

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Create room success",
            Data = room
        });
    }

    // UPDATE
    [HttpPut("{id}")]
    public IActionResult Update(int id, CreateRoomDto dto)
    {
        var room = _service.Update(id, dto);
        if (room == null)
            return NotFound();

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Update room success",
            Data = room
        });
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result)
            return NotFound();

        return Ok(new ApiResponse<object>
        {
            Success = true,
            Message = "Delete room success"
        });
    }
}
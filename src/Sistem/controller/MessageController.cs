using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Extentions;
using app.src.Model;
using app.src.Sistem.dto;
using app.src.Sistem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.src.Sistem.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController(IMessageService messageService, UserManager<User> userManager) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SendMessageAsync([FromBody] MessageSendRequest messageRequest)
        {
            var username = User.GetUsername();
            var appUser = await userManager.FindByNameAsync(username);

            if (appUser == null) { return NotFound("user não encontrado"); }

            await messageService.SendMessageAsync(messageRequest, appUser.Id);
            return Ok();
        }
    }
}
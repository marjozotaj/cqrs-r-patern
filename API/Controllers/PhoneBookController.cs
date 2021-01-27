using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.PhoneBook;
using System.Collections.Generic;
using System;

namespace API.Controllers
{
    public class PhoneBookController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Domain.PhoneBook>>> List()
        {
            return await Mediator.Send(new List.ListQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.CreateCommand command)
        {
             return await Mediator.Send(command);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Unit>> Edit(Guid Id, Edit.EditCommand commandd)
        {
            commandd.Id = Id;
            return await Mediator.Send(commandd);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)  
        {
             return await Mediator.Send(new Delete.DeleteCommand { Id = id });
        }

    }
}


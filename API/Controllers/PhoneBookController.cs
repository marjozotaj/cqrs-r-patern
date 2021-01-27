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

        /// <summary>
        /// Retrieve all PhoneBooks
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Domain.PhoneBook>>> List()
        {
            return await Mediator.Send(new List.ListQuery());
        }
        
        /// <summary>
        /// Create new PhoneBook
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.CreateCommand command)
        {
             return await Mediator.Send(command);
        }

        /// <summary>
        /// Edit an PhoneBook
        /// </summary>
        /// <param name="Id" example="84ccb061-6028-43c9-aed8-510195dbe290">The PhoneBook id</param>
        [HttpPut("{Id}")]
        public async Task<ActionResult<Unit>> Edit(Guid Id, Edit.EditCommand commandd)
        {
            commandd.Id = Id;
            return await Mediator.Send(commandd);
        }

        /// <summary>
        /// Delete an PhoneBook
        /// </summary>
        /// <param name="id" example="84ccb061-6028-43c9-aed8-510195dbe290">The PhoneBook id</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)  
        {
             return await Mediator.Send(new Delete.DeleteCommand { Id = id });
        }

    }
}


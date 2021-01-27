using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Presistence.DAL;

namespace Application.PhoneBook
{
   public class Delete
    {
         public class DeleteCommand : IRequest
        {
          public Guid Id {get;set;}
        }
        public class Handler : IRequestHandler<DeleteCommand>
        {
             private readonly IPhoneBookRepository<Domain.PhoneBook> _phoneBookRepository;
            public Handler(IPhoneBookRepository<Domain.PhoneBook> phoneBookRepository)
            {
                _phoneBookRepository = phoneBookRepository;
            }
            public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    await _phoneBookRepository.DeleteAsync(request.Id);
                    return Unit.Value;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }    
            }

            
        }
    }
}

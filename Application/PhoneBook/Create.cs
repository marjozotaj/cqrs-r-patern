using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Presistence.DAL;

namespace Application.PhoneBook
{
    public class Create
    {
        public class CreateCommand : IRequest
        {
            /// <summary>
            /// The name of the entry
            /// </summary>
            /// <example>John Doe</example>
            public string Name { get; set; }
            /// <summary>
            /// The type of phone book entry
            /// </summary>
            /// <example>Cellphone</example>
            public PType PType { get; set; }
            /// <summary>
            /// The phone number
            /// </summary>
            /// <example>+355696542518</example>
            public string Number { get; set; }
        }

        public class Handler : IRequestHandler<CreateCommand>
        {
             private readonly IPhoneBookRepository<Domain.PhoneBook> _phoneBookRepository;
            public Handler(IPhoneBookRepository<Domain.PhoneBook> phoneBookRepository)
            {
                _phoneBookRepository = phoneBookRepository;
            }

            public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                Domain.PhoneBook pb =   new Domain.PhoneBook(request.Name, request.PType, request.Number );

               if( await _phoneBookRepository.InsertAsync(pb) != null) 
               {
                   return Unit.Value;
               }

                throw new Exception("Problem Saving Changes");
            }
        }
    }
}


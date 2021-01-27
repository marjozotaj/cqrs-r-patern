using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Presistence.DAL;

namespace Application.PhoneBook
{
   public class List
    {
        public class ListQuery : IRequest<List<Domain.PhoneBook>> {}             
        public class Handler : IRequestHandler<ListQuery, List<Domain.PhoneBook>>
        {
             private readonly IPhoneBookRepository<Domain.PhoneBook> _phoneBookRepository;
            public Handler(IPhoneBookRepository<Domain.PhoneBook> phoneBookRepository)
            {
                _phoneBookRepository = phoneBookRepository;
            }

            public async Task<List<Domain.PhoneBook>> Handle(ListQuery request, CancellationToken cancellationToken)
            {
                return await _phoneBookRepository.GetEntitiesAsync();
            }
        }
    }
}

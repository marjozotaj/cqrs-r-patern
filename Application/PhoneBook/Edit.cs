using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Presistence;
using Domain;
using Presistence.DAL;
using System.Text.Json.Serialization;

namespace Application.PhoneBook
{
    public class Edit
    {
        public class EditCommand : IRequest
        {
             [JsonIgnore]
            public Guid Id {get;set;}
            public string Name { get; set; }
            public PType PType { get; set; }
            public string Number { get; set; }
        }
        public class Handler : IRequestHandler<EditCommand>
        {
             private readonly IPhoneBookRepository<Domain.PhoneBook> _phoneBookRepository;
            public Handler(IPhoneBookRepository<Domain.PhoneBook> phoneBookRepository)
            {
                _phoneBookRepository = phoneBookRepository;
            }
            public async Task<Unit> Handle(EditCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var pb = await _phoneBookRepository.FindAsync(request.Id);
                    pb.Name = request.Name;
                    pb.Number = request.Number;
                    pb.PType = request.PType;
                    await _phoneBookRepository.UpdateAsync(pb);
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
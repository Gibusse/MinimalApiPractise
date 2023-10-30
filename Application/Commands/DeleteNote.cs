using MediatR;

namespace MinimalApiPractise.Application.Commands;

public class DeleteNote : IRequest
{
    public int Id { get; set; }
}
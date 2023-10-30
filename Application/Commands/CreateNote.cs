using MediatR;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.Commands;

public class CreateNote : IRequest<Note>
{
    public string? Comment { get; set; }
}
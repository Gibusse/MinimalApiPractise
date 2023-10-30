using MediatR;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.Queries;

public class GetNoteById :IRequest<Note>
{
    public int Id { get; set; }
}
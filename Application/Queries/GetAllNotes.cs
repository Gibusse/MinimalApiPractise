using MediatR;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.Queries;

public class GetAllNotes : IRequest<ICollection<Note>>
{
}
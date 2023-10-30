using MediatR;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.Commands;

public class UpdateNote : IRequest<Note>
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public DateTime UpdateAt { get; set; }
}
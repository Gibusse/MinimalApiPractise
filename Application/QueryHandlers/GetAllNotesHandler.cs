using MediatR;
using MinimalApiPractise.Application.Abstractions;
using MinimalApiPractise.Application.Queries;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.QueryHandlers;

public class GetAllNotesHandler : IRequestHandler<GetAllNotes, ICollection<Note>>
{
    private readonly IRepoNote _repoNote;

    public GetAllNotesHandler(IRepoNote repoNote)
    {
        _repoNote = repoNote;
    }

    public async Task<ICollection<Note>> Handle(GetAllNotes request, CancellationToken cancellationToken)
    {
        return await _repoNote.GetNotes();
    }
}
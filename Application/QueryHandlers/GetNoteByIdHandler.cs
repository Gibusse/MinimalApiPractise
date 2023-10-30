using MediatR;
using MinimalApiPractise.Application.Abstractions;
using MinimalApiPractise.Application.Queries;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.QueryHandlers;

public class GetNoteByIdHandler : IRequestHandler<GetNoteById, Note>
{
    private readonly IRepoNote _repoNote;

    public GetNoteByIdHandler(IRepoNote repoNote)
    {
        _repoNote = repoNote;
    }

    public async Task<Note> Handle(GetNoteById request, CancellationToken cancellationToken)
    {
        var note = await _repoNote.GetNoteById(request.Id);
        return note;
    }
}
using MediatR;
using MinimalApiPractise.Application.Abstractions;
using MinimalApiPractise.Application.Commands;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.CommandHandlers;

public class UpdateNoteHandler : IRequestHandler<UpdateNote, Note>
{
    private readonly IRepoNote _noteRepo;

    public UpdateNoteHandler(IRepoNote repoNote)
    {
        _noteRepo = repoNote;
    }
    public async Task<Note> Handle(UpdateNote request, CancellationToken cancellationToken)
    {
        var note = await _noteRepo.UpdateNote(request.Comment, request.Id);
        return note;
    }
}
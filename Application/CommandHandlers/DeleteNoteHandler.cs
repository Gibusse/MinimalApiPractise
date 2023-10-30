using MediatR;
using MinimalApiPractise.Application.Abstractions;
using MinimalApiPractise.Application.Commands;

namespace MinimalApiPractise.Application.CommandHandlers;

public class DeleteNoteHandler : IRequestHandler<DeleteNote>
{
    private readonly IRepoNote _repoNote;

    public DeleteNoteHandler(IRepoNote repoNote)
    {
        _repoNote = repoNote;
    }

    public async Task<Unit> Handle(DeleteNote request, CancellationToken cancellationToken)
    {
        await _repoNote.DeleteNote(request.Id);
        return Unit.Value;
    }
}
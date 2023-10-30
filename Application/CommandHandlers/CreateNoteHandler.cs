using MediatR;
using MinimalApiPractise.Application.Abstractions;
using MinimalApiPractise.Application.Commands;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.CommandHandlers;

public class CreateNoteHandler : IRequestHandler<CreateNote, Note>
{
    private readonly IRepoNote _noteRepo;

    public CreateNoteHandler(IRepoNote repoNote)
    {
        _noteRepo = repoNote;
    }

    public async Task<Note> Handle(CreateNote request, CancellationToken cancellationToken)
    {
        var newNote = new Note
        {
            Comment = request.Comment
        };

        return await _noteRepo.CreateNote(newNote);
    }
}
using MediatR;
using MinimalApiPractise.Application.Commands;
using MinimalApiPractise.Application.Queries;
using MinimalApiPractise.Domain.Models;
using MinimalApiPractise.MinimalApi.Abstractions;
using MinimalApiPractise.MinimalApi.Filters;

namespace MinimalApiPractise.MinimalApi.EndpointDefinitions;

public class PostEndpointDefinition : IEndPointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var notes = app.MapGroup("/api/notes");
        notes.MapGet("/{id}", GetNoteById).WithName("GetNoteById");

        notes.MapPost("/", CreateNote)
            .AddEndpointFilter<NoteValidationFilter>();

        notes.MapGet("/", GetAllNotes);

        notes.MapPut("/{id}", UpdateNote)
            .AddEndpointFilter<NoteValidationFilter>();;

        notes.MapDelete("/{id}", DeleteNote);
    }

    private async Task<IResult> GetNoteById(IMediator mediator, int id)
    {
        var getNote = new GetNoteById { Id = id };
        var post = await mediator.Send(getNote);
        return TypedResults.Ok(post);
    }

    private async Task<IResult> CreateNote(IMediator mediator, Note note)
    {
        var createNote = new CreateNote { Comment = note.Comment };
        var createdNote = await mediator.Send(createNote);
        return Results.CreatedAtRoute("GetNoteById", new { createdNote.Id}, createdNote);
    }

    private async Task<IResult> GetAllNotes(IMediator mediator)
    {
        var getCommand = new GetAllNotes();
        var notes = await mediator.Send(getCommand);
        return TypedResults.Ok(notes);
    }

    private async Task<IResult> UpdateNote(IMediator mediator, Note note, int id)
    {
        var updateNote = new UpdateNote { Id = id, Comment = note.Comment, UpdateAt = DateTime.Now };
        var updatedNote = await mediator.Send(updateNote);
        return Results.Ok(updatedNote);
    }

    private async Task<IResult> DeleteNote(IMediator mediator,int id)
    {
        var deleteNote = new DeleteNote { Id = id };
        await mediator.Send(deleteNote);
        return Results.NoContent();
    }
}
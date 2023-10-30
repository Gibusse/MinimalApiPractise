using Microsoft.EntityFrameworkCore;
using MinimalApiPractise.Application.Abstractions;
using MinimalApiPractise.DataAccess.ApiDbContext;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.DataAccess.Repositories;

public class RepoNote : IRepoNote
{
    private readonly ApiContext _ctx;

    public RepoNote(ApiContext context)
    {
        _ctx = context;
    }
    public async Task<Note> CreateNote(Note toCreate)
    {
        toCreate.CreatedAt = DateTime.Now;
        toCreate.UpdatedAt = DateTime.Now;
        
        await _ctx.Notes.AddAsync(toCreate);
        await _ctx.SaveChangesAsync();

        return toCreate;
    }

    public async Task DeleteNote(int noteId)
    {
        var note = await _ctx.Notes.FirstOrDefaultAsync(n => n.Id == noteId);

        if (note is null) return;

        _ctx.Notes.Remove(note);

        await _ctx.SaveChangesAsync();
    }

    public async Task<Note> GetNoteById(int noteId)
    {
        var note = await _ctx.Notes.FirstOrDefaultAsync(n => n.Id == noteId);

        if (note is null)
        {
            throw new ArgumentNullException(nameof(Note));
        }

        return note;
    }

    public async Task<ICollection<Note>> GetNotes()
    {
        return await _ctx.Notes.ToListAsync();
    }

    public async Task<Note> UpdateNote(string updateNoteContent, int postId)
    {
        var note = await _ctx.Notes.FirstOrDefaultAsync(n => n.Id == postId);

        if (note is null)
        {
            throw new ArgumentNullException(nameof(Note));
        }

        note.UpdatedAt = DateTime.Now;
        note.Comment = updateNoteContent;
        await _ctx.SaveChangesAsync();

        return note;
    }
}
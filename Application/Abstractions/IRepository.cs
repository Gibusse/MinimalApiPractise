using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.Application.Abstractions;

public interface IRepoNote
{
    Task<ICollection<Note>> GetNotes();
    Task<Note> GetNoteById(int noteId);
    Task<Note> CreateNote(Note toCreate);
    Task<Note> UpdateNote(string updateNoteContent, int postId);
    Task DeleteNote(int noteId);
}
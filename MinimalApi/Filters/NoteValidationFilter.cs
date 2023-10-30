
using Microsoft.IdentityModel.Tokens;
using MinimalApiPractise.Domain.Models;

namespace MinimalApiPractise.MinimalApi.Filters;

public class NoteValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var note = context.GetArgument<Note>(1);
        if (note.Comment.IsNullOrEmpty())
            return await Task.FromResult(Results.BadRequest("Note not valid"));

            return await next(context);
    }
}
using Microsoft.AspNetCore.Mvc;
using Person.DTOs;
using Person.Services;

namespace Person.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        app.MapGet("person", (PersonService service) =>
        {
            var persons = service.GetAll();
            return Results.Ok(persons);
        })
        .WithName("GetAllPersons")
        .Produces<List<Person.Models.PersonModel>>(StatusCodes.Status200OK);

        app.MapGet("person/{id:guid}", (Guid id, PersonService service) =>
        {
            var person = service.GetById(id);
            if (person is null)
                return Results.NotFound(new { Message = "Pessoa não encontrada" });

            return Results.Ok(person);
        })
        .WithName("GetPersonById")
        .Produces<Person.Models.PersonModel>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("person", ([FromBody] CreatePersonRequest request, PersonService service) =>
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return Results.BadRequest(new { Message = "Nome é obrigatório" });

            var person = service.Create(request.Name);
            return Results.Created($"/person/{person.Id}", person);
        })
        .WithName("CreatePerson")
        .Produces<Person.Models.PersonModel>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapPut("person/{id:guid}", (Guid id, [FromBody] UpdatePersonRequest request, PersonService service) =>
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return Results.BadRequest(new { Message = "Nome é obrigatório" });

            var updated = service.Update(id, request.Name);
            if (!updated)
                return Results.NotFound(new { Message = "Pessoa não encontrada" });

            return Results.NoContent();
        })
        .WithName("UpdatePerson")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound);

        app.MapDelete("person/{id:guid}", (Guid id, PersonService service) =>
        {
            var deleted = service.Delete(id);
            if (!deleted)
                return Results.NotFound(new { Message = "Pessoa não encontrada" });

            return Results.NoContent();
        })
        .WithName("DeletePerson")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}

using ApiContasAPagar;
using ApiCrud.Data;
using ApiCrud.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Controllers
{
    public static class ContasRotas
    {
        public static void AddRotasContas(this WebApplication app)
        {

            var rotasContas = app.MapGroup("contas");

            rotasContas.MapPost("", async (AddContasRequest request, AppDbContext context) =>
            {

                var existe = await context.ContasAPagar.AnyAsync(conta => conta.Nome == request.Nome)
                ; await context.ContasAPagar.AnyAsync(conta => conta.DataVencimento == request.dataVencimento);
                if (existe)
                    return Results.Conflict("Conta já está cadastrado");


                var novaConta = new ContasAPagar(request.Nome, request.Valor, request.Pago, request.dataVencimento);
                await context.ContasAPagar.AddAsync(novaConta);
                await context.SaveChangesAsync();

                return Results.Ok(novaConta);

            });


            //rotasContas.MapGet("", async (AddContasRequest request, AppDbContext context) =>
            //{

            //    var contas = await context.ContasAPagar.Where(conta => conta.Pago).ToListAsync();


            //    return contas;

            //}

            //);

        }
    }
}

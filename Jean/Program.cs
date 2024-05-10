using System.ComponentModel.DataAnnotations;
using Jean.Modelos;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();



Funcionario funcionario = new Funcionario();
FolhaPagamento folhaPagamento = new FolhaPagamento();

List<Funcionario> funcionarios = new List<Funcionario>();
List<FolhaPagamento> folhaPagamentos = new List<FolhaPagamento>();


//POST	http://localhost:5206/api/funcionario/cadastrar
app.MapPost("/api/funcionario/cadastrar/", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) => 
{   
    
    //Validação dos atributos do produto
    List<ValidationResult> erros = new List<ValidationResult>();
    if(!Validator.TryValidateObject(funcionario, new ValidationContext(funcionario), erros, true))
    {
        return Results.BadRequest(erros);
    }     
    //Regra de Negócio: Não permitir produtos com o mesmo nome
    Funcionario? funcionarioBuscado = ctx.Funcionarios.FirstOrDefault(x => x.Nome == funcionario.Nome);
  
  if(funcionarioBuscado is not null){
    return Results.BadRequest("Já existe um funcionario com o mesmo nome");
  }
  //Adicionar o produto dentro do banco de dados
  ctx.Funcionarios.Add(funcionario);
  ctx.SaveChanges();

  return Results.Created("", funcionario);
});

//GET	http://localhost:5206/api/funcionario/listar
app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) => 
{
    if(ctx.Funcionarios.Any())
    {
         return Results.Ok(ctx.Funcionarios.ToList());

    }
    return Results.NotFound("Tabela está vazia!");
}
);

//POST	http://localhost:5206/api/folha/cadastrar
app.MapPost("/api/folha/cadastrar/", ([FromBody] FolhaPagamento folhaPagamento, [FromServices] AppDataContext ctx) => 
{   
    
  //Adicionar o produto dentro do banco de dados
  ctx.FolhaPagamentos.Add(folhaPagamento);
  ctx.SaveChanges();

  return Results.Created("", folhaPagamento);
});

//GET	http://localhost:5206/api/folha/listar

app.MapGet("/api/folha/listar", ([FromServices] AppDataContext ctx) => 
{
    if(ctx.FolhaPagamentos.Any())
    {
         return Results.Ok(ctx.FolhaPagamentos.ToList());

    }
    return Results.NotFound("Tabela está vazia!");
}
);

//POST	http://localhost:5206/api/folha/buscar/{cpf}/{mes}/{ano}






app.Run();

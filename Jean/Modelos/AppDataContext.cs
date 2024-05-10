using Microsoft.EntityFrameworkCore;

namespace Jean.Modelos;

//CLASS QUE REPRESENTA O ENTITY FRAMEWORK DENTRO DO PROJETO
public class AppDataContext : DbContext
{
    //Classe que vão representar as tabelas no banco de dados
    public DbSet<Funcionario> Funcionarios{get; set;}

        //Configurando qual banco de dados vai ser utilizado
        //Configurando a string de conexão
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=matheus_jean.db");
    }

}   
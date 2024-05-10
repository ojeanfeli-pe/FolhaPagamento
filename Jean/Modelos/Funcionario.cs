namespace Jean.Modelos;

public class Funcionario{

        public Funcionario(){
          Id = Guid.NewGuid().ToString();
          CriadoEm = DateTime.Now;
        }
        public Funcionario(string nome, double cpf){
          Nome = nome;
          Cpf = cpf;
          Id = Guid.NewGuid().ToString();
          CriadoEm = DateTime.Now;
        }

        public string Id {get; set;}

        public string? Nome  { get;set; } 
        public double Cpf {get; set;}
        public DateTime CriadoEm {get; set;}
        
  
}

namespace Jean.Modelos;

public class FolhaPagamento{

        public FolhaPagamento(){
          Id = Guid.NewGuid().ToString();
          CriadoEm = DateTime.Now;
        }
        public FolhaPagamento( string nome, double valor, double trabalhadas, double mes, double ano){
          Nome = nome;
          ValorHoras = valor;
          QuantTrabalhadas = trabalhadas;
          Mes = mes;
          Ano = ano;
          Id = Guid.NewGuid().ToString();
          CriadoEm = DateTime.Now;
    
        }
         public string Nome {get; set;}        
         public double ValorHoras {get; set;}

         public double QuantTrabalhadas {get; set;}
         public double Mes {get; set;}

         public double Ano {get; set;}

        public string Id {get; set;}
         public DateTime CriadoEm {get; set;}

        
  
}
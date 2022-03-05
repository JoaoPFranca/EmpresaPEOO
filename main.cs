using System;

class Empresa {
  public static void Main() {
    Console.WriteLine("Aplicativo da Botafogo S.A versão BETA");
    int opcao = 0;
    
    do {
      opcao = Menu();
      switch(opcao) {
        case 1 : CriarSetor(); break;
        case 2 : ListarSetor(); break;
        case 3 : AtualizarSetor(); break;
      }
      
    }

    while (opcao != 0);

  }

  public static int Menu() {
    Console.WriteLine("----- O que desejas fazer? -----");
    Console.WriteLine("01 - Criar um novo Setor");
    Console.WriteLine("02 - Listar os Setores existentes");
    Console.WriteLine("03 - Atualizar um setor");
    Console.WriteLine("00 - Fechar o sistema");
    Console.WriteLine("---------------------------------");
    Console.Write("Opção:  ");
    int opcao = int.Parse(Console.ReadLine());
    Console.WriteLine("");
    return opcao;
    
  }
  
  public static void CriarSetor() {
    Console.WriteLine("----- Criar um novo setor -----");
    Console.Write("Informe o código do setor a ser atualizado: ");
    int codigodosetor = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome: ");
    string nome = Console.ReadLine();
    Setor obj =  new Setor(codigodosetor, nome);
    Sistema.CriarSetor(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  
  public static void ListarSetor() {
    Console.WriteLine("----- Listar os setores cadastrados -----");
    foreach(Setor obj in Sistema.ListarSetor()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }
  
  public static void AtualizarSetor() {
    Console.WriteLine("----- Atualizar um setor -----");
    Console.Write("Informe o código do setor a ser atualizado: ");
    int codigodosetor = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do setor a ser atualizado: ");
    string nome = Console.ReadLine();
    Setor obj =  new Setor(codigodosetor, nome);
    Sistema.AtualizarSetor(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
 
} 

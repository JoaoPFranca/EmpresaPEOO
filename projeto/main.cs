using System;

class Empresa {
  public static void Main() {
    Console.WriteLine("Aplicativo da Empresa S/A versão BETA");
    int opcao = 0;
    
    do {
      try{
        opcao = Menu();
        switch(opcao) {
          case 1 : CriarSetor(); break;
          case 2 : ListarSetor(); break;
          case 3 : AtualizarSetor(); break;
          case 4 : RemoverSetor(); break;
          case 5 : CriarColaborador(); break;
          case 6 : ListarColaborador(); break;
          case 7 : RemoverColaborador(); break;
        }
      }
      catch (Exception erro) {
        opcao = -1;
        Console.WriteLine("Erro: " + erro.Message);
      }
    } while (opcao != 0);
  }

  public static int Menu() {
    Console.WriteLine("----- O que desejas fazer? -----");
    Console.WriteLine("01 - Criar um novo setor");
    Console.WriteLine("02 - Listar os setores existentes");
    Console.WriteLine("03 - Atualizar um setor");
    Console.WriteLine("04 - Remover um setor");
    Console.WriteLine("05 - Criar um novo colaborador");
    Console.WriteLine("06 - Listar os colaboradores existentes");
    Console.WriteLine("07 - Remover um colaborador");
    Console.WriteLine("00 - Fechar o sistema");
    Console.WriteLine("---------------------------------");
    Console.Write("Opção:  ");
    int opcao = int.Parse(Console.ReadLine());
    Console.WriteLine("");
    return opcao;
    
  }
  
  public static void CriarSetor() {
    Console.WriteLine("----- Criar um novo setor -----");
    Console.Write("Informe o código do novo setor: ");
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
    Console.Write("Informe o novo nome do setor: ");
    string nome = Console.ReadLine();
    Setor obj =  new Setor(codigodosetor, nome);
    Sistema.AtualizarSetor(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  public static void RemoverSetor() {
    Console.WriteLine("----- Remover um setor -----");
    Console.Write("Informe o código do setor a ser removido: ");
    int codigodosetor = int.Parse(Console.ReadLine());
    string nome = "";
    Setor obj =  new Setor(codigodosetor, nome);
    Sistema.RemoverSetor(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

    public static void CriarColaborador() {
    Console.WriteLine("----- Criar um novo Colaborador -----");
    Console.Write("Informe o código do novo colaborador: ");
    int codigodocolaborador = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do novo colaborador: ");
    string nome = Console.ReadLine();
    Console.Write("Informe o CPF do novo colaborador: ");
    string cpf = Console.ReadLine();
    Console.Write("Informe o telefone do novo colaborador (APENAS NÚMEROS): ");
    int telefone = int.Parse(Console.ReadLine());
    ListarSetor();
    Console.Write("Informe o código do setor do novo colaborador: ");
    int setorquetrabalha = int.Parse(Console.ReadLine());
    Colaborador obj =  new Colaborador(codigodocolaborador, nome, cpf, telefone, setorquetrabalha);
    Sistema.CriarColaborador(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }
  
  public static void ListarColaborador() {
    Console.WriteLine("----- Listar os colaboradores cadastrados -----");
    foreach(Colaborador obj in Sistema.ListarColaborador()) 
      Console.WriteLine(obj);
    Console.WriteLine("------------------------------------------");
  }


  public static void RemoverColaborador() {
    Console.WriteLine("----- Remover um setor -----");
    Console.Write("Informe o código do colaborador a ser removido: ");
    int codigodocolaborador = int.Parse(Console.ReadLine());
    string nome = "";
    string cpf = "";
    int telefone = 0;
    int setorquetrabalha = 0;
    Colaborador obj =  new Colaborador(codigodocolaborador, nome, cpf, telefone, setorquetrabalha);
    Sistema.RemoverColaborador(obj);
    Console.WriteLine("----- Operação realizada com sucesso -----");
  }

  
} 
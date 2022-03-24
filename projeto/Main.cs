using System;
using System.Globalization;
using System.Threading;

class Empresa
{

    private static Consumidor consumidorLogin = null;
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

      try {
        Sistema.AbrirArquivo();
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
      }

      

        Console.WriteLine("Aplicativo da Empresa S/A versão BETA");
        int opcao = 0;
        int funcao = 0;
        do
        {
            try
            {
                if (funcao == 0)
                {
                    opcao = 0;
                    funcao = MenuDoConsumidor();

                }
                if (funcao == 1)
                {
                    opcao = MenuDoADM();
                    switch (opcao)
                    {
                        case 1: CriarSetor(); break;
                        case 2: ListarSetor(); break;
                        case 3: AtualizarSetor(); break;
                        case 4: RemoverSetor(); break;
                        case 5: CriarColaborador(); break;
                        case 6: ListarColaborador(); break;
                        case 7: AtualizarColaborador(); break;
                        case 8: RemoverColaborador(); break;
                        case 9: CriarConsumidor(); break;
                        case 10: ListarConsumidor(); break;
                        case 11: AtualizarConsumidor(); break;
                        case 12: RemoverConsumidor(); break;
                        case 13: CriarTarefa(); break;
                        case 14: ListarTarefa(); break;
                        case 15: AtualizarTarefa(); break;
                        case 16: RemoverTarefa(); break;
                        case 17: AgendamentoAbrirAgenda(); break;
                        case 18: AgendamentoSupervisionarAgenda(); break;
                        case 99: funcao = 0; break;
                    }
                }

                if (funcao == 2 && consumidorLogin == null)
                {
                    opcao = MenuLoginConsumidor();
                    switch (opcao)
                    {
                        case 1: ConsumidorLogin(); break;
                        case 2: funcao = 0; break;
                    }

                }

                if (funcao == 2 && consumidorLogin != null)
                {
                    opcao = MenuLogoutConsumidor();
                    switch (opcao)
                    {
                        case 1: ConsumidorChecarHorariosDisponiveis(); break;
                        case 2: ConsumidorAgendarReuniao(); break;
                        case 3: ConsumidorListarReunioesPassadas(); break;
                        case 4: ConsumidorListarQuemMeAtende(); break;
                        case 99: ConsumidorLogout(); break;
                    }
                }

            }
            catch (Exception erro)
            {
                opcao = -1;
                Console.WriteLine("Erro: " + erro.Message);
            }
        } while (opcao != 0);

      try {
        Sistema.SalvarArquivo();
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
      }
    }

    public static void ConsumidorLogin()
    {
        Console.WriteLine("----- Login do consumidor -----");
        ListarConsumidor();
        Console.Write("Informe o código do consumidor para logar: ");
        int Codigo = int.Parse(Console.ReadLine());
        consumidorLogin = Sistema.ListarConsumidor(Codigo);

    }

    public static void ConsumidorLogout()
    {
        Console.WriteLine("----- Logout do consumidor -----");
        consumidorLogin = null;

    }

    public static void ConsumidorAgendarReuniao()
    {
        Console.WriteLine("----- Horários disponíveis -----");
        foreach (Agendamento obj in Sistema.ListarAgendamento(DateTime.Today))
            Console.WriteLine(obj);
        Console.WriteLine("------------------------------------------");
        Console.Write("Informe o código do horário para reunião: ");
        int codigoAgendamento = int.Parse(Console.ReadLine());

        Console.WriteLine("----- Listar os colaboradores cadastrados -----");
        foreach (Colaborador obj in Sistema.ListarColaborador(consumidorLogin))
        {
            Setor s = Sistema.ListarSetor(obj.GetCodigoDoSetor());
            Consumidor c = Sistema.ListarConsumidor(obj.GetCodigoDoConsumidor());
            Console.WriteLine($"{obj} - Nome do setor: {s.GetNome()} - Nome do consumidor: {c.Nome}");
        }
        Console.WriteLine("Informe o código do colaborador: ");
        int codigodocolaborador = int.Parse(Console.ReadLine());

        Console.WriteLine("----- Listar as tarefas cadastradas -----");
        foreach (Tarefa obj in Sistema.ListarTarefa())
            Console.WriteLine(obj);
        Console.WriteLine("Informe o código da tarefa: ");
        int codigodatarefa = int.Parse(Console.ReadLine());
        Agendamento agendamento = new Agendamento()
        {
            Codigo = codigoAgendamento,
            CodigoDoConsumidor = consumidorLogin.Codigo,
            CodigoDoColaborador = codigodocolaborador,
            CodigoDaTarefa = codigodatarefa
        };
      
        Sistema.AtualizarAgendamento(agendamento);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void ConsumidorChecarHorariosDisponiveis()
    {
        Console.WriteLine("----- Horários disponíveis -----");
        foreach (Agendamento obj in Sistema.ListarAgendamento(DateTime.Today))
            Console.WriteLine(obj);
        Console.WriteLine("------------------------------------------");
    }

    public static void ConsumidorListarReunioesPassadas()
    {
        Console.WriteLine("----- Minhas reuniões -----");
        foreach (Agendamento obj in Sistema.ListarAgendamento(consumidorLogin))
            Console.WriteLine(obj);
        Console.WriteLine("------------------------------------------");
    }

    public static void ConsumidorListarQuemMeAtende()
    {
        Console.WriteLine("----- Meus colaboradores -----");
        foreach (Colaborador obj in Sistema.ListarColaborador())
        {
            Setor s = Sistema.ListarSetor(obj.GetCodigoDoSetor());
            Consumidor c = Sistema.ListarConsumidor(obj.GetCodigoDoConsumidor());
            Console.WriteLine($"{obj} - Nome do setor: {s.GetNome()} - Nome do consumidor: {c.Nome}");
        }
    }

    public static int MenuDoConsumidor()
    {
        Console.WriteLine();
        Console.WriteLine("---------------Quem é você?----------------");
        Console.WriteLine("01 - Entrar como administrador");
        Console.WriteLine("02 - Entrar como consumidor");
        Console.WriteLine("");
        Console.WriteLine("00 - Fechar a aplicação");
        Console.WriteLine("-------------------------------------------");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return opcao;
    }

    public static int MenuDoADM()
    {
        Console.WriteLine("----- O que desejas fazer? -----");
        Console.WriteLine("01 - Criar um novo setor");
        Console.WriteLine("02 - Listar os setores existentes");
        Console.WriteLine("03 - Atualizar um setor");
        Console.WriteLine("04 - Remover um setor");
        Console.WriteLine("05 - Criar um novo colaborador");
        Console.WriteLine("06 - Listar os colaboradores existentes");
        Console.WriteLine("07 - Atualizar um colaborador");
        Console.WriteLine("08 - Remover um colaborador");
        Console.WriteLine("09 - Criar um novo consumidor");
        Console.WriteLine("10 - Listar os consumidores existentes");
        Console.WriteLine("11 - Atualizar um consumidor");
        Console.WriteLine("12 - Remover um consumidor");
        Console.WriteLine("13 - Criar uma nova tarefa");
        Console.WriteLine("14 - Listar as tarefas existentes");
        Console.WriteLine("15 - Atualizar uma tarefa");
        Console.WriteLine("16 - Remover uma tarefa");
        Console.WriteLine("17 - Abrir agenda");
        Console.WriteLine("18 - Supervisionar agenda");
        Console.WriteLine("99 - Voltar ao menu principal");
        Console.WriteLine("00 - Fechar o sistema");
        Console.WriteLine("---------------------------------");
        Console.Write("Opção:  ");
        int opcao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return opcao;

    }

    public static int MenuLoginConsumidor()
    {
        Console.WriteLine();
        Console.WriteLine("-------------------------------");
        Console.WriteLine("01 - Login");
        Console.WriteLine("02 - Voltar");
        Console.WriteLine("");
        Console.WriteLine("00 - Fechar a aplicação");
        Console.WriteLine("-------------------------------");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return opcao;
    }

    public static int MenuLogoutConsumidor()
    {
        Console.WriteLine();
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Saudações, " + consumidorLogin.Nome);
        Console.WriteLine("-------------------------------");
        Console.WriteLine("01 - Checar horários disponíveis para reunião");
        Console.WriteLine("02 - Agendar uma reunião");
        Console.WriteLine("03 - Listar a data das reuniões comigo");
        Console.WriteLine("04 - Listar quem me atende");
        Console.WriteLine("99 - Logout");
        Console.WriteLine("");
        Console.WriteLine("00 - Fechar a aplicação");
        Console.WriteLine("-------------------------------");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        return opcao;
    }

    public static void CriarSetor()
    {
        Console.WriteLine("----- Criar um novo setor -----");
        Console.Write("Informe o código do novo setor: ");
        int codigodosetor = int.Parse(Console.ReadLine());
        Console.Write("Informe o nome: ");
        string nome = Console.ReadLine();
        Setor obj = new Setor(codigodosetor, nome);
        Sistema.CriarSetor(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void ListarSetor()
    {
        Console.WriteLine("----- Setores cadastrados -----");
        foreach (Setor obj in Sistema.ListarSetor())
            Console.WriteLine(obj);
        Console.WriteLine("------------------------------------------");
    }

    public static void AtualizarSetor()
    {
        Console.WriteLine("----- Atualizar um setor -----");
        Console.Write("Informe o código do setor a ser atualizado: ");
        int codigodosetor = int.Parse(Console.ReadLine());
        Console.Write("Informe o novo nome do setor: ");
        string nome = Console.ReadLine();
        Setor obj = new Setor(codigodosetor, nome);
        Sistema.AtualizarSetor(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void RemoverSetor()
    {
        Console.WriteLine("----- Remover um setor -----");
        Console.Write("Informe o código do setor a ser removido: ");
        int codigodosetor = int.Parse(Console.ReadLine());
        string nome = "";
        Setor obj = new Setor(codigodosetor, nome);
        Sistema.RemoverSetor(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void CriarColaborador()
    {
        Console.WriteLine("----- Criar um novo colaborador -----");
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
        int codigoSetor = int.Parse(Console.ReadLine());
        ListarConsumidor();
        Console.Write("Informe o código do consumidor: ");
        int codigoConsumidor = int.Parse(Console.ReadLine());
        Colaborador obj = new Colaborador(codigodocolaborador, nome, cpf, telefone, codigoSetor, codigoConsumidor);
        Sistema.CriarColaborador(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void ListarColaborador()
    {
        Console.WriteLine("----- Listar os colaboradores cadastrados -----");
        foreach (Colaborador obj in Sistema.ListarColaborador())
        {
            Setor s = Sistema.ListarSetor(obj.GetCodigoDoSetor());
            Consumidor c = Sistema.ListarConsumidor(obj.GetCodigoDoConsumidor());
            Console.WriteLine($"{obj} - Nome do setor: {s.GetNome()} - Nome do consumidor: {c.Nome}");
        }
        Console.WriteLine("------------------------------------------");
    }

    public static void AtualizarColaborador()
    {
        Console.WriteLine("----- Atualizar um colaborador -----");
        Console.Write("Informe o código do colaborador a ser atualizado: ");
        int codigodocolaborador = int.Parse(Console.ReadLine());
        Console.Write("Informe o nome do colaborador: ");
        string nome = Console.ReadLine();
        Console.Write("Informe o CPF do colaborador: ");
        string cpf = Console.ReadLine();
        Console.Write("Informe o telefone do colaborador (APENAS NÚMEROS): ");
        int telefone = int.Parse(Console.ReadLine());
        ListarSetor();
        Console.Write("Informe o código do setor do colaborador: ");
        int codigoSetor = int.Parse(Console.ReadLine());
        ListarConsumidor();
        Console.Write("Informe o código do consumidor: ");
        int codigoConsumidor = int.Parse(Console.ReadLine());
        Colaborador obj = new Colaborador(codigodocolaborador, nome, cpf, telefone, codigoSetor, codigoConsumidor);
        Sistema.AtualizarColaborador(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void RemoverColaborador()
    {
        Console.WriteLine("----- Remover um colaborador -----");
        Console.Write("Informe o código do colaborador a ser removido: ");
        int codigodocolaborador = int.Parse(Console.ReadLine());
        string nome = "";
        string cpf = "";
        int telefone = 0;
        int codigoSetor = 0;
        int codigoConsumidor = 0;
        Colaborador obj = new Colaborador(codigodocolaborador, nome, cpf, telefone, codigoSetor, codigoConsumidor);
        Sistema.RemoverColaborador(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void CriarConsumidor()
    {
        Console.WriteLine("----- Criar um novo consumidor -----");
        Console.Write("Informe o nome do novo consumidor: ");
        string nome = Console.ReadLine();
        Console.Write("Informe o telefone do novo consumidor (APENAS NÚMEROS): ");
        int telefone = int.Parse(Console.ReadLine());
        Consumidor obj = new Consumidor { Nome = nome, Telefone = telefone };
        Sistema.CriarConsumidor(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void ListarConsumidor()
    {
        Console.WriteLine("----- Listar os consumidores cadastrados -----");
        foreach (Consumidor obj in Sistema.ListarConsumidor())
            Console.WriteLine(obj);
        Console.WriteLine("------------------------------------------");
    }

    public static void AtualizarConsumidor()
    {
        Console.WriteLine("----- Atualizar um consumidor -----");
        Console.WriteLine("Informe o código do consumidor a ser atualizado: ");
        int codigo = int.Parse(Console.ReadLine());
        Console.Write("Informe o nome do consumidor: ");
        string nome = Console.ReadLine();
        Console.Write("Informe o telefone do consumidor (APENAS NÚMEROS): ");
        int telefone = int.Parse(Console.ReadLine());
        Consumidor obj = new Consumidor { Codigo = codigo, Nome = nome, Telefone = telefone };
        Sistema.AtualizarConsumidor(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void RemoverConsumidor()
    {
        Console.WriteLine("----- Remover um consumidor -----");
        Console.Write("Informe o código do consumidor a ser removido: ");
        int codigo = int.Parse(Console.ReadLine());
        Consumidor obj = new Consumidor { Codigo = codigo };
        Sistema.RemoverConsumidor(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void CriarTarefa()
    {
        Console.WriteLine("----- Criar uma nova tarefa -----");
        Console.Write("Informe a descrição da nova tarefa: ");
        string descricao = Console.ReadLine();
        Tarefa obj = new Tarefa { Descricao = descricao };
        Sistema.CriarTarefa(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void ListarTarefa()
    {
        Console.WriteLine("----- Listar as tarefas cadastradas -----");
        foreach (Tarefa obj in Sistema.ListarTarefa())
            Console.WriteLine(obj);
        Console.WriteLine("------------------------------------------");
    }

    public static void AtualizarTarefa()
    {
        Console.WriteLine("----- Atualizar uma tarefa -----");
        Console.WriteLine("Informe o código da tarefa a ser atualizada: ");
        int codigo = int.Parse(Console.ReadLine());
        Console.Write("Informe a descrição da tarefa: ");
        string descricao = Console.ReadLine();
        Tarefa obj = new Tarefa { Codigo = codigo, Descricao = descricao };
        Sistema.AtualizarTarefa(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void RemoverTarefa()
    {
        Console.WriteLine("----- Remover uma tarefa -----");
        Console.Write("Informe o código da tarefa a ser removida: ");
        int codigo = int.Parse(Console.ReadLine());
        Tarefa obj = new Tarefa { Codigo = codigo };
        Sistema.RemoverTarefa(obj);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void AgendamentoAbrirAgenda()
    {
        Console.WriteLine("----- Abrir agenda -----");
        DateTime data = DateTime.Today;
        Console.Write("Informe a data (CASO QUEIRA A DATA DE HOJE, APERTE ENTER): ");
        string s = Console.ReadLine();
        if (s != "") data = DateTime.Parse(s);
        Sistema.AgendamentoAbrirAgenda(data);
        Console.WriteLine("----- Operação realizada com sucesso -----");
    }

    public static void AgendamentoSupervisionarAgenda()
    {
        Console.WriteLine("----- Supervisionar agenda -----");
        foreach (Agendamento obj in Sistema.ListarAgendamento())
        {
            Consumidor cons = Sistema.ListarConsumidor(obj.CodigoDoConsumidor);
            Colaborador cola = Sistema.ListarColaborador(obj.CodigoDoColaborador);
            Tarefa tare = Sistema.ListarTarefa(obj.CodigoDaTarefa);
            if (cons != null)
                Console.WriteLine("Horários: " + obj + " - Nome do consumidor: " + cons.Nome + " - Nome do colaborador: " + cola.GetNome() + " - Descrição: " + tare.Descricao);
            else
                Console.WriteLine(obj);
        }
        Console.WriteLine("------------------------------------------");
    }
}

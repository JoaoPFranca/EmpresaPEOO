using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Sistema
{
    private static Setor[] setores = new Setor[10];
    private static int contagem;
    private static List<Colaborador> colaboradores = new List<Colaborador>();
    private static List<Consumidor> consumidores = new List<Consumidor>();
    private static List<Tarefa> tarefas = new List<Tarefa>();
    private static List<Agendamento> agendamentos = new List<Agendamento>();


    public static void AbrirArquivo() {
      Arquivo<Setor[]> f1 = new Arquivo<Setor[]>();
      setores = f1.Abrir("./setor.xml");
      contagem = setores.Length;

      Arquivo<List<Colaborador>> f2 = new Arquivo<List<Colaborador>>();
      colaboradores = f2.Abrir("./colaboradores.xml");

      Arquivo<List<Consumidor>> f3 = new Arquivo<List<Consumidor>>();
      consumidores = f3.Abrir("./consumidores.xml");

      Arquivo<List<Tarefa>> f4 = new Arquivo<List<Tarefa>>();
      tarefas = f4.Abrir("./tarefas.xml");

      Arquivo<List<Agendamento>> f5 = new Arquivo<List<Agendamento>>();
      agendamentos = f5.Abrir("./agendamentos.xml");


      /*
      XmlSerializer xml = new XmlSerializer(typeof(Setor[]));
      StreamReader f = new StreamReader("./setor.xml", Encoding.Default);
      setores = (Setor[]) xml.Deserialize(f);
      contagem = setores.Length;
      f.Close();
      */
    }

    public static void SalvarArquivo() {
      Arquivo<Setor[]> f1 = new Arquivo<Setor[]>();
      f1.Salvar("./setor.xml", ListarSetor());

      Arquivo<List<Colaborador>> f2 = new Arquivo<List<Colaborador>>();
      f2.Salvar("./colaboradores.xml", colaboradores);

      Arquivo<List<Consumidor>> f3 = new Arquivo<List<Consumidor>>();
      f3.Salvar("./consumidores.xml", consumidores);

      Arquivo<List<Tarefa>> f4 = new Arquivo<List<Tarefa>>();
      f4.Salvar("./tarefas.xml", tarefas);

      Arquivo<List<Agendamento>> f5 = new Arquivo<List<Agendamento>>();
      f5.Salvar("./agendamentos.xml", agendamentos);





      /*
      XmlSerializer xml = new XmlSerializer(typeof(Setor[]));
      StreamWriter f = new StreamWriter("./setor.xml", false, Encoding.Default);
      xml.Serialize(f, ListarSetor());
      f.Close();
      */
      
    }

    public static void CriarSetor(Setor obj)
    {
        if (contagem == setores.Length)
            Array.Resize(ref setores, 2 * setores.Length);
        setores[contagem] = obj;
        contagem++;
    }

    public static Setor[] ListarSetor()
    {
        Setor[] aux = new Setor[contagem];
        Array.Copy(setores, aux, contagem);
        return aux;
    }

    public static Setor ListarSetor(int codigodosetor)
    {
        foreach (Setor obj in setores)
            if (obj != null && obj.GetCodigoDoSetor() == codigodosetor) return obj;
        return null;
    }

    public static void AtualizarSetor(Setor obj)
    {
        Setor aux = ListarSetor(obj.GetCodigoDoSetor());
        if (aux != null)
            aux.SetNome(obj.GetNome());
    }

    public static void RemoverSetor(Setor obj)
    {
        int aux = IndiceSetor(obj.GetCodigoDoSetor());
        if (aux != -1)
        {
            for (int i = aux; i < contagem - 1; i++)
                setores[i] = setores[i + 1];
            contagem--;
        }
    }

    private static int IndiceSetor(int codigodosetor)
    {
        for (int i = 0; i < contagem; i++)
        {
            Setor obj = setores[i];
            if (obj.GetCodigoDoSetor() == codigodosetor) return i;
        }
        return -1;
    }

    public static void CriarColaborador(Colaborador obj)
    {
        colaboradores.Add(obj);
    }

    public static List<Colaborador> ListarColaborador()
    {
        return colaboradores;
    }

    public static List<Colaborador> ListarColaborador(Consumidor consumidor)
    {
        List<Colaborador> c = new List<Colaborador>();
        foreach (Colaborador obj in colaboradores)
            if (obj.GetCodigoDoConsumidor() == consumidor.Codigo)
                c.Add(obj);
        return c;
    }

    public static Colaborador ListarColaborador(int codigodocolaborador)
    {
        foreach (Colaborador obj in colaboradores)
            if (obj.GetCodigodocolaborador() == codigodocolaborador) return obj;
        return null;
    }

    public static void AtualizarColaborador(Colaborador obj)
    {
        Colaborador aux = ListarColaborador(obj.GetCodigodocolaborador());
        if (aux != null)
        {
            aux.SetNome(obj.GetNome());
            aux.SetCpf(obj.GetCpf());
            aux.SetTelefone(obj.GetTelefone());
            aux.SetCodigoDoSetor(obj.GetCodigoDoSetor());
        }
    }

    public static void RemoverColaborador(Colaborador obj)
    {
        Colaborador aux = ListarColaborador(obj.GetCodigodocolaborador());
        if (aux != null)
        {
            colaboradores.Remove(aux);
        }
    }

    public static void CriarConsumidor(Consumidor obj)
    {
        int codigodocolaborador = 0;
        foreach (Consumidor aux in consumidores)
            if (aux.Codigo > codigodocolaborador) codigodocolaborador = aux.Codigo;
        obj.Codigo = codigodocolaborador + 1;
        consumidores.Add(obj);
    }

    public static List<Consumidor> ListarConsumidor()
    {
        return consumidores;
    }

    public static Consumidor ListarConsumidor(int codigodocolaborador)
    {
        foreach (Consumidor obj in consumidores)
            if (obj.Codigo == codigodocolaborador) return obj;
        return null;
    }

    public static void AtualizarConsumidor(Consumidor obj)
    {
        Consumidor aux = ListarConsumidor(obj.Codigo);
        if (aux != null)
        {
            aux.Nome = obj.Nome;
            aux.Telefone = obj.Telefone;
        }
    }

    public static void RemoverConsumidor(Consumidor obj)
    {
        Consumidor aux = ListarConsumidor(obj.Codigo);
        if (aux != null)
        {
            consumidores.Remove(aux);
        }
    }

    public static void CriarTarefa(Tarefa obj)
    {
        int codigodocolaborador = 0;
        foreach (Tarefa aux in tarefas)
            if (aux.Codigo > codigodocolaborador) codigodocolaborador = aux.Codigo;
        obj.Codigo = codigodocolaborador + 1;
        tarefas.Add(obj);
    }

    public static List<Tarefa> ListarTarefa()
    {
        return tarefas;
    }

    public static Tarefa ListarTarefa(int codigodocolaborador)
    {
        foreach (Tarefa obj in tarefas)
            if (obj.Codigo == codigodocolaborador) return obj;
        return null;
    }

    public static void AtualizarTarefa(Tarefa obj)
    {
        Tarefa aux = ListarTarefa(obj.Codigo);
        if (aux != null)
        {
            aux.Descricao = obj.Descricao;
        }
    }

    public static void RemoverTarefa(Tarefa obj)
    {
        Tarefa aux = ListarTarefa(obj.Codigo);
        if (aux != null)
        {
            tarefas.Remove(aux);
        }
    }

    public static void AgendamentoAbrirAgenda(DateTime data)
    {
        int[] horas = { 8, 9, 10, 11, 14, 15, 16, 17 };
        DateTime hoje = data.Date;
        foreach (int h in horas)
        {
            TimeSpan horario = new TimeSpan(0, h, 0, 0);
            Agendamento obj = new Agendamento { DataHora = hoje + horario };
            CriarAgendamento(obj);
        }
    }

    public static void CriarAgendamento(Agendamento obj)
    {
        int codigodocolaborador = 0;
        foreach (Agendamento aux in agendamentos)
            if (aux.Codigo > codigodocolaborador) codigodocolaborador = aux.Codigo;
        obj.Codigo = codigodocolaborador + 1;
        agendamentos.Add(obj);
    }

    public static List<Agendamento> ListarAgendamento()
    {
        return agendamentos;
    }

    public static List<Agendamento> ListarAgendamento(Consumidor consumidor)
    {
        List<Agendamento> a = new List<Agendamento>();
        foreach(Agendamento obj in agendamentos)
            if (obj.CodigoDoConsumidor == consumidor.Codigo)
                a.Add(obj);
        return a;
    }

    public static List<Agendamento> ListarAgendamento(DateTime data)
    {
        List<Agendamento> a = new List<Agendamento>();
        foreach (Agendamento obj in agendamentos)
            if (obj.CodigoDoConsumidor == 0 && obj.DataHora.Date == data.Date)
                a.Add(obj);
        return a;
    }

    public static Agendamento ListarAgendamento(int codigodocolaborador)
    {
        foreach (Agendamento obj in agendamentos)
            if (obj.Codigo == codigodocolaborador) return obj;
        return null;
    }

    public static void AtualizarAgendamento(Agendamento obj)
    {
        Agendamento aux = ListarAgendamento(obj.Codigo);
        if (aux != null)
        {
            //aux.DataHora = obj.DataHora;
            aux.CodigoDoConsumidor = obj.CodigoDoConsumidor;
            aux.CodigoDoColaborador = obj.CodigoDoColaborador;
            aux.CodigoDaTarefa = obj.CodigoDaTarefa;
        }
      
    }

    public static void RemoverAgendamento(Agendamento obj)
    {
        Agendamento aux = ListarAgendamento(obj.Codigo);
        if (aux != null)
        {
            agendamentos.Remove(aux);
        }
    }

}
using System;

public class Colaborador
{
    private int codigodocolaborador;
    private string nome;
    private string cpf;
    private int telefone;
    private int codigoSetor;
    private int codigoConsumidor;

    public int Codigodocolaborador {
      get => codigodocolaborador;
      set => codigodocolaborador = value;
    }

    public string Nome {
      get => nome;
      set => nome = value;
    }

    public string Cpf {
      get => cpf;
      set => cpf = value;
    }

    public int Telefone {
      get => telefone;
      set => telefone = value;
    }

    public int Codigosetor {
      get => codigoSetor;
      set => codigoSetor = value;
    }
  
    public int Codigoconsumidor {
      get => codigoConsumidor;
      set => codigoConsumidor = value;
    }
    
    
    public Colaborador() { }
    public Colaborador(int codigodocolaborador, string nome, string cpf, int telefone, int codigoSetor, int codigoConsumidor)
    {
        this.codigodocolaborador = codigodocolaborador;
        this.nome = nome;
        this.cpf = cpf;
        this.telefone = telefone;
        this.codigoSetor = codigoSetor;
        this.codigoConsumidor = codigoConsumidor;
    }

    public void SetCodigodocolaborador(int codigodocolaborador)
    {
        this.codigodocolaborador = codigodocolaborador;
    }

    public int GetCodigodocolaborador()
    {
        return codigodocolaborador;
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public string GetNome()
    {
        return nome;
    }

    public void SetCpf(string cpf)
    {
        this.cpf = cpf;
    }

    public string GetCpf()
    {
        return cpf;
    }

    public void SetTelefone(int telefone)
    {
        this.telefone = telefone;
    }

    public int GetTelefone()
    {
        return telefone;
    }

    public void SetCodigoDoSetor(int codigoSetor)
    {
        this.codigoSetor = codigoSetor;
    }

    public int GetCodigoDoSetor()
    {
        return codigoSetor;
    }

    public void SetCodigoDoConsumidor(int codigoConsumidor)
    {
        this.codigoConsumidor = codigoConsumidor;
    }

    public int GetCodigoDoConsumidor()
    {
        return codigoConsumidor;
    }

    public override string ToString()
    {
        return $"Código do colaborador: {codigodocolaborador} - Nome do colaborador: {nome} - CPF do colaborador: {cpf} - Telefone do colaborador: {telefone} - Código do setor: {codigoSetor}";
    }
  
}
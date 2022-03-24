using System;

public class Setor
{
    private int codigodosetor;
    private string nome;

    public int Codigodosetor {
      get => codigodosetor;
      set => codigodosetor = value;
    }

    public string Nome {
      get => nome;
      set => nome = value;
    }

    public Setor() {}
    public Setor(int codigodosetor, string nome)
    {
        this.nome = nome;
        this.codigodosetor = codigodosetor;
    }

    public void SetCodigoDoSetor(int codigodosetor)
    {
        this.codigodosetor = codigodosetor;
    }

    public int GetCodigoDoSetor()
    {
        return codigodosetor;
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public string GetNome()
    {
        return nome;
    }

    public override string ToString()
    {
        return $"Código do setor: {codigodosetor} - Nome do setor: {nome}";
    }
}
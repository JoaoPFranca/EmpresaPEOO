using System;

public class Setor : IComparable <Setor>
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

    public int CompareTo (Setor s) {
      return nome.CompareTo(s.GetNome());
    }
  
    public override string ToString()
    {
        return $"{codigodosetor} - {nome}";
    }
}

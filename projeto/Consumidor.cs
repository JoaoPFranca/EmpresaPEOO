using System;

public class Consumidor : IComparable <Consumidor>
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public int Telefone { get; set; }

    public string GetNome() {
      return Nome;
    }

    public int CompareTo (Consumidor cons) {
      return this.Nome.CompareTo(cons.GetNome());
    }
  
    public override string ToString()
    {
        return $"{Codigo} - {Nome} - {Telefone}";
    }
  
}

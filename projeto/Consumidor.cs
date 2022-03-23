using System;

class Consumidor
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public int Telefone { get; set; }
    public override string ToString()
    {
        return $"Código do consumidor: {Codigo} - Nome do consumidor: {Nome} - Telefone do consumidor: {Telefone}";
    }
}

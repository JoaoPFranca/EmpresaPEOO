using System;

class Tarefa
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public override string ToString()
    {
        return $"{Codigo} - {Descricao}";
    }
}

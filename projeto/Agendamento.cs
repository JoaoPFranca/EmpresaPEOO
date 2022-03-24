using System;

public class Agendamento
{
    public int Codigo { get; set; }
    public DateTime DataHora { get; set; }
    public int CodigoDoConsumidor { get; set; }
    public int CodigoDoColaborador { get; set; }
    public int CodigoDaTarefa { get; set; }
    public int Telefone { get; set; }
    public override string ToString()
    {
        string s = $"{Codigo} - {DataHora:dd/MM/yyyy:mm}";
        if (CodigoDoConsumidor == 0) s += " - Vago";
        return s;
    }
}

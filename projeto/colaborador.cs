using System;

class Colaborador {
  private int codigodocolaborador;
  private string nome;
  private string cpf;
  private int telefone;
  private int setorquetrabalha;

  public Colaborador(int codigodocolaborador, string nome, string cpf, int telefone, int setorquetrabalha) {
    this.codigodocolaborador = codigodocolaborador;
    this.nome = nome;
    this.cpf = cpf;
    this.telefone = telefone;
    this.setorquetrabalha = setorquetrabalha;
  }

  public void SetCodigodocolaborador(int codigodocolaborador) {
    this.codigodocolaborador = codigodocolaborador;
  }

  public int GetCodigodocolaborador() {
    return codigodocolaborador;
  }

  public void SetNome(string nome) {
    this.nome = nome;
  }

  public string GetNome() {
    return nome;
  }

  public void SetCpf(string cpf) {
    this.cpf = cpf;
  }

  public string GetCpf() {
    return cpf;
  }

  public void SetTelefone(int telefone) {
    this.telefone = telefone;
  }

  public int GetTelefone() {
    return telefone;
  }

  public void SetSetorquetrabalha(int setorquetrabalha) {
    this.setorquetrabalha = setorquetrabalha;
  }

  public int GetSetorquetrabalha() {
    return setorquetrabalha;
  }

  public override string ToString() {
    return $"{codigodocolaborador} - {nome} - {cpf} - {telefone} - {setorquetrabalha}";
  }
  
}

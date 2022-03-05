using System;

class Colaborador {
  private string nome;
  private string cpf;
  private int telefone;
  private string setorquetrabalha;

  public Colaborador(string nome, string cpf, int telefone, string setorquetrabalha) {
    this.nome = nome;
    this.cpf = cpf;
    this.telefone = telefone;
    this.setorquetrabalha = setorquetrabalha;
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

  public void SetSetorquetrabalha(string setorquetrabalha) {
    this.setorquetrabalha = setorquetrabalha;
  }

  public string GetSetorquetrabalha() {
    return setorquetrabalha;
  }

  public override string ToString() {
    return $"{nome} - {cpf} - {telefone} - {setorquetrabalha}";
  }
  
}

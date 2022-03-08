using System;

class Setor {
  public int codigodosetor;
  public string nome;
  
  public Setor(int codigodosetor, string nome) {
    this.nome = nome;
    this.codigodosetor = codigodosetor;
  }
  
  public void SetCodigoDoSetor(int codigodosetor) {
    this.codigodosetor = codigodosetor;
  }

  public int GetCodigoDoSetor() {
    return codigodosetor;
  }
  
  public void SetNome(string nome) {
    this.nome = nome;
  }

  public string GetNome() {
    return nome;
  }

  public override string ToString() {
    return $"{codigodosetor} - {nome}";
  }
  
} 

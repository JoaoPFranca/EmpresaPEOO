using System;

class Sistema {
  private static Setor[] setores = new Setor[10];
  private static int contagem;
  
  public static void  CriarSetor(Setor obj) {
    if (contagem == setores.Length)
      Array.Resize(ref setores, 2 * setores.Length);
      setores[contagem] = obj;
    contagem++;
  }

  public static Setor[] ListarSetor() {
    Setor[] aux = new Setor[contagem];
    Array.Copy(setores, aux, contagem);
    return aux;
  }
  
  public static Setor ListarSetor(string nome) {
    foreach(Setor obj in setores)
      if (obj != null && obj.GetNome() == nome) return obj;
    return null;
  }
  
  public static void AtualizarSetor(Setor obj) {
    Setor aux = ListarSetor(obj.GetNome());
    if (aux != null)
      aux.nome=obj.nome;
  }
  
}

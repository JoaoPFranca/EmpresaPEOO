using System;
using System.Collections.Generic;

class Sistema {
  private static Setor[] setores = new Setor[10];
  private static int contagem;
  
  private static List<Colaborador> colaboradores = new List<Colaborador>();

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
  
  public static Setor ListarSetor(int codigodosetor) {
    foreach(Setor obj in setores)
      if (obj != null && obj.GetCodigoDoSetor() == codigodosetor) return obj;
    return null;
  }
  
  public static void AtualizarSetor(Setor obj) {
    Setor aux = ListarSetor(obj.GetCodigoDoSetor());
    if (aux != null)
      aux.SetNome(obj.GetNome());
  }

  public static void RemoverSetor(Setor obj) {
    int aux = IndiceSetor(obj.GetCodigoDoSetor());
    if (aux != -1){
      for (int i = aux; i < contagem -1; i++)
        setores[i] = setores[i + 1];
      contagem--;
    }
  }
  
  private static int IndiceSetor(int codigodosetor) {
    for (int i = 0; i < contagem; i++) {
      Setor obj = setores[i];
      if (obj.GetCodigoDoSetor() == codigodosetor) return i;
    }
  return -1;
  }


// ----------------------------- //

  public static void  CriarColaborador(Colaborador obj) {
    colaboradores.Add(obj);
  }

  public static List<Colaborador> ListarColaborador() {
    return colaboradores;
  }
  
  public static Colaborador ListarColaborador(int codigodocolaborador) {
    foreach(Colaborador obj in colaboradores)
      if (obj.GetCodigodocolaborador() == codigodocolaborador) return obj;
    return null;
  }
  
  public static void AtualizarColaborador(Colaborador obj) {
    Colaborador aux = ListarColaborador(obj.GetCodigodocolaborador());
    if (aux != null) {
      aux.SetNome(obj.GetNome());
      aux.SetCodigodocolaborador(obj.GetCodigodocolaborador());
      aux.SetCpf(obj.GetCpf());
      aux.SetTelefone(obj.GetTelefone());
      aux.SetSetorquetrabalha(obj.GetSetorquetrabalha());
    }
  }
    

  public static void RemoverColaborador(Colaborador obj) {
    Colaborador aux = ListarColaborador(obj.GetCodigodocolaborador());
    if (aux != null) {
      colaboradores.Remove(aux);

    }
  
  }

}
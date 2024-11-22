namespace ControleFinaceiroAPI.Models;
using System.Collections.Generic;

public class Mes
{
    public int Id { get; set; }
    public string Nome { get; set; } 
    public ICollection<Gasto> Gastos { get; set; }
}
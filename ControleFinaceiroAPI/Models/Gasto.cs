namespace ControleFinaceiroAPI.Models;

public class Gasto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public int MesId { get; set; }
    public Mes Mes { get; set; }
}
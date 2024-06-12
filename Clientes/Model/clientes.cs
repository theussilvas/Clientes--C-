class Clientes
{
    public List<Clientes> Cliente {get; set;}
    public int id {get; set;}
    public string nome {get; set;}
    public int idade {get; set;}
    public string email {get; set;}

    public override string ToString() 
    {
        return $"Id:{id} - Nome:{nome} - Idade:{idade} - Email:{email}";
    }
}
class NClientes
{
    public static List <Clientes> clientes = new List<Clientes>();

    public static List <Clientes> Listar()
    {
        return clientes;
    }

    public static Clientes Listar(int id)
    {
        foreach(Clientes obj in clientes)
        {
            if (obj.id == id)
            {
              return obj;  
            } 
        }

        return null;
    }

    public static void Adicionar(Clientes c)
    {
        int id = 0;

        foreach(Clientes obj in clientes)
        {
            if(obj.id > id)
            {
                id = obj.id;
            }
        }
        id++;
        c.id = id;
        clientes.Add(c);
    }

    public static void Atualizar(Clientes c)
    {
        Clientes obj = Listar(c.id);
        if (obj != null)
        {
            obj.email = c.email;
        }
    }

    public static void Excluir(Clientes c)
    {
        Clientes obj = Listar(c.id);
        if (obj != null)
        {
            clientes.Remove(obj);
        }
    }
}
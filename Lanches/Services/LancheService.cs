using Lanche.Models;

namespace Lanche.Services;

    public static class LancheService
    {
    //Atributos privados
    static List<Lanches> lanches { get; set; }
    static int nextId = 4;

    //Construtor
    static LancheService()
    {
        lanches = new List<Lanches> { 
            new Lanches{
                id = 1,
                nome = "X-bacon",
                preco = 10.00,
                vegetariano = false,
                tipoCarne = "Bovina"
            },
            new Lanches{
                id = 2,
                nome = "Pastel de Soja",
                preco = 6.50,
                vegetariano = true,
                tipoCarne = "Soja"
            },
            new Lanches{
                id = 3,
                nome = "Cachorro-quente completo",
                preco = 5.00,
                vegetariano = false,
                tipoCarne = "Carne moída"
            }
        };
    }

    //Métodos públicos
    //Listar todos os lanches
    public static List<Lanches> GetAll() => lanches;

    //Listar lanche por ID
    public static Lanches? Get(int id)
    {
        return lanches.FirstOrDefault(p => p.id == id);
    }

    //Adicionar lanche
    public static void Add(Lanches lanche)
    {
        lanche.id = nextId++;
        lanches.Add(lanche);
    }

    //Deletar lanche
    public static void Delete(int id)
    {
        var lanche = Get(id);
        if (lanche is null)
            return;
        lanches.Remove(lanche);
    }

    //Atualizar lanche
    public static void Update(Lanches lanche)
    {
        var index = lanches.FindIndex(p => p.id == lanche.id);
        if (index == -1)
            return;
        lanches[index] = lanche;
    }
}
namespace Aula01;
using System.IO;

public class Program
{
     
     public static void Main()
    {
        string path = @"/home/erickcastro/Documentos/programação/dotnet studos/ListaDeCompras/";
        string fileName = "lista_de_compras.txt";
        string filePath = path + fileName;

        List<string> shopingList = new List<string>();

        if (File.Exists(filePath))
        {
            shopingList.AddRange(File.ReadAllLines(filePath));
        }

        while (true)
        {
            Console.WriteLine("\n=== Lista de Compras ===");
            Console.WriteLine("1. Adicionar item");
            Console.WriteLine("2. Remover item");
            Console.WriteLine("3. Exibir lista");
            Console.WriteLine("4. Sair");
            Console.WriteLine("Escolha um item para continuar");

            string choiceUser = Console.ReadLine();

            switch(choiceUser)
            {
                case "1":
                    Console.WriteLine("Digite o nome do item para adicionar: ");
                    string itemInsert = Console.ReadLine();
                    if (!string.IsNullOrEmpty(itemInsert))
                    {
                        shopingList.Add(itemInsert);
                        Console.WriteLine($"Item '{itemInsert}' adicionado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("O item não pode ser vazio!");
                    }

                break;
                
                case "2":
                    Console.WriteLine("Digite o nome do item para remover: ");
                    string itemToRemove = Console.ReadLine();
                    if (shopingList.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Item '{itemToRemove}' removido com sucesso");
                    }
                    else
                    {
                        Console.WriteLine($"Item '{itemToRemove}' não encontrado!");
                    }

                break;

                case "3":
                    Console.WriteLine("\n Itens na sua Lista de Compras:");

                    if (shopingList.Count == 0)
                    {
                        Console.WriteLine("Sua lista está vazia");
                    }
                    else
                    {
                        for (int i = 0; i < shopingList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {shopingList[i]}");
                        }
                    }
                break;

                case "4":
                    File.WriteAllLines(filePath, shopingList);
                    Console.WriteLine("Lista salva com sucesso! Saindo...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente");
                break;
            }
        }
    }
}
  
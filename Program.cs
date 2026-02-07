using System;
using System.Collections.Generic;
using atividadde.Models;
using atividadde.Services;

namespace atividadde
{
    class Program
    {
        static List<Cliente> clientes = new();
        static List<Tecnico> tecnicos = new();
        static List<Categoria> categorias = new()
        {
            new Categoria(1, "Suporte Técnico"),
            new Categoria(2, "Manutenção de Software"),
            new Categoria(3, "Redes")
        };

        static ChamadoService chamadoService = new();

        static void Main()
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n===== Sistema de Chamados =====");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Cadastrar Técnico");
                Console.WriteLine("3 - Abrir Chamado");
                Console.WriteLine("4 - Atribuir Técnico");
                Console.WriteLine("5 - Encerrar Chamado");
                Console.WriteLine("6 - Listar Chamados por Status");
                Console.WriteLine("7 - Listar Chamados por Técnico");
                Console.WriteLine("8 - Sair");
                Console.Write("Escolha uma opção: ");
                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "1": CadastrarCliente(); break;
                    case "2": CadastrarTecnico(); break;
                    case "3": AbrirChamado(); break;
                    case "4": AtribuirTecnico(); break;
                    case "5": EncerrarChamado(); break;
                    case "6": ListarPorStatus(); break;
                    case "7": ListarPorTecnico(); break;
                    case "8": sair = true; break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
        }

        // ========================= Funções =========================

        static void CadastrarCliente()
        {
            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine()!;
            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            int id = clientes.Count + 1;
            clientes.Add(new Cliente(id, nome, email));
            Console.WriteLine($"Cliente '{nome}' cadastrado com sucesso!");
        }

        static void CadastrarTecnico()
        {
            Console.Write("Nome do técnico: ");
            string nome = Console.ReadLine()!;
            Console.Write("Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Especialidade: ");
            string esp = Console.ReadLine()!;

            int id = tecnicos.Count + 1;
            tecnicos.Add(new Tecnico(id, nome, email, esp));
            Console.WriteLine($"Técnico '{nome}' cadastrado com sucesso!");
        }

        static void AbrirChamado()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um cliente primeiro.");
                return;
            }

            Console.WriteLine("Selecione o cliente:");
            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.Id} - {c.Nome}");
            }
            int clienteId = int.Parse(Console.ReadLine()!);
            Cliente cliente = clientes.Find(c => c.Id == clienteId)!;

            Console.WriteLine("Selecione a categoria:");
            foreach (var cat in categorias)
            {
                Console.WriteLine($"{cat.Id} - {cat.Nome}");
            }
            int catId = int.Parse(Console.ReadLine()!);
            Categoria categoria = categorias.Find(c => c.Id == catId)!;

            int chamadoId = chamadoService.ListarPorStatus("Aberto").Count + chamadoService.ListarPorStatus("Encerrado").Count + 1;
            Chamado chamado = new Chamado(chamadoId, cliente, categoria);
            chamadoService.AbrirChamado(chamado);

            Console.WriteLine($"Chamado {chamado.Id} aberto com sucesso!");
        }

        static void AtribuirTecnico()
        {
            if (tecnicos.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um técnico primeiro.");
                return;
            }

            Console.WriteLine("Chamados abertos:");
            var abertos = chamadoService.ListarPorStatus("Aberto");
            if (abertos.Count == 0)
            {
                Console.WriteLine("Nenhum chamado aberto.");
                return;
            }
            foreach (var c in abertos)
            {
                Console.WriteLine($"{c.Id} - Cliente: {c.Cliente.Nome}, Categoria: {c.Categoria.Nome}");
            }

            Console.Write("Escolha o ID do chamado: ");
            int chamId = int.Parse(Console.ReadLine()!);
            Chamado chamado = abertos.Find(c => c.Id == chamId)!;

            Console.WriteLine("Selecione o técnico:");
            foreach (var t in tecnicos)
            {
                Console.WriteLine($"{t.Id} - {t.Nome}");
            }
            int tecId = int.Parse(Console.ReadLine()!);
            Tecnico tecnico = tecnicos.Find(t => t.Id == tecId)!;

            chamado.AtribuirTecnico(tecnico);
            chamado.Historico.Add(new HistoricoChamado($"Técnico {tecnico.Nome} atribuído."));
            Console.WriteLine("Técnico atribuído com sucesso!");
        }

        static void EncerrarChamado()
        {
            var emAndamento = chamadoService.ListarPorStatus("Em andamento");
            if (emAndamento.Count == 0)
            {
                Console.WriteLine("Nenhum chamado em andamento.");
                return;
            }

            Console.WriteLine("Chamados em andamento:");
            foreach (var c in emAndamento)
            {
                Console.WriteLine($"{c.Id} - Cliente: {c.Cliente.Nome}, Técnico: {c.Tecnico?.Nome}");
            }

            Console.Write("Escolha o ID do chamado: ");
            int chamId = int.Parse(Console.ReadLine()!);
            Chamado chamado = emAndamento.Find(c => c.Id == chamId)!;

            chamado.Encerrar();
            chamado.Historico.Add(new HistoricoChamado("Chamado encerrado."));
            Console.WriteLine("Chamado encerrado com sucesso!");
        }

        static void ListarPorStatus()
        {
            Console.Write("Digite o status (Aberto, Em andamento, Encerrado): ");
            string status = Console.ReadLine()!;
            var lista = chamadoService.ListarPorStatus(status);

            if (lista.Count == 0)
            {
                Console.WriteLine($"Nenhum chamado com status '{status}'.");
                return;
            }

            foreach (var c in lista)
            {
                Console.WriteLine($"ID: {c.Id}, Cliente: {c.Cliente.Nome}, Técnico: {c.Tecnico?.Nome ?? "Não atribuído"}, Categoria: {c.Categoria.Nome}");
            }
        }

        static void ListarPorTecnico()
        {
            if (tecnicos.Count == 0)
            {
                Console.WriteLine("Nenhum técnico cadastrado.");
                return;
            }

            Console.WriteLine("Selecione o técnico:");
            foreach (var t in tecnicos)
            {
                Console.WriteLine($"{t.Id} - {t.Nome}");
            }

            int tecId = int.Parse(Console.ReadLine()!);
            Tecnico tecnico = tecnicos.Find(t => t.Id == tecId)!;

            var lista = chamadoService.ListarPorTecnico(tecnico);
            if (lista.Count == 0)
            {
                Console.WriteLine($"Nenhum chamado atribuído ao técnico {tecnico.Nome}.");
                return;
            }

            foreach (var c in lista)
            {
                Console.WriteLine($"ID: {c.Id}, Cliente: {c.Cliente.Nome}, Status: {c.Status}, Categoria: {c.Categoria.Nome}");
            }
        }
    }
}

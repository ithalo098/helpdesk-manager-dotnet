# Helpdesk Manager .NET

Sistema de chamados de suporte técnico em C# com clientes, técnicos, categorias e histórico.

## Estrutura

- [`Interfaces/`](./Interfaces/)
- [`Models/`](./Models/)
- [`Services/`](./Services/)
- [`Program.cs`](./Program.cs)

## Visão geral

O código e os materiais deste repositório estão organizados para consulta e evolução do projeto. As funcionalidades descritas refletem os arquivos presentes, sem pressupor uma publicação em produção.

## Tecnologias

- C#
- .NET

## Executar localmente

Requer o SDK .NET 10.

```sh
dotnet run --project atividadde.csproj
```

## Documentação do projeto

# Sistema de Chamados de Suporte Técnico

Sistema simples de gerenciamento de chamados desenvolvido em C# com Programação Orientada a Objetos.

**Alunos:**  
Ithalo Augusto  
Henrique Matos

## Diagrama

https://i.postimg.cc/rwDWtdFq/Whats-App-Image-2026-02-07-at-20-44-26.jpg

## Funcionalidades

- Cadastro de clientes e técnicos
- Abertura de chamados com categoria
- Atribuição de técnico ao chamado
- Atualização de status (ABERTO → EM_ANDAMENTO → ENCERRADO)
- Encerramento com motivo
- Registro de histórico de atendimentos
- Listagem de chamados (todos, por status ou por técnico)

## Conceitos de POO Utilizados

- Classe e Objeto
- Encapsulamento
- Herança (Usuario → Cliente / Tecnico)
- Polimorfismo (sobrescrita de ToString)
- Abstração (classe abstrata Usuario)
- Interfaces (IAtribuivel e IEncerravel)
- Classes abstratas
- Construtores parametrizados

## Princípios SOLID Aplicados

- **S**ingle Responsibility  
  Chamado → apenas dados e estado  
  ChamadoService → regras de negócio e operações

- **O**pen/Closed  
  Novos usuários ou categorias podem ser adicionados sem alterar código existente

- **L**iskov Substitution  
  Cliente e Técnico substituem Usuario sem quebrar o sistema

- **I**nterface Segregation  
  Interfaces pequenas: IAtribuivel (para técnicos) e IEncerravel (para chamados)

- **D**ependency Inversion  
  Serviço gerencia entidades via listas (pode evoluir para interface de repositório)

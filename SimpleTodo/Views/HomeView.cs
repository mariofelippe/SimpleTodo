using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo.Views
{
    public static class HomeView
    {
        private const string TITLE = "Simple ToDo!";


        public static string Header()
        {
            Console.Clear();
            StringBuilder header = new StringBuilder();
            header.AppendLine("######################################################");
            header.AppendLine($"                     {TITLE}                       ");
            header.AppendLine("######################################################");

            return header.ToString();
        }

        public static string Home()
        {
            
            StringBuilder home = new StringBuilder();
            home.AppendLine(Header());
            home.AppendLine();
            home.AppendLine("1 - Tarefas Pendentes.");
            home.AppendLine("2 - Criar Tarefa.");
            home.AppendLine("3 - Atualizar Tarefa.");
            home.AppendLine("4 - Concluir Tarefa.");
            home.AppendLine("5 - Excluir Tarefa.");
            home.AppendLine("6 - Tarefas Concluídas.");
            home.AppendLine("0 - Sair.");
            home.AppendLine();
            home.Append("Opção: ");
            return home.ToString();
            
        }


        public static void ListTodos(List<Todo> todos)
        {
            
            Console.WriteLine(Header());
            Console.WriteLine("Pendentes:\n");
            
            foreach (Todo todosItem in todos)
            {
                Console.WriteLine();
                Console.WriteLine(todosItem);
            }
            Console.WriteLine();
          
            
        }

    }
}

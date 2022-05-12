using System;
using SimpleTodo.Data;
using SimpleTodo.Models;
using SimpleTodo.Views;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

Context db = new Context();

while (true)
{
    Console.Write(HomeView.Home());
    string op = Console.ReadLine();

    if (op == "0")
        break;

    if(op == "1")
    {
        var todos = await db.Todos.Where(todo => todo.IsDone == false).AsNoTracking().ToListAsync();

        HomeView.ListTodos(todos);
        Console.Write("Aperte para continuar...");
        Console.ReadKey();
    }

    if(op == "2")
    {
        Console.WriteLine(HomeView.Header());
        
        Console.Write("Título: ");
        string title = Console.ReadLine();
        Console.Write("Descrição: ");
        string description = Console.ReadLine();
        Todo todo = new Todo(title, description);
        try
        {
           await db.Todos.AddAsync(todo);
            db.SaveChangesAsync();
        }catch (Exception ex)
        {
            Console.WriteLine($"Erro ao adicionar a tarefa! {ex.Message}");
        }
        
    }

    if(op == "3")
    {
        var todos = await db.Todos.AsNoTracking().ToListAsync();
        HomeView.ListTodos(todos);
        
        Console.Write("ID da tarefa feita: ");
        string read = Console.ReadLine();
        if(int.TryParse(read, out int id))
        {
            var todo = await db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if(todo == null)
            {
                Console.WriteLine("Tarefa não localizada!");

            }
            else
            {
                try
                {
                    Console.Write("Titulo: ");
                    string title = Console.ReadLine();
                    Console.Write("Descrição: ");
                    string description = Console.ReadLine();
                    Console.Write("Feita? (s - sim): ");
                    if(title != "")
                        todo.Title = title.Trim();
                    if(description != "")
                        todo.Description = description.Trim();
                    if(Console.ReadLine().ToUpper() == "S")
                    {
                        todo.IsDone = true;
                    }
                    else
                    {
                        todo.IsDone = false;
                    }
                        
                    db.Todos.Update(todo);
                    await db.SaveChangesAsync();
                    Console.Write("Tarefa atualizada!");
                }catch (Exception ex)
                {
                    Console.WriteLine($"Não foi possível atualizar a tarefa! {ex.Message}");
                }
            }
            Console.ReadKey();
        }
        
    }

    if(op == "4")
    {
        var todos = await db.Todos.Where(todo => todo.IsDone == false).AsNoTracking().ToListAsync();
        HomeView.ListTodos(todos);

        Console.Write("ID da tarefa feita: ");
        string read = Console.ReadLine();
        if (int.TryParse(read, out int id))
        {
            var todo = await db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (todo == null)
            {
                Console.WriteLine("Tarefa não localizada!");

            }
            else
            {
                try
                {
                    todo.IsDone = true;
                    db.Todos.Update(todo);
                    await db.SaveChangesAsync();
                    Console.Write("Tarefa Concluída!");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Não foi possível atualizar a tarefa! {ex.Message}");
                }
            }
            Console.ReadKey();
        }
    }

    if (op == "5")
    {
        var todos = await db.Todos.AsNoTracking().ToListAsync();
        HomeView.ListTodos(todos);

        Console.Write("ID da tarefa: ");
        string read = Console.ReadLine();
        if (int.TryParse(read, out int id))
        {
            var todo = await db.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (todo == null)
            {
                Console.WriteLine("Tarefa não localizada!");

            }
            else
            {
                try
                {
                    
                    db.Remove(todo);
                    await db.SaveChangesAsync();
                    Console.Write("Tarefa Excluída!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Não foi possível excluir a tarefa! {ex.Message}");
                }
            }
            Console.ReadKey();
        }
    }

    if(op == "6")
    {
        var todos = await db.Todos.Where(todo => todo.IsDone == true).AsNoTracking().ToListAsync();

        HomeView.ListTodos(todos);
        Console.Write("Aperte para continuar...");
        Console.ReadKey();
    }
}


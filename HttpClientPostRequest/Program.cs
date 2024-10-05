using System.Net;
using System.Reflection;
using System.Threading.Tasks;

Console.Title = "RND Brute Force - R3N@T0 S@NT05";
Console.ForegroundColor = ConsoleColor.Green;
Thread.Sleep(500);
Console.WriteLine("##############################################");
Console.WriteLine("           BRUTE FORCE C# RND - APP ");
Console.WriteLine("##############################################");
Thread.Sleep(500);
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("DNS ALVO:");
Thread.Sleep(500);
Console.WriteLine($"-------------------------------------");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"URL: http://localhost:81/login/");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"-------------------------------------");
Console.ForegroundColor = ConsoleColor.White;
Thread.Sleep(500);
Console.Write($"AUTOR: ");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"RENATO SANTOS");
Console.ForegroundColor = ConsoleColor.White;
Thread.Sleep(500);
Console.WriteLine($"APP: C# NET Core 6");
Thread.Sleep(500);
Console.Clear();


HttpClientPostRequest.HttpCli Client = new HttpClientPostRequest.HttpCli();

//HttpClientPostRequest.HttpCli.strTXTBiblia = File.ReadAllText("Arq.txt");

#region"BLOCO USANDO LOOP FOR"
/*
long qtdPostRequest = 100;
for (long i = 0; i < qtdPostRequest; i++)
{
  
    try
    {    
        i++;

        var t = Task.Factory.StartNew(() =>
        {
            HttpClientPostRequest.HttpCli.Client(i);

        },TaskCreationOptions.AttachedToParent);

        t.Wait();
        
        Console.WriteLine($"Task Concluida: {t?.IsCompleted ?? false}");
        Console.WriteLine($"Thread principal saindo: {t?.Id}");
        Console.WriteLine($"-----------------------------------");


       
        t.Wait();
        if (t.IsCompletedSuccessfully)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"TaskCompletaID: {t.Id}");
            Console.WriteLine($"-----------------------------------------");
        }
    
    }

 
    catch (Exception ex)
    {
        using (StreamWriter writer = new StreamWriter($"TaskErro.txt", append: true))
        {
            writer.WriteLine($"ExceptionTask: {ex.Message}");
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }


}
*/
#endregion

#region"BLOCO LOOP INFINITO"
long i = 0;
while (true)
{   
	try
	{
        i++;

        var t = Task.Factory.StartNew(() =>
        {
            HttpClientPostRequest.HttpCli.Client(i);

        },TaskCreationOptions.AttachedToParent);

        t.Wait();
        
        //Console.Clear();
        //Console.WriteLine($"Task Concluida: {t?.IsCompleted ?? false}");
        //Console.WriteLine($"Thread principal saindo: {t?.Id}");
        //Console.WriteLine($"-------------------------------------");
   
    }
	catch (Exception ex)
	{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = ConsoleColor.White;

        /*
        using (StreamWriter writer = new StreamWriter($"MainExceptionTask{i}.txt", append: false))
        {
            writer.WriteLine($"MainExceptionTask: {ex.Message}");
        }
        */
    }
}
#endregion



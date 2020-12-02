using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var  indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Aluno aluno = new Aluno();

                        Console.WriteLine("Informe o nome do aluno:");
                        aluno.Nome = Console.ReadLine();
                        indiceAluno++;

                        Console.WriteLine("Informe a nota dele:");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)) 
                        {
                            aluno.Nota = nota;
                        }
                        else 
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach(var aaluno in alunos) {
                            if (!string.IsNullOrEmpty(aaluno.Nome)) 
                            {
                                Console.WriteLine($"Aluno: {aaluno.Nome} - Nota:{aaluno.Nota}");
                            }
                        }
                        break;
                    case "3":
                        var nmrAlunos = 0;
                        decimal notaTotal = 0;
                        for(int i = 0; i < indiceAluno; i++) {
                            if(!string.IsNullOrEmpty(alunos[i].Nome)) {
                                notaTotal += alunos[i].Nota;
                                nmrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nmrAlunos;
                        Console.WriteLine($"Media geral: {mediaGeral}");
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular media geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
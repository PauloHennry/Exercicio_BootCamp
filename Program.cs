using System;

namespace cSharp_Exemples
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();



            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("O nome do aluno: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

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
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var ntAlunos = 0;

                        for(int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                ntAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / ntAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                         Console.WriteLine($"MEDIA GERAL: {mediaGeral} CONCEITO: {conceitoGeral}");

                         Console.WriteLine($"MEDIA GERAL: {mediaGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                Console.WriteLine("Informe a opção desejada: ");
                Console.WriteLine();
                Console.WriteLine("1 - Insira um novo aluno");
                Console.WriteLine("2 - Listar alunos");
                Console.WriteLine("3 - Cálcular média geral");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                opcaoUsuario = Console.ReadLine();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1 - Insira um novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Cálcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}

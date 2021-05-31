using System;

namespace media
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indice_aluno = 0;
            string opcao_usuario = ObterOpcaoUsuario();

            while (opcao_usuario.ToUpper() != "X")
            {
                switch (opcao_usuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indice_aluno] = aluno;
                        indice_aluno++;

                        break;
                    case "2":
                        foreach (Aluno a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome}; NOTA: {a.Nota};");
                            }
                        }
                        break;
                    case "3":
                        decimal nota_total = 0;
                        var n_alunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                nota_total = nota_total + alunos[i].Nota;
                                n_alunos++;
                            }
                        }

                        var media_geral = nota_total / n_alunos;
                        Conceito conceito_geral;

                        if (media_geral < 3)
                        {
                            conceito_geral = Conceito.E;
                        }
                        else if (media_geral < 4)
                        {
                            conceito_geral = Conceito.D;
                        }
                        else if (media_geral < 6)
                        {
                            conceito_geral = Conceito.C;
                        }
                        else if (media_geral < 8)
                        {
                            conceito_geral = Conceito.B;
                        }
                        else
                        {
                            conceito_geral = Conceito.A;
                        }
                        
                        Console.WriteLine($"MÉDIA GERAL: {media_geral}; CONCEITO: {conceito_geral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao_usuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcao_usuario = Console.ReadLine();
            Console.WriteLine();
            return opcao_usuario;
        }
    }
}


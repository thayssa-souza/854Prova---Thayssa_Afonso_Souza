namespace Dotnet;

class Program
{
    static string[,] PcTabuleiro()
    {
        string[,] pcJogador = new string[10, 10]
        {
            {"DS1"," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {"DS1"," . ","BS1","BS1"," . ","BS2","BS2"," . "," . "," . "},
            {"DS1"," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . ","NT1","NT1","NT1","NT1"," . "},
            {"DS2"," . "," . ","PS1"," . "," . "," . "," . "," . ","BS3"},
            {"DS2"," . "," . ","PS1"," . "," . "," . "," . "," . ","BS3"},
            {"DS2"," . "," . ","PS1"," . "," . "," . ","BS4","BS4"," . "},
            {" . "," . "," . ","PS1","DS3","DS3","DS3"," . "," . "," . "},
            {" . "," . "," . ","PS1"," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . ","NT2","NT2","NT2","NT2"," . "}
        };


        return pcJogador;
    }  

    static string[,] montarTabuleiro(List<(string Nome, int Tamanho, int Quantidade)>listaTupla, Dictionary<string, int>posicaoLinha, Dictionary<string, int> posicaoColuna)
    {
        string[,] jogadorTabuleiro = new string[,]
        {
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "}
        };


        bool todasEmbarcacoesColocadas = false;
        
        Dictionary<string, int> contarQuantidade = new Dictionary<string, int>();
        contarQuantidade.Add("PS", 0);
        contarQuantidade.Add("NT", 0);
        contarQuantidade.Add("DS", 0);
        contarQuantidade.Add("SB", 0);

        while(todasEmbarcacoesColocadas == false)
        {
            Console.WriteLine("Qual o tipo da embarcação?");
            string navio = Console.ReadLine();

            (string Nome, int Tamanho, int Quantidade) tupla = listaTupla.Find(tupla => tupla.Nome == navio);

            if(!listaTupla.Exists(tupla => tupla.Nome == navio))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }
            else if(contarQuantidade[navio] >= tupla.Quantidade)
            {
                Console.WriteLine("Quantidade dessa embarcação foi preenchida.");
                continue;
            }

            bool posicaoValida = false;

            string posicao = "";

            while(!posicaoValida)
            {
                Console.WriteLine($"Qual será a posição de {navio}?");
                posicao = Console.ReadLine();

                Console.WriteLine($"Posicao.Length: {posicao.Length}");

                for(int i = 0; i < posicao.Length; i = i + 2)
                {
                    string linha = posicao.Substring(i, 1);
                    string coluna = posicao.Substring(i + 1, 1);

                    if(coluna == "1" && i + 2 < posicao.Length && posicao.Substring(i + 1, 2) == "10") 
                    {
                        coluna = posicao.Substring(i + 1, 2);
                        i++;
                    }
                    
                    if(jogadorTabuleiro[posicaoLinha[linha], posicaoColuna[coluna]] != " . ") 
                    {
                        Console.WriteLine("Posição ja ocupada por outra embarcação.");
                        posicaoValida = false;
                        break;
                    }
                    posicaoValida = true;
                }
            }

            Console.Clear();

            for(int i = 0; i < posicao.Length; i = i + 2)
            {
                string linha = posicao.Substring(i, 1);
                string coluna = posicao.Substring(i + 1, 1);

                if(coluna == "1" && i + 2 < posicao.Length && posicao.Substring(i + 1, 2) == "10") 
                {
                    coluna = posicao.Substring(i + 1, 2);
                    i++;
                }

                jogadorTabuleiro[posicaoLinha[linha], posicaoColuna[coluna]] = navio + (contarQuantidade[navio] + 1);
            }

            contarQuantidade[navio]++;

            if(contarQuantidade["PS"] == 1 && contarQuantidade["NT"] == 0 && contarQuantidade["DS"] == 0 && contarQuantidade["SB"] == 0)
            {
                Console.WriteLine("Todas as embarcações foram colocadas.");
                todasEmbarcacoesColocadas = true;

            }
            var indexLinha = jogadorTabuleiro.GetLength(0);
            var indexColuna = jogadorTabuleiro.GetLength(1);

            for(int x = 0; x < indexLinha; x++)
            {
               for (int y = 0; y < indexColuna; y++)
               {
                   Console.Write($"{jogadorTabuleiro[x, y]}");
               }
               Console.WriteLine();
           } 
        }

        return jogadorTabuleiro;
    }
    static string[,] tabuleiroTiro()
    {
        string[,] tabuleiroVazio = new string[10, 10]
        {
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "},
            {" . "," . "," . "," . "," . "," . "," . "," . "," . "," . "}
        };

        return tabuleiroVazio;
    }
    static void Main(string[] args)
    {
        string[,] tabuleiroTiroJogador1 = tabuleiroTiro();
        string[,] tabuleiroTiroJogador2 = tabuleiroTiro();
        string[,] pcTurn = tabuleiroTiro();
        string[,] tabuleiroCheioJogador1;
        string[,] tabuleiroCheioJogador2;
        string[,] tabuleiroPC = PcTabuleiro();
        object[,] tabuleiro = new object[10, 10];
        string jogador1 = "";
        string jogador2 = "";

        string[] jogadasPC = new string[] {"B5", "B6", "B7", "E2", "F2", "G2", "H2", "I2"};
        int numeroJogadasPC = 0;

        var indiceLinha = new Dictionary<string, int>();
        indiceLinha.Add("A", 0);
        indiceLinha.Add("B", 1);
        indiceLinha.Add("C", 2);
        indiceLinha.Add("D", 3);
        indiceLinha.Add("E", 4);
        indiceLinha.Add("F", 5);
        indiceLinha.Add("G", 6);
        indiceLinha.Add("H", 7);
        indiceLinha.Add("I", 8);
        indiceLinha.Add("J", 9);

        var indiceColuna = new Dictionary<string, int>();
        indiceColuna.Add("1", 0);
        indiceColuna.Add("2", 1);
        indiceColuna.Add("3", 2);
        indiceColuna.Add("4", 3);
        indiceColuna.Add("5", 4);
        indiceColuna.Add("6", 5);
        indiceColuna.Add("7", 6);
        indiceColuna.Add("8", 7);
        indiceColuna.Add("9", 8);
        indiceColuna.Add("10", 9);

        var listaTupla = new List<(string Embarcacao, int Tamanho, int Quantidade)>();
        listaTupla.Add(("PS", 5, 1));
        listaTupla.Add(("NT", 4, 0));
        listaTupla.Add(("DS", 3, 0));
        listaTupla.Add(("SB", 2, 0));


        Console.WriteLine("Bem-vindo(a) ao Batalha Naval.");
        Console.WriteLine("Deseja ler as regras? Responda com S ou N.");
        string resposta = Console.ReadLine();
        if (resposta == "S")
        {
            Console.WriteLine("Regras:");
            Console.WriteLine("Utilize as siglas para preencher seu tabuleiro: 1 PS - Porta-avião ocupa 5 quadrantes; 2 NT - Navios-tanque ocupam 4 quadrantes; 3 DS - Destroyers ocupam 3 quadrantes; 4 SB - Submarinos ocupam 2 quadrantes.");
            Console.WriteLine("Cada embarcação deve respeitar o seu tamanho adequado.");
            Console.WriteLine("Uma embarcação não pode sobrepor a outra.");
            Console.WriteLine("As embarcações podem ser posicionadas na vertical ou horizontal, sempre formando uma reta, nunca uma diagonal.");
            Console.WriteLine("Quando o navio receber todos os disparos, ele afunda");
            Console.WriteLine("O jogo termina quando um o jogador afundar todos os navios do seu oponente.");
            Console.WriteLine("Começando o jogo.");
        }
        else
            Console.WriteLine("Começando o jogo.");

        Console.WriteLine("Você jogará sozinho? Responda com S ou N.");
        string novaResposta = Console.ReadLine();
        
        Console.WriteLine("Digite o nome do primeiro jogador:");
        jogador1 = Console.ReadLine();
        
        
        if (novaResposta == "N")
        {
            Console.WriteLine("Digite o nome do segundo jogador:");
            jogador2 = Console.ReadLine();
            Console.WriteLine($"Combate: {jogador1} vs {jogador2}");
        } 
        else 
        {
            Console.WriteLine($"Combate: {jogador1} vs Máquina");
        }
        Console.Clear();
        Console.WriteLine($"{jogador1} monte o seu tabuleiro:");
        tabuleiroCheioJogador1 = montarTabuleiro(listaTupla, indiceLinha, indiceColuna);
        Console.Clear();

        if (novaResposta == "N")
        {
            Console.WriteLine($"{jogador2} monte o seu tabuleiro:");
            tabuleiroCheioJogador2 = montarTabuleiro(listaTupla, indiceLinha, indiceColuna);
        }
        else
        {
            tabuleiroCheioJogador2 = tabuleiroPC;
        }
        Console.Clear();

        Console.WriteLine("Valendo!");
        Console.WriteLine($"{jogador1} este é o tabuleiro do seu adversário: ");

        var indexLinha = tabuleiroTiroJogador2.GetLength(0);
        var indexColuna = tabuleiroTiroJogador2.GetLength(1);
        for (var i = 0; i < indexLinha; i++)
        {
            for (var j = 0; j < indexLinha; j++)
            {
                Console.Write($"{tabuleiroTiroJogador2[i, j]}");
            }
            Console.WriteLine();
        }
                
        while(true)
        {
            Console.WriteLine($"{jogador1}, em qual posição você quer atirar?");
            string tiro = Console.ReadLine();
            string linha = tiro.Substring(0, 1);
            string coluna = tiro.Substring(1, 1);
            if(coluna == "1" && tiro.Length > 2 && tiro.Substring(2, 1) == "0") 
            {
                coluna = tiro.Substring(1, 2);
            }

            if (tabuleiroCheioJogador2[indiceLinha[linha], indiceColuna[coluna]] == " . ")
            {
                tabuleiroTiroJogador2[indiceLinha[linha], indiceColuna[coluna]] = " A ";
                Console.WriteLine("BUM... ÁGUA!");
            }
            else
            {
                tabuleiroTiroJogador2[indiceLinha[linha], indiceColuna[coluna]] = " X ";
                Console.WriteLine("BUM... EMBARCAÇÃO!");
            }

            indexLinha = tabuleiroTiroJogador2.GetLength(0);
            indexColuna = tabuleiroTiroJogador2.GetLength(1);
            for (var i = 0; i < indexLinha; i++)
            {
                for (var j = 0; j < indexLinha; j++)
                {
                    Console.Write($"{tabuleiroTiroJogador2[i, j]}");
                }
                Console.WriteLine();
            }

            bool ganhou = true;

            for(int i = 0; i < tabuleiroCheioJogador2.GetLength(0); i++)
            {
                for(int j = 0; j < tabuleiroCheioJogador2.GetLength(1); j++)
                {
                    if(tabuleiroCheioJogador2[i, j] == " . ") 
                    {
                        continue;
                    }
                    else {
                        if(tabuleiroTiroJogador2[i, j] != " X ") 
                        {
                            ganhou = false;
                        }
                    }
                }
            }

            if(ganhou)
            {
                Console.WriteLine($"Parabéns {jogador1} você DERROTOU o {jogador2}!");
                break;
            }

            if(novaResposta == "N")
            {
                Console.WriteLine($"{jogador2}, em qual posição você quer atirar?");
                tiro = Console.ReadLine();
            }
            else
            {
                tiro = jogadasPC[numeroJogadasPC];
                numeroJogadasPC++;
            }
            
            linha = tiro.Substring(0, 1);
            coluna = tiro.Substring(1, 1);
            if(coluna == "1" && tiro.Length > 2 && tiro.Substring(2, 1) == "0") 
            {
                coluna = tiro.Substring(1, 2);
            }

            if (tabuleiroCheioJogador1[indiceLinha[linha], indiceColuna[coluna]] == " . ")
            {
                tabuleiroTiroJogador1[indiceLinha[linha], indiceColuna[coluna]] = " A ";
                Console.WriteLine("SPLASH... ÁGUA!");
            }
            else
            {
                tabuleiroTiroJogador1[indiceLinha[linha], indiceColuna[coluna]] = " X ";
                Console.WriteLine("BUM... EMBARCAÇÃO!");
            }

            indexLinha = tabuleiroTiroJogador1.GetLength(0);
            indexColuna = tabuleiroTiroJogador1.GetLength(1);
            for (var i = 0; i < indexLinha; i++)
            {
                for (var j = 0; j < indexLinha; j++)
                {
                    Console.Write($"{tabuleiroTiroJogador1[i, j]}");
                }
                Console.WriteLine();
            }

            for(int i = 0; i < tabuleiroCheioJogador1.GetLength(0); i++)
            {
                for(int j = 0; j < tabuleiroCheioJogador1.GetLength(1); j++)
                {
                    if(tabuleiroCheioJogador1[i, j] == " . ") 
                    {
                        continue;
                    }
                    else {
                        if(tabuleiroTiroJogador1[i, j] != " X ") 
                        {
                            ganhou = false;
                        }
                    }
                }
            }

            if(ganhou)
            {
                Console.WriteLine($"Parabéns {jogador2} você DERROTOU o {jogador1}!");
                break;
            }
        } 
                
    }
        
    
}
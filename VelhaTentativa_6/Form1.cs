using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VelhaTentativa_6
{
 
        public partial class Form1 : Form
        {
            int jogo; // 0- o jogo nao começou, 1-vs PC
            int placar1, placar2;
            int jogador; //jogador da vez
            // 1 - O , 2 - X
			
			//forma encontrada para colcoar imegem no botao, imagem criada no fireworks com um x e uma bolinha 

            Image bola_preta = Image.FromFile("C:/Users/Johnatan/Desktop/JogoDaVelha/bola_preta.jpg");
            Image x_preto = Image.FromFile("C:/Users/Johnatan/Desktop/JogoDaVelha/x_preto.jpg");
           

            int[,] tabela = new int[3, 3];// define a matriz sendo 3 x 3

            public Form1()
            {
                InitializeComponent();
                jogo = 0;
            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }

            
            private void btnPc_Click(object sender, EventArgs e)
            {
                jogo = 1;
                placar1 = placar2 = 0;
                jogador = 1;
                lblAviso.Text = "                               Vez do O";
                lblPlacar.Text = "Usuario   " + placar1 + "  X  " + placar2 + "   Computador";
                lblId1.Text = "O - Usuario";
                lblId2.Text = "X - Computador";
                zerar();
            }

         

            private void mudaCor(int n, int m, int player)
            {
                if (player == 2)
                {
                    if (n == 0)
                    {
                        if (m == 0)
                        {
                            b11.BackgroundImage = x_preto;
                        }
                        else if (m == 1)
                        {
                            b12.BackgroundImage = x_preto;
                        }
                        else
                            b13.BackgroundImage = x_preto;
                    }
                    else if (n == 1)
                    {
                        if (m == 0)
                        {
                            b21.BackgroundImage = x_preto;
                        }
                        else if (m == 1)
                        {
                            b22.BackgroundImage = x_preto;
                        }
                        else
                        {
                            b23.BackgroundImage = x_preto;
                        }
                    }
                    else
                    {
                        if (m == 0)
                        {
                            b31.BackgroundImage = x_preto; 
                        }
                        else if (m == 1)
                        {
                            b32.BackgroundImage = x_preto;
                        }
                        else
                        {
                            b33.BackgroundImage = x_preto; 
                        }
                    }
                }
                else
                {
                    if (n == 0)
                    {
                        if (m == 0)
                        {
                            b11.BackgroundImage = bola_preta;
                        }
                        else if (m == 1)
                        {
                            b12.BackgroundImage = bola_preta;
                        }
                        else
                        {
                            b13.BackgroundImage = bola_preta; 
                        }
                    }
                    else if (n == 1)
                    {
                        if (m == 0)
                        {
                            b21.BackgroundImage = bola_preta; 
                        }
                        else if (m == 1)
                        {
                            b22.BackgroundImage = bola_preta;
                        }
                        else
                        {
                            b23.BackgroundImage = bola_preta; 
                        }
                    }
                    else
                    {
                        if (m == 0)
                        {
                            b31.BackgroundImage = bola_preta; 
                        }
                        else if (m == 1)
                        {
                            b32.BackgroundImage = bola_preta;
                        }
                        else
                        {
                            b33.BackgroundImage = bola_preta; 
                        }
                    }
                }
            }

            //retorna 1 se acabou o jogo e 2 se empatou
            // private int verificaJogo(int vez) 
        private int verificaJogo(int vez)
            {
                int i, j, player, aux;

                if (vez == 1)
                {
                    lblAviso.Text = "                               Vez do X";
                }
                else
                {
                    lblAviso.Text = "                               Vez do O"; 
                }

                for (i = 0; i < 3; i++)
                {
                    player = tabela[i, 0];
                    if (vez == player)
                    {
                        if (tabela[i, 0] == tabela[i, 1] && tabela[i, 0] == tabela[i, 2])
                        {
                            mudaCor(i, 0, player);
                            mudaCor(i, 1, player);
                            mudaCor(i, 2, player);
                            return 1;
                        }
                    }
                    player = tabela[0, i];
                    if (vez == player)
                    {
                        if (tabela[0, i] == tabela[1, i] && tabela[2, i] == tabela[0, i])
                        {
                            mudaCor(0, i, player);
                            mudaCor(1, i, player);
                            mudaCor(2, i, player);
                            return 1;
                        }
                    }

                player = tabela[1, 1];
                if (player == vez)
                {
                    if (tabela[1, 1] == tabela[0, 0] && tabela[1, 1] == tabela[2, 2])
                    {
                        mudaCor(1, 1, player);
                        mudaCor(0, 0, player);
                        mudaCor(2, 2, player);
                        return 1;
                    }
                    if (tabela[1, 1] == tabela[2, 0] && tabela[1, 1] == tabela[0, 2])
                    {
                        mudaCor(2, 0, player);
                        mudaCor(1, 1, player);
                        mudaCor(0, 2, player);
                        return 1;
                    }
                }

                aux = 0;
                for (i = 0; i < 3; i++)
                    for (j = 0; j < 3; j++)
                    {
                        if (tabela[i, j] == 0)
                            break;
                        else
                            aux++;
                    }
                if (aux == 9)
                {
                    return 2;
                }

                if (jogo == 1 && vez == 1)
                {
                    computador();// para chamar a função
                }

                if (jogo == 1)
                {
                    jogador = 1;//para voltar a vez para o usuario
                }

                return 0;
            }

            private void zerar()
            {
                int i, j;
                for (i = 0; i < 3; i++)
                    for (j = 0; j < 3; j++)
                        tabela[i, j] = 0;
              
                b11.BackgroundImage = null;// para zerar
                b12.BackgroundImage = null;// para zerar
                b13.BackgroundImage = null;// para zerar
                b21.BackgroundImage = null;// para zerar
                b22.BackgroundImage = null;// para zerar
                b23.BackgroundImage = null;// para zerar
                b31.BackgroundImage = null;// para zerar
                b32.BackgroundImage = null;// para zerar
                b33.BackgroundImage = null;// para zerar
            }
// aqui eu vou verificar quem foi q ganhou o jogo  e exibir a mensagem para o meu usuario
            private void fimJogo(int vencedor)
            {
                if (vencedor == 0)
                {
                    MessageBox.Show("VIXI, Empatou!!");
                }
                else if (jogo == 1)
                {
                    if (vencedor == 1)
                    {
                        placar1++;
                        // PARA EXIBIR A MENSAGEM PARA O USUARIO
                        MessageBox.Show("Você ganhou!!\n Usuario " + placar1 + " X " + placar2 + " Computador");
                    }
                    else
                    {
                        placar2++;
                        // PARA EXIBIR A MENSAGEM PARA O USUARIO
                        MessageBox.Show("Você Perdeu!!\n Usuario " + placar1 + " X " + placar2 + " Computador");
                    }
                    lblPlacar.Text = "Usuario   " + placar1 + "  X  " + placar2 + "   Computador";
                }
                
                zerar(); //zera a tabela do jogo 
            }

            //aqui e a parte q gera a logica para a jogada do meu computador
            private void marcar(int n, int m)
            {
                if (n == 0)
                {
                    if (m == 0)
                                      //  x| |// posição do x
                        //                 | |
                       //                  | |
                        b11.BackgroundImage = x_preto;
                    else if (m == 1)
                        //se o botao do meu formulario  = "X";
                        /*                       |x|
                                                 | |
                                                 | |      */
                        b12.BackgroundImage = x_preto;
                    else
                        //se o botao do meu formulario  = "X";
                        /*                       | |x
                                                 | |           
                                                 | |        */
                        b13.BackgroundImage = x_preto;
                }
                else if (n == 1)
                {
                    if (m == 0)
                        /*                        | |
                                                 x| |
                                                  | |    */
                        b21.BackgroundImage = x_preto;
                    else if (m == 1)
                        /*                        | |
                                                  |x|
                                                  | |     */
                        b22.BackgroundImage = x_preto;
                    else
                        /*                        | |
                                                  | |x
                                                  | |    */
                        b23.BackgroundImage = x_preto;
                }
                else
                {
                    if (m == 0)//so uma linha nao precisa de abrir e fechar o if nao 
                        /*                        | |
                                                  | |
                                                 x| |     */
                        b31.BackgroundImage = x_preto;
                    else if (m == 1)
                        /*                        | |
                                                  | |
                                                  |x|             */
                        b32.BackgroundImage = x_preto;
                    else
                        /*                        | |
                                                  | |
                                                  | |x     */
                        b33.BackgroundImage = x_preto;
                }
            }

            private void computador()
            {
                int i, j, aux = 0, cont;
                int p = -1, q = -1, r = -1, s = -1; //como  na logoca do papel, tenho que criar um indice auxiliar das possiveis jogadas que o pc pode fazer para tentarganhar o jogo
                //então eu vou salvar os locai onde e masi provavel que com mais de uma jogada o pc ganhe

                //para verificar se é possivel ganhar na proxima jogada.
                for (i = 0; i < 3; i++)
                {
                    cont = 0;
                    for (j = 0; j < 3; j++)
                    {
                        if (tabela[i, j] == 1)
                        {
                            cont = -1;
                            break;
                        }
                        if (tabela[i, j] == 2)
                        {
						  cont++;
						}
                        else
                        {
                            p = i;
                            q = j;
                        }
                    }
                    if (cont == 2) //para criar a linha 
                    {
                        for (j = 0; j < 3; j++)
                        {
                            if (tabela[i, j] == 0)
                            {
                                tabela[i, j] = 2;
                                marcar(i, j);
                                break;
                            }
                        }
                        aux = 1;
                        break;
                    }
                    else if (cont == -1)
                    {
                        p = q = -1;
                    }

                    cont = 0;
                    for (j = 0; j < 3; j++)
                    {
                        if (tabela[j, i] == 1)
                        {
                            cont = -1;
                            break;
                        }
                        if (tabela[j, i] == 2)
                        {
							cont++;
						}
                        else
                        {
                            p = j; //salva na variavel a  coluna
                            q = i;//salva na variavel a  linha
                        }
                    }
                    if (cont == 2) //para criar uma coluna
                    {
                        for (j = 0; j < 3; j++)
                            if (tabela[j, i] == 0)
                            {
                                tabela[j, i] = 2;
                                marcar(j, i);
                                break;
                            }
                        aux = 1;
                        break;
                    }
                    else if (cont == -1)
                        p = q = -1;
                }

                //para checar a diagonal
                if (aux == 0 && (tabela[1, 1] == 2 || tabela[1, 1] == 0))
                {
                    cont = 0;
                    for (i = 0; i < 3; i++)
                    {
                        if (tabela[i, i] == 1)
                         {  
							cont = -5;
						 }
                        else if (tabela[i, i] == 2)
                        { 
						cont++;
						}
                        else
                        {    p = q = i;}
                        for (j = 0; j < 3; j++)
                        {
                            if (i + j == 2)
                            {
                                if (tabela[i, j] == 2)
                                    aux++;
                                else if (tabela[i, j] == 1)
                                    aux = -5;
                                else
                                {
                                    r = i;
                                    s = j;
                                }
                            }
                        }
                    }

                    if (cont == 2)
                    {
                        for (j = 0; j < 3; j++)
                            if (tabela[j, j] == 0)
                            {
                                tabela[j, j] = 2;
                                marcar(j, j);
                                break;
                            }
                        aux = 1;
                    }
                    else if (aux == 2)
                    {
                        for (i = 0; i < 3; i++)
                            for (j = 0; j < 3; j++)
                                if (i + j == 2 && tabela[i, j] == 0)
                                {
                                    tabela[i, j] = 2;
                                    marcar(i, j);
                                    break;
                                }
                        aux = 1;
                    }
                    else if (cont < 0 && aux < 0)
                    {
                        p = q = r = s = -1;
                        aux = 0;
                    }
                    else if (cont < 0)
                    {
                        p = q = -1;
                        aux = 0;
                    }
                    else
                        aux = 0;
                }

                //verifica se é necessário bloquear a jogada do usuário para evitar dele ganhar
                if (aux == 0)
                {
                    for (i = 0; i < 3; i++)
                    {
                        cont = 0;
                        for (j = 0; j < 3; j++)
                        {
                            if (tabela[i, j] == 2)
                            {
                                cont = -1;
                                break;
                            }
                            if (tabela[i, j] == 1)
                                cont++;
                        }
                        if (cont == 2) //o oponente pode fazer essa linha
                        {
                            for (j = 0; j < 3; j++)
                                if (tabela[i, j] == 0)
                                {
                                    tabela[i, j] = 2;
                                    marcar(i, j);
                                    break;
                                }
                            aux = 1;
                            break;
                        }

                        cont = 0;
                        for (j = 0; j < 3; j++)
                        {
                            if (tabela[j, i] == 2)
                            {
                                cont = -1;
                                break;
                            }
                            if (tabela[j, i] == 1)
                                cont++;
                        }
                        if (cont == 2) //possivel chance do meu  oponente fazer a jogada
                        {
                            for (j = 0; j < 3; j++)
                                if (tabela[j, i] == 0)
                                {
                                    tabela[j, i] = 2;
                                    marcar(j, i);
                                    break;
                                }
                            aux = 1;
                            break;
                        }
                    }

                    //verifica se a diagonal  precisa de bloqueio
                    if (aux == 0 && (tabela[1, 1] == 1 || tabela[1, 1] == 0))
                    {
                        cont = 0;
                        for (i = 0; i < 3; i++)
                        {
                            if (tabela[i, i] == 1)
                                cont++;
                            for (j = 0; j < 3; j++)
                            {
                                if (i + j == 2)
                                {
                                    if (tabela[i, j] == 1)
                                        aux++;
                                    else if (tabela[i, j] == 2)
                                        aux = -5;
                                }
                            }
                        }

                        if (cont == 2)
                        {
                            for (j = 0; j < 3; j++)
                                if (tabela[j, j] == 0)
                                {
                                    tabela[j, j] = 2;
                                    marcar(j, j);
                                    break;
                                }
                            aux = 1;
                        }
                        else if (aux == 2)
                        {
                            for (i = 0; i < 3; i++)
                                for (j = 0; j < 3; j++)
                                    if (i + j == 2 && tabela[i, j] == 0)
                                    {
                                        tabela[i, j] = 2;
                                        marcar(i, j);
                                        break;
                                    }
                            aux = 1;
                        }
                        else
                        {
                            aux = 0;
                        }
                    }
                }

                //coloca preferencialmente no meio, onde me oferece mais  opçoes de ganahr 
                if (aux == 0 && tabela[1, 1] == 0)
                {
                    tabela[1, 1] = 2;
                    // "X";
                    b22.BackgroundImage = x_preto;
                    aux = 1;
                }

                
                if (aux == 0)
                {
                    if (p > 0 && q > 0)
                    {
                        tabela[p, q] = 2;
                        marcar(p, q);
                    }
                    else if (r > 0 && s > 0)
                    {
                        tabela[r, s] = 2;
                        marcar(r, s);
                    }
                    else
                    {
                        //random gera aleatorio  caso nao tenha como colcoar no meio ,pois o primeiro jogo nao é de tao suma importancia 
                        //colocar em qualquer lugar
                        Random aux1 = new Random(DateTime.Now.Millisecond);
                        int lugar;
                        while (aux == 0)
                        {
                            lugar = aux1.Next() % 9;
                            if (lugar == 0 && tabela[0, 0] == 0)
                            {
                                tabela[0, 0] = 2;
                                marcar(0, 0);
                                break;
                            }
                            else if (lugar == 1 && tabela[0, 1] == 0)
                            {
                                tabela[0, 1] = 2;
                                marcar(0, 1);
                                break;
                            }
                            else if (lugar == 2 && tabela[0, 2] == 0)
                            {
                                tabela[0, 2] = 2;
                                marcar(0, 2);
                                break;
                            }
                            else if (lugar == 3 && tabela[1, 0] == 0)
                            {
                                tabela[1, 0] = 2;
                                marcar(1, 0);
                                break;
                            }
                            else if (lugar == 4 && tabela[1, 1] == 0)
                            {
                                tabela[1, 1] = 2;
                                marcar(1, 1);
                                break;
                            }
                            else if (lugar == 5 && tabela[1, 2] == 0)
                            {
                                tabela[1, 2] = 2;
                                marcar(1, 2);
                                break;
                            }
                            else if (lugar == 6 && tabela[2, 0] == 0)
                            {
                                tabela[2, 0] = 2;
                                marcar(2, 0);
                                break;
                            }
                            else if (lugar == 7 && tabela[2, 1] == 0)
                            {
                                tabela[2, 1] = 2;
                                marcar(2, 1);
                                break;
                            }
                            else if (lugar == 8 && tabela[2, 2] == 0)
                            {
                                tabela[2, 2] = 2;
                                marcar(2, 2);
                                break;
                            }
                        }
                    }
                }
                aux = verificaJogo(2);
                if (aux == 1)
                    {
					fimJogo(2);
					}
                else if (aux == 2)
                   {
				   fimJogo(0);
				   }
            }

            private void b1_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[0, 0] == 0)
                {
                    tabela[0, 0] = jogador;
                    if (jogador == 1)
                    {
                        // "O";
                        b11.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        // "X";
                        b11.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));// resto 
                    if (aux == 1)
                       {
					   fimJogo(2 - ((jogador + 1) % 2));
					   }
                    else if (aux == 2)
                    {
					fimJogo(0);
					}
                }
            }

            private void b2_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[0, 1] == 0)
                {
                    tabela[0, 1] = jogador;
                    if (jogador == 1)
                    {
                        // "O";
                        b12.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        //"X";
                        b12.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                       {
					   fimJogo(2 - ((jogador + 1) % 2));
					   }
                    else if (aux == 2)
                      {
					  fimJogo(0);
					  }
                }
            }

            private void b13_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[0, 2] == 0)
                {
                    tabela[0, 2] = jogador;
                    if (jogador == 1)
                    {
                        //"O";
                        b13.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        // "X";
                        b13.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                        {
						fimJogo(2 - ((jogador + 1) % 2));
						}
                    else if (aux == 2)
                       {
					   fimJogo(0);
					   }
                }
            }

            private void b21_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[1, 0] == 0)
                {
                    tabela[1, 0] = jogador;
                    if (jogador == 1)
                    {
                        //"O";
                        b21.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        //"X";
                        b21.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                       {
					   fimJogo(2 - ((jogador + 1) % 2));
					   }
                    else if (aux == 2)
                        {
						fimJogo(0);
						}
                }
            }

            private void b22_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[1, 1] == 0)
                {
                    tabela[1, 1] = jogador;
                    if (jogador == 1)
                    {
                        //"O";
                        b22.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        // "X";
                        b22.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                      {
					  fimJogo(2 - ((jogador + 1) % 2));
					  }
                    else if (aux == 2)
                      {
						fimJogo(0);
					  }
                }
            }

            private void b23_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[1, 2] == 0)
                {
                    tabela[1, 2] = jogador;
                    if (jogador == 1)
                    {
                        // "O";
                        b23.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        // "X";
                        b23.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                        {
						fimJogo(2 - ((jogador + 1) % 2));
						}
                    else if (aux == 2)
                      {
						fimJogo(0);
					  }
                }
            }

            private void b31_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[2, 0] == 0)
                {
                    tabela[2, 0] = jogador;
                    if (jogador == 1)
                    {
                        //"O";
                        b31.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        // "X";
                        b31.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                       {
					   fimJogo(2 - ((jogador + 1) % 2));
					   }
                    else if (aux == 2)
                      {
					  fimJogo(0);
					  }
                }
            }

            private void b32_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[2, 1] == 0)
                {
                    tabela[2, 1] = jogador;
                    if (jogador == 1)
                    {
                        //"O";
                        b32.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        //"X";
                        b32.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                       { 
					   fimJogo(2 - ((jogador + 1) % 2));
					   }
                    else if (aux == 2)
                       {
					   fimJogo(0);
					   }
                }
            }

            private void b33_Click(object sender, EventArgs e)
            {
                int aux;
                if (jogo > 0 && tabela[2, 2] == 0)
                {
                    tabela[2, 2] = jogador;
                    if (jogador == 1)
                    {
                        //"O";
                        b33.BackgroundImage = bola_preta;
                        jogador = 2;
                    }
                    else
                    {
                        //"X";
                        b33.BackgroundImage = x_preto;
                        jogador = 1;
                    }
                    aux = verificaJogo(2 - ((jogador + 1) % 2));
                    if (aux == 1)
                        {
						fimJogo(2 - ((jogador + 1) % 2));
						}
                    else if (aux == 2)
                        {
						fimJogo(0);
						}
                }
            }
        }
    }
}
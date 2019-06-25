using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace BoatEscape
{
    class Program
    {
        //float rot = 0.0f;
        static float iceZ = 0.0f;
        static float iceX = 0.0f;
        static float b = 0.0f;
        static int clock = 150;
        static Random random = new Random();
        static int pontuacao = 0;
        static string jogador = "";
        static bool colisao = true;


        static void barco()
        {
            Gl.glBegin(Gl.GL_QUADS);

            Cor(0.6f, 0.4f, 0.1f);
            // Face Lateral Direita
            Gl.glVertex3f(0.1f, -0.3f, -0.2f);
            Gl.glVertex3f(0.2f, 0.0f, -0.4f);
            Gl.glVertex3f(0.2f, 0.0f, 0.4f);
            Gl.glVertex3f(0.1f, -0.3f, 0.2f);
            // Face Lateral Esquerda
            Gl.glVertex3f(-0.1f, -0.3f, -0.2f);
            Gl.glVertex3f(-0.2f, 0.0f, -0.4f);
            Gl.glVertex3f(-0.2f, 0.0f, 0.4f);
            Gl.glVertex3f(-0.1f, -0.3f, 0.2f);

            Cor(0.5f, 0.35f, 0.1f);
            // Face Lateral Fundo
            Gl.glVertex3f(-0.1f, -0.3f, -0.2f);
            Gl.glVertex3f(0.1f, -0.3f, -0.2f);
            Gl.glVertex3f(0.2f, 0.0f, -0.4f);
            Gl.glVertex3f(-0.2f, 0.0f, -0.4f);
            //// Face Lateral Frente
            Gl.glVertex3f(-0.1f, -0.3f, 0.2f);
            Gl.glVertex3f(0.1f, -0.3f, 0.2f);
            Gl.glVertex3f(0.2f, 0.0f, 0.4f);
            Gl.glVertex3f(-0.2f, 0.0f, 0.4f);

            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            //Face Inferior
            Cor(0.7f, 0.35f, 0.1f);
            Gl.glVertex3f(-0.1f, -0.3f, -0.2f);
            Gl.glVertex3f(0.1f, -0.3f, -0.2f);
            Gl.glVertex3f(0.1f, -0.3f, 0.2f);
            Gl.glVertex3f(-0.1f, -0.3f, 0.2f);

            Gl.glEnd();

            //// Mastro
            Gl.glBegin(Gl.GL_LINES);

            Cor(1.2f, 1.2f, 1.2f);
            Gl.glPointSize(30);
            Gl.glVertex3f(0.0f, -0.3f, 0.0f);
            Gl.glVertex3f(0.0f, 1.1f, 0.0f);
            Gl.glEnd();

            //// Caravela
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            //Frontal Direita
            Gl.glVertex3f(0.0f, 1.1f, 0.0f);
            Gl.glVertex3f(0.0f, 0.3f, 0.35f);
            Gl.glVertex3f(0.075f, 0.3f, 0.0f);

            //Frontal Esquerda
            Gl.glVertex3f(0.0f, 1.1f, 0.0f);
            Gl.glVertex3f(0.0f, 0.3f, 0.35f);
            Gl.glVertex3f(-0.075f, 0.3f, 0.0f);

            //Traseira Direita
            Cor(1.5f, 1.5f, 1.5f);
            Gl.glVertex3f(0.0f, 1.1f, 0.0f);
            Gl.glVertex3f(0.0f, 0.3f, -0.35f);
            Gl.glVertex3f(0.075f, 0.3f, 0.0f);

            //Traseira Esquerda
            Gl.glVertex3f(0.0f, 1.1f, 0.0f);
            Gl.glVertex3f(0.0f, 0.3f, -0.35f);
            Gl.glVertex3f(-0.075f, 0.3f, 0.0f);

            //Fundo da caravela
            Gl.glVertex3f(-0.05f, 0.3f, 0.0f);
            Gl.glVertex3f(0.0f, 0.3f, 0.35f);
            Gl.glVertex3f(0.075f, 0.3f, 0.0f);

            Gl.glVertex3f(-0.05f, 0.3f, 0.0f);
            Gl.glVertex3f(0.0f, 0.3f, -0.35f);
            Gl.glVertex3f(0.075f, 0.3f, 0.0f);
            Gl.glEnd();
        }

        static void mar()
        {
            Cor(0.498039f, 1f, 0.831373f);
            Glut.glutSolidCube(20.0f);
        }

        static void sol()
        {
            Cor(1.0f, 1.0f, 0.0f);
            Glut.glutSolidSphere(0.2f, 20, 20);
        }

        static void ice()
        {
            Gl.glBegin(Gl.GL_TRIANGLES);
            //Face frontal
            Cor(1.5f, 1.5f, 1.5f);
            Gl.glVertex3f(-0.2f, -0.5f, -0.7f);
            Gl.glVertex3f(-0.1f, -0.65f, -0.6f);
            Gl.glVertex3f(-0.3f, -0.65f, -0.6f);

            //Face traseira esquerda
            Cor(1.7f, 1.7f, 1.7f);
            Gl.glVertex3f(-0.2f, -0.5f, -0.7f);
            Gl.glVertex3f(-0.3f, -0.65f, -0.6f);
            Gl.glVertex3f(-0.2f, -0.65f, -0.8f);

            //Face traseira direita
            Cor(1.8f, 1.8f, 1.8f);
            Gl.glVertex3f(-0.2f, -0.5f, -0.7f);
            Gl.glVertex3f(-0.2f, -0.65f, -0.8f);
            Gl.glVertex3f(-0.1f, -0.65f, -0.6f);

            //Face inferior
            Gl.glVertex3f(-0.3f, -0.65f, -0.6f);
            Gl.glVertex3f(-0.2f, -0.65f, -0.8f);
            Gl.glVertex3f(-0.1f, -0.65f, -0.6f);
            Gl.glEnd();
        }

        static void inicializa()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(35.0f, 1.0, 0.001, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            DefineIluminacao();
            Glu.gluLookAt(0.0, 4.0, 4.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            Gl.glClearColor(1f, 0.5f, 0f, 0.0f);
        }

        static void desenha()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, -16.5f, 0.0f);
            Gl.glRotatef(-20, 1.0f, 0.0f, 0.0f);
            mar();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(0.9f, 1.8f, 0.8f);
            sol();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, 1.45f);
            Gl.glTranslatef(b, 0.0f, 0.0f);
            barco();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(0.2f, -0.3f, -1.1f);
            Gl.glTranslatef(0.0f, 0.0f, iceZ);
            Gl.glTranslatef(iceX, 0.0f, 0.0f);
            ice();
            Gl.glPopMatrix();

            Glut.glutSwapBuffers();
        }

        static void DefineIluminacao()
        {

            // Habilitando a iluminação
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            // Definindo a intensidade da luz e cores
            float[] LuzAmbiente = { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] LuzDifusa = { 0.8f, 0.8f, 0.8f, 1.0f };
            float[] LuzEspecular = { 1.0f, 1.0f, 1.0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, LuzAmbiente);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, LuzDifusa);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, LuzEspecular);

            // Estabelece a posição da luz
            float[] PosicaoLuz = { 0.5f, 0.5f, 0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, PosicaoLuz);
        }

        static void Cor(float r, float g, float b)
        {
            float[] cor = { r, g, b, 1f };
            float[] sombra = { 0f, 0f, 0f, 0.5f };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, cor);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, cor);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, sombra);
        }


        static void Timer(int value)
        {
            if (!colisao)
            {
                iceZ += 0.1f;
                pontuacao += 1;
                if ((((iceX + 0.1f) > (b - 0.25f)) && ((iceX + 0.1f) < (b + 0.25f))) && (iceZ >= 2.5f))
                {
                    colisao = true;
                    Console.WriteLine("\nJogador: " + jogador);
                    Console.WriteLine("Pontuação: " + pontuacao);
                    Console.WriteLine("\nPressione F1 para jogar novamente...");
                }

                if (iceZ >= 3.4f)
                {
                    iceZ = 0.0f;
                    iceX = NextFloat(random);
                    if (clock > 10)
                    {
                        clock -= 10;
                    }
                }
                Glut.glutPostRedisplay();
                Glut.glutTimerFunc(clock, Timer, 1);
            }
        }

        static void TeclasEspeciais(int key, int x, int y)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_LEFT:
                    if (b > -1.1f)
                        b -= 0.1f;
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    if (b < 1.1f)
                        b += 0.1f;
                    break;
                case Glut.GLUT_KEY_F1:
                    colisao = false;
                    pontuacao = 0;
                    iceZ = 0.0f;
                    iceX = NextFloat(random);
                    clock = 150; 

                    Glut.glutTimerFunc(clock, Timer, 1);
                    break;
            }
            Glut.glutPostRedisplay();
        }

        static float NextFloat(Random random)
        {
            return ((random.Next(-10, 10)) >= 0) ? (float)((random.NextDouble() * 2.2f) * 1.0f) : (float)((random.NextDouble() * 2.2f) * (-1.0f));
        }



        static void Main()
        {
            Console.WriteLine("Para iniciar o jogo pressione F1!\n");
            Console.Write("Digite seu nome: ");
            jogador = Console.ReadLine();

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutCreateWindow("Boat Escape");

            Glut.glutTimerFunc(clock, Timer, 1);

            inicializa();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Glut.glutDisplayFunc(desenha);
            Glut.glutSpecialFunc(TeclasEspeciais);
            Glut.glutMainLoop();
        }
    }
}

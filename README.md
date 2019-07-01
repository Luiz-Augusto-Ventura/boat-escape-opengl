# boat-escape-opengl

Notas importantes: 

*Para que este projeto funcione, é necessário que se importe duas bibliotecas fundamentais, a GLUT(Graphics Library Utilitty Toolkit) e a OpenGL, obviamente. Para tal, utilizo o Tao Framework. Após instalá-lo, você pode adicionar as bibliotecas mencionadas nas referências do projeto, e, logo após, importá-las para seu código normalmente. Para isso, recomendo o seguinte tutorial: https://codeyarns.com/2013/06/18/how-to-get-started-with-tao-framework-using-c/ 

*É necessário compilar o projeto pelo menos uma vez, para que o Visual Studio possa criar o caminho "bin/Debug" dentro do projeto. Nesta pasta ficará o aplicativo final compilado para linguagem de máquina. 

*Certo, se você realizou o passo descrito acima, notará que uma excessão foi gerada. Pois bem, isso aconteceu porque a biblioteca GLUT do Tao Framework tem como dependência a DLL "freglut.dll" que acompanha o projeto. Para resolver este problema, você terá que mover esta DLL para o caminho "bin/Debug" do projeto. Por isso lhe pedi que compilasse o projeto primeiramente. 


Capturas de tela:

![Captura do jogo](https://github.com/Luiz-Augusto-Ventura/boat-escape-opengl/tree/master/screenshots/captura_game.png)



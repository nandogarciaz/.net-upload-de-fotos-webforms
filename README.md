# Upload de fotos feitos em ASP .NET WebForms

Esse c�digo faz tratamento de imagem redimensionando as fotos, salvando as fotos grandes e pequenas.

As foto s�o redimensionadas e centralizadas em cima de outra foto, que � fundo branco padr�o do sistema, padronizando a largura e altura da nova imagem que ser� salva.

O sistema j� tem tratamento para enviar apenas arquivos jpeg, jpg, n�o deixando enviar arquivos de outros formatos.

� exibida a imagem enviada com sucesso ou uma mensagem de erro caso ocorra algum erro no upload.



OBS: 
O c�digo esta todo comentado para melhor entendimento de quem esta come�ando a estudar .NET

- Mudar o endere�o das pastas dos arquivos
- A imagem de fundo est� verde para teste, tem que mudar para um fundo de outra cor
- Est� enviando apenas uma foto, caso queria enviar mais ter� de implementar.
- O padr�o de tamanho que as imagens ser�o salvas � baseado na imagem de fundo, a
imagem que � quadrada, se mudar o tamanho dessa imagem mudar� o tamanho de todas
as imagens grandes.
- O padr�o das imagens pequenas � 180L x 180A se quiser mudat tem que falterar o c�digo. 



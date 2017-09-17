# Upload de fotos feitos em ASP .NET WebForms

Esse código faz tratamento de imagem redimensionando as fotos, salvando as fotos grandes e pequenas.

As foto são redimensionadas e centralizadas em cima de outra foto, que é fundo branco padrão do sistema, padronizando a largura e altura da nova imagem que será salva.

O sistema já tem tratamento para enviar apenas arquivos jpeg, jpg, não deixando enviar arquivos de outros formatos.

É exibida a imagem enviada com sucesso ou uma mensagem de erro caso ocorra algum erro no upload.



OBS: 
O código esta todo comentado para melhor entendimento de quem esta começando a estudar .NET

- Mudar o endereço das pastas dos arquivos
- A imagem de fundo está verde para teste, tem que mudar para um fundo de outra cor
- Está enviando apenas uma foto, caso queria enviar mais terá de implementar.
- O padrão de tamanho que as imagens serão salvas é baseado na imagem de fundo, a
imagem que é quadrada, se mudar o tamanho dessa imagem mudará o tamanho de todas
as imagens grandes.
- O padrão das imagens pequenas é 180L x 180A se quiser mudat tem que falterar o código. 



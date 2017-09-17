using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace MesclarImagens
{
    public partial class Deafult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErro.Visible = false;
        }

        protected void btUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // verificando extensão do arquivo
                string[] allowedExtensions = { ".jpeg", ".jpg" };
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

                // verifica se a imagem é jpeg ou jpg
                if ((fileExtension == allowedExtensions[0]) || (fileExtension == allowedExtensions[1]))
                {
                    // Salva o arquivo na pasta temporária
                    FileUpload1.SaveAs(Server.MapPath("~/arquivos/temp/") + FileUpload1.FileName);

                    // Chama o método (upload/redimensionamento) da imagem
                    FotoRedim(FileUpload1.FileName);

                    // Deleta imagem temporária
                    File.Delete(Server.MapPath("~/arquivos/temp/") + FileUpload1.FileName);
                }
                else
                {
                    lblErro.Text = "Erro: Formato de arquivo inávlido, é aceito apenas jpg.";
                    lblErro.Visible = true;
                    Image1.ImageUrl = "";
                }
            }
       }

        protected void FotoRedim(string _filename)
        {
            // IMAGEM ENVIADA - O QUE VAI EM CIMA
            string Imagem = Server.MapPath("~/arquivos/temp/" + _filename);
            
            // IMAGEM DE FUNDO - O QUE VAI EM BAIXO
            // a imagem será redimensionada e centralizada nas medidas 
            // dessa imagem padrão do fundo, neste exemplo é 800x800
            string Fundo = Server.MapPath("~/arquivos/imgFundoGrande.jpg");
           
            // Criação dos objetos utilizando a classe Image
            System.Drawing.Image fundo = System.Drawing.Image.FromFile(Fundo);
            System.Drawing.Image foto = System.Drawing.Image.FromFile(Imagem);

            // variáveis para posicionar a foto de cima no centro da foto de baixo
            float dx = ((fundo.Width - foto.Width) / 2), dy = ((fundo.Height - foto.Height) / 2);
            // declarando dimensões da foto que foi enviada
            int fw = foto.Width, fh = foto.Height;

            // redimensionando fundo e alinhando a foto no centro do background (fundo)
            if (foto.Width < fundo.Width)
            {
                if (foto.Height < fundo.Height)
                {
                    fw = foto.Width;
                    fh = foto.Height;
                }
                else 
                {
                    fh = fundo.Height;
                    fw = (fundo.Width * foto.Width) / fundo.Height;
                    dy = 0.0F;
                }
            }
            else if (foto.Height < fundo.Height)
            {
                if (foto.Width < foto.Height)
                {
                    fh = fundo.Height;
                    fw = (fundo.Width * foto.Width) / fundo.Height;
                    dy = 0.0F;
                }
                else
                {
                    fh = (fundo.Height * foto.Height) / fundo.Width;
                    fw = fundo.Width;
                    dx = 0.0F;
                }
            }
            else 
            {
                // Se a altura e largura for maior entra nesse tratamento e redimensiona
                if (foto.Width < foto.Height)
                {
                    fh = fundo.Height;
                    fw = (fundo.Width * foto.Width) / foto.Height;
                    dy = 0.0F;
                    dx = ((fw - fh) / 2); // centralizando com as imagens já redimensionadas
                }
                else
                {
                    fh = (fundo.Height * foto.Height) / foto.Width;
                    fw = fundo.Width;
                    dx = 0.0F;
                    dy = ((fw - fh) / 2); // centralizando com as imagens já redimensionadas
                }
            }
              
            // Criação do objeto com a classe Graphics, para manipulação da fundo
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(fundo);

            // Inserção da foto no objeto gr (foto de fundo)
            // passando como parâmetro os pontos iniciais X/Y e o tamanho do fundo
            gr.DrawImage(foto, dx, dy, fw, fh);

            // Mapeando, renomeando e Salvando
            string nome = _filename.Replace(".jpg","") + "_280" + Path.GetExtension(_filename);
            string fotoGrande = Server.MapPath("~/arquivos/imagens/") + nome ;
            fundo.Save(fotoGrande, System.Drawing.Imaging.ImageFormat.Jpeg);

            System.Drawing.Image thumbnailImage = fundo.GetThumbnailImage(180, 180, null, IntPtr.Zero);

            string fotoPequena = Server.MapPath("~/arquivos/imagens/") + nome.Replace("_280", "_180");
            thumbnailImage.Save(fotoPequena, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Mostra a foto grande na tela
            Image1.ImageUrl = "~/arquivos/imagens/" + nome.Replace("_280", "_180");

            // liberando objeto da memória
            thumbnailImage.Dispose();
            fundo.Dispose();
            foto.Dispose();
            gr.Dispose();
        }
    
    }  
}
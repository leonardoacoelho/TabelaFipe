using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaFipe.BLL
{
    public static class ImagemBo
    {
        public static void Exportar(this Image imagem, string nomeEntidade, int id)
        {
            if (imagem != null)
            {
                var caminho = $@"{AppDomain.CurrentDomain.BaseDirectory}\Imagens\{nomeEntidade}\";
                var existe = Directory.Exists(caminho);

                if (!existe)
                    Directory.CreateDirectory(caminho);

                var fileName = $@"{caminho}\{id.ToString()}.jpeg";
                imagem.Save(fileName, ImageFormat.Jpeg);
            }
        }

        public static void Delete(string nomeEntidade, int id)
        {
            var caminho = $@"{AppDomain.CurrentDomain.BaseDirectory}\Imagens\{nomeEntidade}\";
            var fileName = $@"{caminho}\{id.ToString()}.jpeg";

            var fileInfo = new FileInfo(fileName);

            if (fileInfo.Exists)
                fileInfo.Delete();
        }

        public static Image Importar(string nomeEntidade, int id)
        {
            var caminho = $@"{AppDomain.CurrentDomain.BaseDirectory}\Imagens\{nomeEntidade}\";
            var fileName = $@"{caminho}\{id.ToString()}.jpeg";

            var fileInfo = new FileInfo(fileName);

            if (fileInfo.Exists)
            {
                var bytes = File.ReadAllBytes(fileName);
                var stream = new MemoryStream(bytes);
                return Image.FromStream(stream);
            }

            return null;
        }
    }
}

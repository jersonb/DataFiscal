using DataFiscal.Data;
using DataFiscal.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace DataFiscal.Facedes
{
    public class ImportFile
    {
        public List<Arquivo> ArquivosValidos { get; private set; }
        public List<Arquivo> TodosArquivos { get; private set; }
       

        private readonly ApplicationDbContext db;
        private readonly IList<IFormFile> uploads;

        public ImportFile(ApplicationDbContext _db, IList<IFormFile> _uploads)
        {
            db = _db;
            uploads = _uploads;
            ArquivosValidos = new List<Arquivo>();
            TodosArquivos = new List<Arquivo>();
            GeraArquivos();
        }

        public ImportFile(ApplicationDbContext _db)
        {
            db = _db;
           
        }

        public Arquivo LerArquivo(IFormFile arquivo)
        {
            using (var stream = arquivo.OpenReadStream())
            {
                var textReader = (TextReader)new StreamReader(stream);
                var xml = textReader.ReadToEnd();
               
                return new Arquivo
                {
                    Nome = arquivo.FileName,
                    Nf = new FileToNfe(db).GetNfe(xml),
                    Xml = xml
                };
            }
        }

        private void GeraArquivos()
        {
            foreach (var upload in uploads)
            {
                using (var stream = upload.OpenReadStream())
                {
                    var textReader = (TextReader)new StreamReader(stream);
                    var xml = textReader.ReadToEnd();
                    var arquivo = new Arquivo
                    {
                        Nome = upload.FileName,
                        Nf = new FileToNfe(db).GetNfe(xml),
                        Xml = xml
                    };

                    if (StatusArquivo(arquivo))
                    {
                        if (arquivo.Nf.Id == 0)
                        {
                            arquivo.Status = "Importada";
                            ArquivosValidos.Add(arquivo);
                            TodosArquivos.Add(arquivo);

                        }
                        else
                        {
                            arquivo.Status = "Importada Anteriormente";
                            TodosArquivos.Add(arquivo);
                        }
                    }
                    else
                    {
                        arquivo.Status = "Este Arquivo não é uma Nota Fiscal";
                        TodosArquivos.Add(arquivo);
                    }
                   
                }
            }
        }

        private bool StatusArquivo(Arquivo arquivo)
        {
            return arquivo.Nf != null;
        }
    }
}

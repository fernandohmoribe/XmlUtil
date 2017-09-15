using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlUtil.Classes
{
    public class NotaItem
    {
        public int ID { get; set; }
        public int IDNota { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }


        public NotaItem()
        {

        }

        public NotaItem(int inteiro, double flutuante)
        {
            ID = inteiro;
            IDNota = inteiro;
            Quantidade = inteiro;
            Preco = flutuante;
        }
    }
}

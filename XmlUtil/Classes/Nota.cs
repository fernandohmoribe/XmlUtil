using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableWatcher.Base;

namespace XmlUtil.Classes
{
    public class Nota
    {
        [AtributoBanco("Handle")]
        public string GuidID { get; set; }

        [AtributoBanco("NumeroNota")]
        public string Numero { get; set; }

        public string Conta { get; set; }

        public List<NotaItem> Items { get; set; }

        public Nota()
        {

        }

        public Nota(int pID)
        {
            Random objRandom = new Random();

            GuidID = Guid.NewGuid().ToString();
            Numero = "NumeroNota" + GuidID;
            Items = new List<NotaItem>();
            for (int i = 0; i < 3; i++)
            {
                int inteiro = objRandom.Next(1000);
                double flutuante = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(objRandom.NextDouble()), 2));
                Items.Add(new NotaItem(inteiro, flutuante));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableWatcher;

namespace XmlUtil.Classes
{
    public class Abrev
    {
        [AtributoBanco("Handle")]
        public int Handle { get; set; }

        [AtributoBanco("Descricao")]
        public string Descricao { get; set; }

        [AtributoBanco("Abreviatura")]
        public string Abreviatura { get; set; }
    }
}

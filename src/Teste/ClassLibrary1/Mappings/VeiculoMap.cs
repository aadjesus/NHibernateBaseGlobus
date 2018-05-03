using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Mappings
{
    public class VeiculoMap : MapBase<VeiculoModel>
    {
        public VeiculoMap()
        {
            CreateIdColumn("DiaDaSemana", "Id");
            //References(r => r.TipoDeDia, "IdTipoDeDia");
            //Map(m => m.Dia, "Dia").CustomType<eTipoDeDia>();
        }
    }
}

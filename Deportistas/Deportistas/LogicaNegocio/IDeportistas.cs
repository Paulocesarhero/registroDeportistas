using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deportistas.Dominio;

namespace Deportistas.LogicaNegocio
{
    public interface IDeportistas
    {
        public Boolean registrarDeportista(Deportista deportista);
    }
}